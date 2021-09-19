using BumpySellotape.Core.Messaging;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Traits.Model
{

    [HideReferenceObjectPicker]
    public class StackChangeRule
    {
        [field: SerializeField, LabelText("Trigger")] public MessageFilter MessageFilter { get; private set; } = new();
        [field: SerializeField, LabelText("Amount")] public int StackChangeAmount { get; private set; }
    }
}
