using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.References
{
    public class Reference<T> : SerializedScriptableObject where T : new()
    {
        [field: SerializeField][HideLabel] public T Object = new T();
    }
}
