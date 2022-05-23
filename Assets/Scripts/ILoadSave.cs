using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public interface ILoadSave<T>
    {
        void SaveBonus(T bonuses, string path = null);
        
        T LoadBonus(string path = null);
    }
}