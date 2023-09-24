using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class OnDiceResult : MonoBehaviour
    {
        [SerializeField] private DiceInforSO _information;
        [SerializeField] private List<DiceResultAction> _diceFaces;
        private void OnEnable()
        {
            GetComponent<PhysicBaseMovement>()._velocityOnZero += OnAction;
        }

        private void OnDisable()
        {
            GetComponent<PhysicBaseMovement>()._velocityOnZero -= OnAction;
        }

        private void OnAction()
        {
            _diceFaces[GetComponent<FaceDetector>().topFace].OnResult();
        }
    }
}