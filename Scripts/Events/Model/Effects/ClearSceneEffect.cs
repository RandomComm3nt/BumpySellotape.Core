namespace BumpySellotape.Events.Model.Effects
{
    public class ClearSceneEffect : IEffect
    {
        public bool blah;

        string IEffect.Label => "Clear Scene";

        void IEffect.Process(ProcessingContext processingContext)
        {
            processingContext.GameController.ScreenManager.ClearScreen();
        }
    }
}
