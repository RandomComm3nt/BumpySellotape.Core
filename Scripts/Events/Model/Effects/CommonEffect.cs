using BumpySellotape.Events.Model.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Packages.Events.Model.Effects
{
    public class CommonEffect : IEffect
    {
        [SerializeField, FoldoutGroup("@Label"), OnValueChanged("EffectDefinitionChanged")] private /*CommonEffectDefinition*/ MonoBehaviour effectDefinition;

        public string Label => effectDefinition ? effectDefinition.name : "[Common Effect]";

        void IEffect.Process(ProcessingContext processingContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
