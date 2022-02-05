using BumpySellotape.Core.Input;

namespace BumpySellotape.Events.Controller
{
    public class CutsceneInputHandler : InputHandler<CutsceneManager>
    {
        private CutsceneManager controller;

        public override string ActionMap => "Cutscene";

        public override void Initialise(CutsceneManager controller)
        {
            this.controller = controller;
        }

        public void OnAdvanceText()
        {
            controller.OnAdvanceText();
        }
    }
}