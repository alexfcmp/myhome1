using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public abstract class BaseBonus : MonoBehaviour
    {
        abstract protected void ChangeSpeed();
    }
}