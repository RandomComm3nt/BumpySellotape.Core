using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace BumpySellotape.Core
{
    /// <summary>
    /// A wrapper around a Dictionary with Type keys, to allow attaching any class to another
    /// </summary>
    /// <typeparam name="TBase">A base class for all classes that should be attached</typeparam>
    [HideReferenceObjectPicker]
    public class SystemLinks<TBase>
    {
        [SerializeField, DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.Foldout)] 
        private Dictionary<Type, TBase> systems = new Dictionary<Type, TBase>();

        public List<TBase> Systems => systems.Values.ToList();

        public T GetSystemSafe<T>() where T : class
        {
            if (!systems.ContainsKey(typeof(T)))
                throw new Exception($"SystemLinks does not have system of type {typeof(TBase).Name}");
            if (!(systems[typeof(T)] is T))
                throw new Exception($"SystemLinks has an incorrectly registered system. Expected type: {typeof(TBase).Name}, actual type: {systems[typeof(TBase)].GetType().Name}");

            return systems[typeof(T)] as T;
        }

        public T GetSystemOrNull<T>() where T : class
        {
            if (!systems.ContainsKey(typeof(T)))
                return null;
            if (!(systems[typeof(T)] is T))
                throw new Exception($"SystemLinks has an incorrectly registered system. Expected type: {typeof(TBase).Name}, actual type: {systems[typeof(TBase)].GetType().Name}");

            return systems[typeof(T)] as T;
        }

        public IEnumerable<T> GetSystemsOfType<T>()
        {
            return systems
                .Values
                .Where(x => x is T)
                .Select(x => (T)(object)x);
        }

        [Button]
        public void RegisterSystem(TBase system)
        {
            systems[system.GetType()] = system;
        }

        public void RegisterSystem(Type t, TBase system)
        {
            Assert.IsTrue(t.IsAssignableFrom(system.GetType()));
            systems[t] = system;
        }

        public void CopyFrom(SystemLinks<TBase> systemLinks)
        {
            foreach (var s in systemLinks.systems)
                RegisterSystem(s.Key, s.Value);
        }
    }

    public class SystemLinks : SystemLinks<object>
    {
    }
}
