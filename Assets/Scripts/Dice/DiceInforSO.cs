using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "DiceData", menuName = "SO/DiceData", order = 0)]
    public class DiceInforSO : ScriptableObject
    {   
        public List<TowerInfor> _resultActions { get; private set;}

        // public void AddData(IDataDiceResult action)
        // {
        //     if (_resultActions.Count >= 6) return;
        //     _resultActions.Add(action);
        // }
    }
}