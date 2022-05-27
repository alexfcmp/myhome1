using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public interface ILoadSave<T>
    {
        void Save(T item, string path = null);
        
        T Load(string path = null);
    }
}