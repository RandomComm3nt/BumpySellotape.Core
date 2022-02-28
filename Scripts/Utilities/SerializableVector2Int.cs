using System;
using UnityEngine;

namespace BumpySellotape.Core.Utilities
{
    [Serializable]
    public struct SerializableVector2Int
    {
        [SerializeField] private int x;
        [SerializeField] private int y;

        public SerializableVector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator Vector2Int(SerializableVector2Int v) => new (v.x, v.y);
        public static implicit operator SerializableVector2Int(Vector2Int v) => new (v.x, v.y);
    }
}