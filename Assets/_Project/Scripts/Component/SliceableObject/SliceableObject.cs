using UnityEngine;
using EzySlice;
using Random = UnityEngine.Random;

namespace CookRun.Component.SliceableObject
{
    public class SliceableObject : ASliceableObject
    {
        [SerializeField] protected Vector3[] sliceDirection = new Vector3[2] { Vector3.zero, Vector3.zero };

        public override void Slice(Vector3 position, Vector3 direction)
        {
            direction = GetDirection();
            position = transform.position;
            DoSlice(position, direction);
            SliceReaction();
        }

        private Vector3 GetDirection()
        {
            float x = Random.Range(sliceDirection[0].x, sliceDirection[1].x);
            float y = Random.Range(sliceDirection[0].y, sliceDirection[1].y);
            float sign = Random.value < 0.5f ? 1.0f : -1.0f;
            var direction = new Vector3(x, y * sign, 0.0f);
            return direction;
        }

        protected override void DoSlice(Vector3 position, Vector3 direction)
        {
            SlicedHull slicedHull = GetSlicedHull(position, direction, crossSectionMaterial);

            SetupCutOffPart(Vector3.right, () => slicedHull.CreateUpperHull(gameObject, crossSectionMaterial));
            SetupCutOffPart(Vector3.left, () => slicedHull.CreateLowerHull(gameObject, crossSectionMaterial));
        }
    }

    public interface ISliceable
    {
        void Slice(Vector3 position, Vector3 direction);
    }
}