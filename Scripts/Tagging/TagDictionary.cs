using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace BumpySellotape.Core.Tagging
{
    [CreateAssetMenu(menuName = "Common/Tag Dictionary")]
    public class TagDictionary : SerializedScriptableObject
    {
        [field: OdinSerialize] 
        public ValueDropdownList<int> Tags { get; } = new ValueDropdownList<int>();
    }
}
