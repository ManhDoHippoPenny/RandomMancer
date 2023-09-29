﻿using DefaultNamespace.Effect;
using UnityEngine;

namespace DefaultNamespace
{
    public class ExplodeOnResult : DiceResultAction<ExplodeEffect>
    {
        [SerializeField] private float _radius;
        
        public override void OnResult(Vector3 pos)
        {
            ExplodeSpawner.Instance.Spawn(this.transform.position,_radius);
        }
    }
}