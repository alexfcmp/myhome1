using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public sealed class GoodBonus : BaseBonus
    {
        internal static UnityAction onGoodBonusTook;

        protected override void ChangeSpeed() => Player.speed = Random.Range(8, 15);

        void OnTriggerEnter(Collider other)
        {
            ChangeSpeed();
            onGoodBonusTook.Invoke();
        }
    }
}