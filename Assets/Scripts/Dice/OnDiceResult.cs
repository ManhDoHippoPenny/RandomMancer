using System;
using System.Collections.Generic;
using log4net.Core;
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
            Debug.Log("On Dice Result");
            Vector3 tempPos = transform.position - LevelManager.Instance._root.position;
            Debug.Log(Mathf.Round(tempPos.x / LevelManager.Instance._size) + " " + Mathf.Round(tempPos.z / LevelManager.Instance._size));
            _diceFaces[GetComponent<FaceDetector>().topFace].OnResult(LevelManager.Instance._root.position + 
                new Vector3(Mathf.Round(tempPos.x / LevelManager.Instance._size) * LevelManager.Instance._size, 1f,
                    Mathf.Round(tempPos.z / LevelManager.Instance._size) * LevelManager.Instance._size));
        }
    }
}