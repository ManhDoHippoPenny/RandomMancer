using DefaultNamespace.ScriptableObjects;
using DefaultNamespace.Towers;
using UnityEngine;

namespace DefaultNamespace
{
    public class RespawnOnResult : DiceResultAction<TowerInfor>
    {
        public override void OnResult(Vector3 pos)
        {
            Debug.Log("Spawn Tower " + pos);
            var tower = TowerSpawner.Instance.Spawn(pos);
            tower.GetComponent<TowerBehaviour>()._towerInfor = _dataForAction;
        }
    }
}