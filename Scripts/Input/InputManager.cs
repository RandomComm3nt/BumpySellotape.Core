using UnityEngine;

namespace BumpySellotape.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        public InputHandler<TController> SetInputHandler<THandler, TController>(TController controller)
            where THandler : InputHandler<TController>
        {
            var go = new GameObject(typeof(THandler).Name);
            var handler = go.AddComponent<THandler>();
            handler.Initialise(controller);
            go.transform.SetParent(transform);
            return handler;
        }
    }
}