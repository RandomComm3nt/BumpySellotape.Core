using BumpySellotape.Core.Stats.Controller;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Stats.Model
{
    [HideReferenceObjectPicker]
    public class StatCollectionGenerator : Generator<StatCollection>
    {
        [SerializeField] private List<GeneratedStatTemplate> statTemplates = new();

        public override StatCollection GenerateT()
        {
            var sc = new StatCollection();
            sc.GenerateFromTemplates(statTemplates);
            return sc;
        }
    }
}
