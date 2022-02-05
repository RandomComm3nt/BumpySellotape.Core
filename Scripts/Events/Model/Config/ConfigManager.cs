using System;
using System.Collections.Generic;

namespace BumpySellotape.Events.Model.Config
{
    // singleton object for storing objects with a base class of ConfigBase
    // config files are keyed by type and only the latest file loaded of each type is stored
    public class ConfigManager
    {
        private Dictionary<Type, ConfigBase> configFiles = new Dictionary<Type, ConfigBase>();

        private static ConfigManager instance;
        public static ConfigManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConfigManager();
                return instance;
            }
        }

        public void LoadConfigFile(ConfigBase configBase)
        {
            configFiles[configBase.GetType()] = configBase;
        }

        public bool TryGetConfigFile<T>(out T configFile)
            where T : ConfigBase
        {
            if (configFiles.TryGetValue(typeof(T), out var configBase))
            {
                configFile = configBase as T;
                return true;
            }
            configFile = null;
            return false;
        }
    }
}
