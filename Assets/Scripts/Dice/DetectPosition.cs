using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DetectPosition : MonoBehaviour
    {
        [SerializeField] private GridManager.GridManager _gridManager;
        public Vector2 result;
        private void Start()
        {
            GetComponent<PhysicBaseMovement>()._velocityOnZero += GetPositionInGrid;
        }

        public void GetPositionInGrid()
        {
            Vector2 temp = transform.position - _gridManager._holder.transform.position + new Vector3(1.5f,1.5f,0f);
            //Debug.Log((Vector2) GetComponent<DragAndDropAble>().WorldPos + " " + (Vector2)_gridManager._holder.transform.position);
            Debug.Log(temp);
            result = new Vector2(Mathf.RoundToInt(temp.x), Mathf.RoundToInt(temp.y));
        }
    }
}