using BumpySellotape.Events.Model.Effects;
using System;
using UnityEngine;

namespace BumpySellotape.Events.Model.Config
{
    public class LoadConfigEffect : IEffect
    {
        [SerializeField] private ConfigBase configFile = default;

        string IEffect.Label => throw new NotImplementedException();

        void IEffect.Process(ProcessingContext processingContext)
        {
            ConfigManager.Instance.LoadConfigFile(configFile);
        }
    }
}
