using BumpySellotape.Events.Model.Effects;
using UnityEngine;

namespace BumpySellotape.Events.Model.Nodes
{
    public class EventTrigger
    {
        [field: SerializeField] public IEffect Effect { get; set; }
    }
}
