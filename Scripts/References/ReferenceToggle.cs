using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.References
{
    [HideReferenceObjectPicker]
    public class ReferenceToggle<T> where T : new()
    {
        [SerializeField] private bool useReference = default;
        [SerializeField, HideIf(nameof(useReference)), HideLabel] private T directObject = default;
        [SerializeField, ShowIf(nameof(useReference))] private Reference<T> objectReference = default;

        public T Object => useReference ? objectReference.Object : directObject;

        public static implicit operator T(ReferenceToggle<T> r) => r.Object;
    }
}
