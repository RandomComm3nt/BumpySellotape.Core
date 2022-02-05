using BumpySellotape.Core.References;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BumpySellotape.Events.Model.Effects.Text
{
    [HideReferenceObjectPicker]
    public class DisplayText
    {
        [SerializeField] private ReferenceToggle<DialogueActor> dialogueActorToggle = new ReferenceToggle<DialogueActor>();
        public DialogueActor DialogueActor => dialogueActorToggle.Object;

        [field: SerializeField, ReadOnly] public string Text { get; private set; }
        private bool expandText;
        [ShowInInspector, HideLabel, ShowIf(nameof(expandText)), TextArea(20, 30)] private string expandedText;

        private string ToggleExpandLabel => expandText ? "Save Changes" : "Edit";

        public DisplayText()
        { }

        public DisplayText(string text)
        {
            Text = text;
        }

        [Button(name: "$" + nameof(ToggleExpandLabel))]
        private void ToggleExpand()
        {
            if (expandText)
                Text = expandedText;
            else
                expandedText = Text;
            expandText = !expandText;
        }
    }
}
