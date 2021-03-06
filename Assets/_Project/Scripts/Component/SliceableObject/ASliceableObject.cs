using UnityEngine;
using EzySlice;
using System;
using CookRun.Utility.Audio;

namespace CookRun.Component.SliceableObject
{
    [RequireComponent(typeof(Collider))]
    public abstract class ASliceableObject : AComponent, ISliceable, ISoundable
    {
        [Header("FX")]
        [SerializeField] protected Material crossSectionMaterial = null;
        [SerializeField] protected AudioClip[] audioClip = null;
        [SerializeField] protected GameObject sliceEffect = null;
        protected IDecalPlacer _decalPlacer = null;

        [Header("CutOff Parts Slice Force")]
        [SerializeField] protected bool addForceToParts = true;
        [Tooltip("X - min value; Y - max value")]
        [SerializeField] protected Vector2 force = Vector2.one;

        [Header("Other")]
        [SerializeField] protected DynamicPart dynamicPart = DynamicPart.Both;
        [SerializeField] protected int objectLayer = 0; 
        [SerializeField] protected int cutOffPartLayer = 0; 

        protected enum DynamicPart
        {
            None,
            Both,
            Lower,
            Upper
        }

        protected virtual void Awake()
        {
            _decalPlacer = GetComponent<IDecalPlacer>();
            gameObject.layer = objectLayer;
        }

        public virtual void Slice(Vector3 position, Vector3 direction)
        {
            DoSlice(position, direction);
            SliceReaction();
        }

        protected virtual void SliceReaction()
        {
            MakeSound();
            SpawnSliceEffect();
            PlaceDecal();

            gameObject.SetActive(false);
        }

        protected virtual void DoSlice(Vector3 position, Vector3 direction)
        {
            SlicedHull slicedHull = GetSlicedHull(position, direction, crossSectionMaterial);

            SetupCutOffPart(direction, () => slicedHull.CreateUpperHull(gameObject, crossSectionMaterial));
            SetupCutOffPart(-direction, () => slicedHull.CreateLowerHull(gameObject, crossSectionMaterial));
        }

        protected virtual SlicedHull GetSlicedHull
            (Vector3 position, Vector3 direction, Material crossSectionMaterial)
        {
            return gameObject.Slice(position, direction, crossSectionMaterial);
        }

        protected virtual void SetupCutOffPart(Vector3 sliceDirection, Func<GameObject> creation)
        {
            GameObject part = creation.Invoke();
            part.layer = cutOffPartLayer;
            float force = GetForce();

            if (PartDynamic(part.name))
            {
                var dynamicPart = CutOffPartDynamic.AddComponent<BoxCollider>(part);
                if (addForceToParts)
                    dynamicPart.AddForce(sliceDirection, force);
            }
            else
            {
                CutOffPartStatic.AddComponent(part);
            }
        }

        private float GetForce() => UnityEngine.Random.Range(force.x, force.y);

        private bool PartDynamic(string partName)
        {
            if (dynamicPart == DynamicPart.None)
                return false;

            if (dynamicPart == DynamicPart.Both)
                return true;

            if (partName.Contains("Lower"))
                return dynamicPart == DynamicPart.Lower;
            else if (partName.Contains("Upper"))
                return dynamicPart == DynamicPart.Upper;

            return false;
        }

        protected override void OnDisable()
        {
            Destroy();
        }

        public virtual void MakeSound()
        {
            if (audioClip == null || audioClip.Length < 1)
                return;

            int randomIndex = UnityEngine.Random.Range(0, audioClip.Length - 1);
            AudioClip clip = audioClip[randomIndex];
            AudioPlayer.PlayClipAtPoint(clip, transform.position);
        }

        protected virtual GameObject SpawnSliceEffect()
        {
            //Returnes false both when quitting the app/editor and when unloading the scene
            //Make sure that the object is not instantiated when the scene is unloaded
            if (!gameObject.scene.isLoaded || sliceEffect == null)
                return null;

            return Instantiate(sliceEffect, transform.position, Quaternion.identity);
        }

        public virtual void PlaceDecal()
        {
            _decalPlacer?.PlaceDecalOnHitPoint();
        }
    }
}