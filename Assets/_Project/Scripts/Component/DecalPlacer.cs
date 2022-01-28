using UnityEngine;

namespace CookRun.Component
{
    //TODO: Implement object pooler system
    public class DecalPlacer : AComponent, IDecalPlacer
    {
        [SerializeField] private GameObject decalPrefab = null;
        [SerializeField] private Texture[] decal = null;
        [SerializeField] private Color32 color = new Color32(1, 1, 1, 255);
        [SerializeField] private Vector3 direction = Vector3.down;
        [SerializeField] private float distanceMax = 1.0f;

        public void PlaceDecalOnHitPoint()
        {
            if (Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, distanceMax))
            {
                Place(hit.point);
            }
        }

        private void Place(Vector3 position)
        {
            var rotation = GetRotation();
            GameObject spawnedDecal = Instantiate(decalPrefab, position, rotation);
            var renderer = spawnedDecal.GetComponent<Renderer>();
            SetupMaterial(renderer.material);
        }

        private Quaternion GetRotation() =>
            Quaternion.Euler(90, 0, Random.Range(0, 360));

        private void SetupMaterial(Material material)
        {
            Texture texture = GetDecalTexture();
            material.mainTexture = texture;
            material.color = color;
        }

        private Texture GetDecalTexture()
        {
            int randomIndex = Random.Range(0, decal.Length - 1);
            return decal[randomIndex];
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            RaycastHit raycastHit = default;
            bool hit = Physics.Raycast(transform.position, direction.normalized, out raycastHit, distanceMax);
            if (hit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, direction.normalized * raycastHit.distance);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, direction.normalized * distanceMax);
            }
        }
#endif
    }

    public interface IDecalPlacer
    {
        void PlaceDecalOnHitPoint();
    }
}