using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects.Text
{
    [HideReferenceObjectPicker]
    public class DialogueActor
    {
        [field: SerializeField] public string ActorName { get; private set; }
    }
}
