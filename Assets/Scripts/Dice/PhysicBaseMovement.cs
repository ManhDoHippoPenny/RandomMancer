using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PhysicBaseMovement : MonoBehaviour
    {
        private Rigidbody _body;
        [SerializeField] private float multiply;
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _movementDirection;
        [SerializeField] private Vector3 speedBody;

        public delegate void VelocityOnZero();

        public VelocityOnZero _velocityOnZero;
        
        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
        }

        public void ApplyForce(Vector2 dir, float speed)
        {
            this._speed = speed * multiply;
            _body.velocity = dir * _speed;
        }

        private void Update()
        {
            if (_body.velocity == Vector3.zero && speedBody != Vector3.zero)
            {
                _velocityOnZero?.Invoke();
            }
            speedBody = _body.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.CompareTag("Wall"))
            {
                Vector2 reflect = Vector2.Reflect(_movementDirection, collision.contacts[0].normal);
                _movementDirection = new Vector3(reflect.x,reflect.y,0);
            } 
        }
    }
}