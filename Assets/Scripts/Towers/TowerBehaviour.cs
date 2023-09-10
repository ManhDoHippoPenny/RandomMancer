using DefaultNamespace.ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace.Towers
{
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private TowerInfor _towerInfor;

        public void SetTowerInfor(TowerInfor infor)
        {
            _towerInfor = infor;
        }
    }
}