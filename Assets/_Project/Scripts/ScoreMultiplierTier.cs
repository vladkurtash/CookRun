using System.Linq;
using UnityEngine;

namespace CookRun
{
    public class ScoreMultiplierTier : MonoBehaviour
    {
        private Table[] _tables = null;

        private void Awake()
        {
            _tables = GetComponentsInChildren<Table>().ToArray();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                ServeTables();
        }

        private void ServeTables()
        {
            for (int i = 0; i < _tables.Length; i++)
            {
                _tables[i].Serve();
            }
        }
    }
}