using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
        private bool _invoked = false;
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
            _invoked = true;
        }

        private void OnDisable()
        {
            _velocityOnZero -= StopTheDice;
        }

        public void ApplyForce(Vector3 dir, float speed)
        {
            _speed = speed * multiply;
            _body.velocity = dir * _speed;
            //Debug.Log(_body.velocity + " " + dir);
            _body.useGravity = true;
        }

        private void Start()
        {
            _body.AddTorque(30,0,30);
        }

        private void Update()
        {
            speedBody = _body.velocity;
            if(_body.velocity == Vector3.zero && _invoked && _body.angularVelocity == Vector3.zero)
            {
                _velocityOnZero?.Invoke();
                _invoked = false;
            }
        }

        public void StopTheDice()
        {
            _body.velocity = Vector3.zero;
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                _numberOnImpact--;
            }
        }
    }
}