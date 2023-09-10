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
            speedBody = _body.velocity;
        }

        // private void FixedUpdate()
        // {
        //     _body.velocity = _movementDirection * _speed;
        // }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.gameObject.CompareTag("Wall"))
            {
                Debug.Log(col.contacts[0].normal);
                _movementDirection = Vector2.Reflect(_movementDirection, col.contacts[0].normal);
            } 
        }
    }
}