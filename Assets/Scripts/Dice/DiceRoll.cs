using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class DiceRoll : MonoBehaviour
    {
        private Rigidbody _body;
        private PhysicBaseMovement _physic;

        private bool _stopTheDice = false;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
            _physic = GetComponent<PhysicBaseMovement>();
        }

        private void OnEnable()
        {
            _physic._velocityOnZero += StopTheDice;
        }

        private void OnDisable()
        {

            _physic._velocityOnZero -= StopTheDice;
        }

        private void Update()
        {
            if (_stopTheDice)
            {
                _body.angularVelocity = Vector3.zero;
                Vector3 temp = transform.eulerAngles;
                //Debug.Log(temp);
                //Debug.Log(new Vector3(FindClosestMultipleOf90(temp.x), FindClosestMultipleOf90(temp.y), temp.z));
                transform.eulerAngles =
                    new Vector3(FindClosestMultipleOf90(temp.x), FindClosestMultipleOf90(temp.y), FindClosestMultipleOf90(temp.z));
                _stopTheDice = false;
            }
        }

        public void RollDice(float throwForce, float rollForce, int i)
        {
            var randomVariance = Random.Range(-1f, 1f);
           // _body.AddForce(transform.forward * (throwForce + randomVariance), ForceMode.Impulse);

            var randX = Random.Range(0f, 1f);
            var randY = Random.Range(0f, 1f);
            var randZ = Random.Range(0f, 1f);

            _body.AddTorque(new Vector3(randX, randY, randZ) * (rollForce + randomVariance), ForceMode.Impulse);
        }

        public void StopTheDice()
        {
            _stopTheDice = true;
        }
        
        public static float FindClosestMultipleOf90(float number)
        {
            // Calculate the nearest multiple of 90
            int quotient = (int)(number / 90.0f);
            float remainder = number % 90.0f;
            float closestMultiple;

            if (Math.Abs(remainder) <= 45.0f)
            {
                closestMultiple = quotient * 90.0f;
            }
            else
            {
                closestMultiple = (quotient+1) * 90.0f;
            }

            return closestMultiple;
        }
    }
}