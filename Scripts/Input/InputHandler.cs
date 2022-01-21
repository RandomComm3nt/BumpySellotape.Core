using UnityEngine;

namespace BumpySellotape.Core.Input
{
    public abstract class InputHandler<T> : MonoBehaviour
    {
        public abstract void Initialise(T controller);
    }
}