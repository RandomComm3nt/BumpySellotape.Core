using BumpySellotape.Core.Stats.Controller;
using BumpySellotape.Core.Stats.Model;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace BumpySellotape.Core.Stats.View
{
    public class StatList : SerializedMonoBehaviour
    {
        [SerializeField] private Dictionary<StatType, StatDisplay> displayMapping = new Dictionary<StatType, StatDisplay>();

        public void Initialise(StatCollection statCollection)
        {
            displayMapping.ForEach(kvp =>
            {
                if (statCollection.GetStat(kvp.Key, out Stat s))
                    kvp.Value.Initialise(s);
                else
                    kvp.Value.gameObject.SetActive(false);
            });
        }
    }
}
