using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TowerInformation", menuName = "Tower Information",order = 0)]
    public class TowerInfor : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _cost;
        [SerializeField] private TowerSpeed _speed;
        [TextArea] [SerializeField] private string _description;

        public string Name => _name;
        public int Cost => _cost;

        public string Speed
        {
            get
            {
                switch (_speed)
                {
                    case TowerSpeed.FAST:
                    {
                        return "Fast";
                    }
                    default:
                        return "Undefined";
                }
            }
        }
    }

    public enum TowerSpeed
    {
        FAST,
        SLOW,
        MEDIUM,
    }
}