using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicBaseMovement : MonoBehaviour
    {
        private Rigidbody2D _body;
        [SerializeField] private float multiply;
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _movementDirection;
        [SerializeField] private Vector2 speedBody;

        public delegate void VelocityOnZero();

        public VelocityOnZero _velocityOnZero;
        
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        public void ApplyForce(Vector2 dir, float speed)
        {
            this._speed = speed * multiply;
            _body.velocity = dir * _speed;
        }

        private void Update()
        {
            if (_body.velocity == Vector2.zero && speedBody != Vector2.zero)
            {
                _velocityOnZero?.Invoke();
            }
            speedBody = _body.velocity;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.gameObject.CompareTag("Wall"))
            {
                _movementDirection = Vector2.Reflect(_movementDirection, col.contacts[0].normal);
            } 
        }
    }
}