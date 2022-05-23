using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public sealed class MyNullException : Exception
    {
        internal int messege { get; private set; }
        public MyNullException(string message) : base(message)
        {
            this.messege = messege;
        }
    }
}