using UnityEngine;

namespace CookRun.Component
{
    public class ObjectRotator : AComponent
    {
        [SerializeField] private Vector3 _vector;
        [SerializeField] private float _speed;
        private Transform _transform;
        private void Awake() =>
            _transform = GetComponent<Transform>();

        private void Update() =>
            _transform.Rotate(_vector, _speed * Time.deltaTime);
    }
}