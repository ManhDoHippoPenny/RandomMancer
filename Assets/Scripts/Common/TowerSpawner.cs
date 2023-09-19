using UnityEngine;

namespace DefaultNamespace
{
    public class TowerSpawner : Singleton<TowerSpawner>
    {
        [SerializeField] private GameObject _TowerPrefab;
        [SerializeField] private GameObject _holder;
        
        // public void SpawnTower(Vector2 position, TowerInfor infor)
        // {
        //     GameObject tower = Instantiate(_TowerPrefab, position, Quaternion.identity);
        //     tower.transform.SetParent(_holder.transform);
        //     tower.GetComponent<TowerBehaviour>().SetTowerInfor(infor);
        // }
    }
}