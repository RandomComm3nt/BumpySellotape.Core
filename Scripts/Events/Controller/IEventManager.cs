using BumpySellotape.Events.Model.Effects;
using BumpySellotape.Events.Model.Nodes;
using System;

namespace BumpySellotape.Events.Controller
{
    public interface IEventManager
    {
        ProcessingContext CreateProcessingContext();
        void ProcessEventNode(EventNode eventNode);
        void SetSystemLink(object system);
        void SetSystemLink(Type t, object system);
        void AdvanceFrame();
    }
}
