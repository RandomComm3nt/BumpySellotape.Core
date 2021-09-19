using BumpySellotape.Core.Stats.Controller;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    [HideReferenceObjectPicker]
    public class StatCollectionGenerator : Generator<StatCollection>
    {
        [SerializeField, ListDrawerSettings(CustomAddFunction = nameof(CreateGeneratedStatTemplate))] private List<GeneratedStatTemplate> statTemplates = new();
        public List<GeneratedStatTemplate> StatTemplates { get => statTemplates; }

        public override StatCollection GenerateT()
        {
            var sc = new StatCollection();
            sc.GenerateFromTemplates(statTemplates);
            return sc;
        }

        private GeneratedStatTemplate CreateGeneratedStatTemplate()
        {
            return new GeneratedStatTemplate();
        }
    }
}
