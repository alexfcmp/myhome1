using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public sealed class BadBonus : BaseBonus
    {
        internal static UnityAction onBadBonusTook;

        protected override void ChangeSpeed() => Player.speed = Random.Range(1, 3);

        void OnTriggerEnter(Collider other)
        {
            ChangeSpeed();
            onBadBonusTook.Invoke();
        }
    }
}