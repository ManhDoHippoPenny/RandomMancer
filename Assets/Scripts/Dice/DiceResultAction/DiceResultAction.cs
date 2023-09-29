using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class DiceResultAction : MonoBehaviour
    {
        public virtual void OnResult(Vector3 pos)
        {
            
        }
    }

    public abstract class DiceResultAction<T1> : DiceResultAction
    {
        [NotNull] protected T1 _dataForAction;
    }
}