using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class DiceRoll : MonoBehaviour
    {
        private Rigidbody _body;

        [SerializeField] private float maxRandomForceValue, startRollingForce;

        private float forceX, forceY, forceZ;

        public int diceFaceNum;

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if (_body != null)
            {
                RollDice();
            }
        }

        private void RollDice()
        {
            _body.isKinematic = false;
            
            _body.AddForce(Vector3.up * startRollingForce);
            _body.AddTorque(forceX,forceY,forceZ);
        }

        private void Initialize()
        {
            _body = GetComponent<Rigidbody>();
            _body.isKinematic = true;
            transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
            
        }
    }
}