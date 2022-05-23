using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public class WinController : MonoBehaviour
    {
        internal static UnityAction onPlayerWin;
        void OnTriggerEnter(Collider other) => onPlayerWin.Invoke();
    }
}