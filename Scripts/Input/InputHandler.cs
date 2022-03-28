using UnityEngine;
using UnityEngine.InputSystem;

namespace BumpySellotape.Core.Input
{
    public abstract class InputHandler : MonoBehaviour
    {
        public virtual void OnEnable()
        {
            GetComponentInParent<PlayerInput>().SwitchCurrentActionMap(ActionMap);
        }

        public abstract void Initialise(object controller);

        public abstract string ActionMap { get; }
    }

    public abstract class InputHandler<T> : InputHandler
        where T : class
    {
        public override void Initialise(object controller)
        {
            Initialise(controller as T);
        }

        protected abstract void Initialise(T controller);
    }
}