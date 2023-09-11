using System;
using System.Collections.Generic;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class DiceRoll : MonoBehaviour
    {
        private Rigidbody _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
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
    }
}