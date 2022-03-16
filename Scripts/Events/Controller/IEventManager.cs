using BumpySellotape.Events.Model.Effects;
using System;

namespace BumpySellotape.Events.Controller
{
    public interface IEventManager
    {
        ProcessingContext CreateProcessingContext();
        void SetSystemLink(object system);
        void SetSystemLink(Type t, object system);
        void AdvanceFrame();
        ProcessingContext ProcessEffect(IEffect effect);
    }
}
