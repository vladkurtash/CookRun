using UnityEngine;
using EzySlice;
using System;

namespace CookRun.Component.SliceableObject
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class SliceableObject : AComponent, ISliceable, ISoundable
    {
        [SerializeField] protected Material crossSectionMaterial = null;
        [SerializeField] protected AudioClip audioClip = null;
        [SerializeField] protected GameObject sliceEffect = null;
        [SerializeField] protected bool addForceToParts = true;
        [SerializeField] protected float force = 0.0f;
        [SerializeField] protected DynamicPart dynamicPart = DynamicPart.Both;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }

        protected enum DynamicPart
        {
            None,
            Both,
            Lower,
            Upper
        }

        public void Slice(Vector3 position, Vector3 direction)
        {
            DoSlice(position, direction);
            MakeSound();
            //SpawnSliceEffect();

            gameObject.SetActive(false);
        }

        protected virtual void DoSlice(Vector3 position, Vector3 direction)
        {
            Material crossSectionMaterial = null;//GetCrossSectionMaterial();
            SlicedHull slicedHull = GetSlicedHull(position, direction, crossSectionMaterial);

            SetupCutOffPart(direction, () => slicedHull.CreateUpperHull(gameObject, crossSectionMaterial));
            SetupCutOffPart(-direction, () => slicedHull.CreateLowerHull(gameObject, crossSectionMaterial));
        }

        protected virtual SlicedHull GetSlicedHull(Vector3 position, Vector3 direction, Material crossSectionMaterial)
        {
            return gameObject.Slice(position, direction, crossSectionMaterial);
        }

        protected virtual void SetupCutOffPart(Vector3 sliceDirection, Func<GameObject> creation)
        {
            GameObject part = creation.Invoke();

            if (PartDynamic(part.name))
            {
                CutOffPartDynamic dynamicPart = part.AddComponent<CutOffPartDynamic>();
                if (addForceToParts)
                    AddForceToPart(dynamicPart, sliceDirection, force);
            }
            else
            {
                part.AddComponent<CutOffPartStatic>();
            }
        }

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

        protected virtual void AddForceToPart(CutOffPartDynamic dynamicPart, Vector3 direction, float force)
        {
            dynamicPart.AddForce(direction, force);
        }

        protected override void OnDisable()
        {
            Destroy();
        }

        public virtual void MakeSound()
        {
            
        }

        protected virtual GameObject SpawnSliceEffect()
        {
            //Returnes false both when quitting the app/editor and when unloading the scene
            //Make sure that the object is not instantiated when the scene is unloaded
            if (!gameObject.scene.isLoaded)
                return null;

            return Instantiate(sliceEffect, transform.position, Quaternion.identity);
        }
    }

    public interface ISliceable
    {
        void Slice(Vector3 position, Vector3 direction);
    }
}