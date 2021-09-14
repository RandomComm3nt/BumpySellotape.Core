using BumpySellotape.Core.Traits.Controller;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BumpySellotape.Core.Traits.Model
{
    [HideReferenceObjectPicker]
    public class TraitCollectionGenerationData : Generator<TraitCollection>
    {
        [SerializeField] private List<TraitGenerationData> traitGenerationData = new();

        public List<Trait> GenerateTraits()
        {
            return traitGenerationData
                .Where(t => Random.value * 100 < t.chanceToGenerate)
                .Select(t => new Trait(t.traitType))
                .ToList();
        }

        public override TraitCollection GenerateT()
        {
            var tc = new TraitCollection();
            tc.Traits.AddRange(GenerateTraits());
            return tc;
        }

        //public object Generate() => IGenerator < TraitCollection > .Generate();

        [HideReferenceObjectPicker]
        private class TraitGenerationData
        {
            [Required] public TraitType traitType;
            [SuffixLabel("%"), Range(0f, 100f)] public float chanceToGenerate = 100f;
        }
    }
}
