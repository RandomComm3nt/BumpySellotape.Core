using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace BumpySellotape.Core.Tagging
{
    [HideReferenceObjectPicker]
    public class TagList
    {
        [field: SerializeField, ValueDropdown("@GetPossibleTags()")]
        public List<int> Tags { get; private set; } = new List<int>();

        public bool Intersects(TagList l)
        {
            return Tags.Intersect(l.Tags).Count() > 0;
        }

        #if UNITY_EDITOR
        [NonSerialized] public string tagDictionaryName;
        [NonSerialized] public TagDictionary tagDictionary;

        private ValueDropdownList<int> GetPossibleTags()
        {
            var assets = AssetDatabase.FindAssets(tagDictionaryName);
            var dict = AssetDatabase.LoadAssetAtPath<TagDictionary>(AssetDatabase.GUIDToAssetPath(assets[0]));

            return dict.Tags;
        }
        #endif
    }
}

/* Example:

        [OnInspectorInit("@tagList.tagDictionaryName = \"New Tag Dictionary\"")]
        public TagList tagList = new TagList();

*/