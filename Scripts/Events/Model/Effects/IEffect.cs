namespace BumpySellotape.Events.Model.Effects
{
    public interface IEffect
    {
        void Process(ProcessingContext processingContext);

        string Label { get; }
    }
}

