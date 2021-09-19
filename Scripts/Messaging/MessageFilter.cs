using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Core.Messaging
{
    [HideReferenceObjectPicker]
    public struct MessageFilter
    {
        public MessageFilter(MessageType messageType) : this()
        {
            MessageType = messageType;
        }

        [field: SerializeField] public MessageType MessageType { get; private set; }
        [field: SerializeField, HideInInspector] public string MessageName { get; private set; }
    }
}
