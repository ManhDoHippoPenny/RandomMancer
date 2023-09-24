using DefaultNamespace.ScriptableObjects;
using DefaultNamespace.Towers;
using UnityEngine;

namespace DefaultNamespace
{
    public class RespawnOnResult : DiceResultAction<TowerInfor>
    {
        public override void OnResult()
        {
            var tower = TowerSpawner.Instance.Spawn(this.transform.position);
            tower.GetComponent<TowerBehaviour>()._towerInfor = _dataForAction;
        }
    }
}