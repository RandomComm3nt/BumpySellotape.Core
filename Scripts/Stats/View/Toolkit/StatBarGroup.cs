using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace BumpySellotape.Core.Stats.View.Toolkit
{
    public class StatBarGroup : VisualElement
    {
        public StatBarGroup(StatCollection statCollection, List<StatType> statTypes)
        {
            foreach (var st in statTypes)
            {
                if (statCollection.GetStat(st, out var stat))
                    Add(new UiToolkitStatBar(stat));
            }
        }
    }
}
