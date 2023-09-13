using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PhysicBaseMovement : MonoBehaviour
    {
        private Rigidbody _body;
        [SerializeField] private float multiply;
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 speedBody;
        [SerializeField] private int _numberOnImpact;


        private float counter;
        [SerializeField] private float _timeCalCol;
        public delegate void VelocityOnZero();

        public VelocityOnZero _velocityOnZero;
        
        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
            counter = _timeCalCol;
        }

        private void OnEnable()
        {
            _velocityOnZero += StopTheDice;
        }

        private void OnDisable()
        {
            _velocityOnZero -= StopTheDice;
        }

        public void ApplyForce(Vector2 dir, float speed)
        {
            this._speed = speed * multiply;
            _body.velocity = dir * _speed;
        }

        private void Update()
        {
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                _numberOnImpact--;
                counter = _timeCalCol;
            }
            if (_numberOnImpact == 0)
            {
                _velocityOnZero?.Invoke();
            }
            speedBody = _body.velocity;
        }

        public void StopTheDice()
        {
            _body.velocity = Vector3.zero;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.CompareTag("Wall"))
            {
                _body.velocity = Vector3.Reflect(speedBody, collision.contacts[0].normal);
                _numberOnImpact--;
                counter = _timeCalCol;
            } 
        }
    }
}