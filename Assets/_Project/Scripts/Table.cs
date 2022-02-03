using System.Linq;
using UnityEngine;

namespace CookRun
{
    public class Table : MonoBehaviour
    {
        [SerializeField] private GameObject foodAppearanceVFX = null;
        [SerializeField] private Transform foodSpawnPointTransform = null;
        [SerializeField] private string animationState = "Clap";
        private Animator[] _characterAnimators = null;
        [SerializeField] private GameObject[] food = null;

        private void Awake()
        {
            _characterAnimators = GetComponentsInChildren<Animator>().ToArray();
        }

        public void Serve()
        {
            SpawnFood();
            SpawnVFX();
            EnableCharactersAnimation();
        }

        private void EnableCharactersAnimation()
        {
            for (int i = 0; i < _characterAnimators.Length; i++)
            {
                _characterAnimators[i].SetBool(animationState, true);
            }
        }

        private void SpawnVFX()
        {
            Instantiate(foodAppearanceVFX, foodSpawnPointTransform.position, Quaternion.identity);
        }

        private void SpawnFood()
        {
            GameObject foodToSpawn = GetFood();
            GameObject spawnedFood = Instantiate(foodToSpawn, foodSpawnPointTransform.position, Quaternion.identity);
            spawnedFood.transform.localScale = new Vector3(1, 1, 1);
        }

        private GameObject GetFood()
        {
            int randomFoodIndex = Random.Range(0, food.Length - 1);
            return food[randomFoodIndex];
        }
    }
}