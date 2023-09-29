using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DetectPosition : MonoBehaviour
    {
        public Vector2 result;

        public Vector2 GetPositionInGrid()
        {
            Vector3 temp = (transform.position - LevelManager.Instance._root.position) / LevelManager.Instance._size;
            result = new Vector2(Mathf.RoundToInt(temp.x + 0.5f), Mathf.RoundToInt(temp.z + 0.5f));
            Debug.Log(result);
            return result;
        }
    }
}