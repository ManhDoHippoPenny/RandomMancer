using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class FaceDetector : MonoBehaviour
    {
        private DiceRoll dice;

        private void Awake()
        {
            dice = GetComponent<DiceRoll>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (dice != null)
            {
                if (dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
                    dice.diceFaceNum = int.Parse(other.name);
                }
            }
        }
    }
}