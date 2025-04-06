using System.Collections.Generic;

namespace surus.util
{
    public class TypedDictionary
    {
        private readonly Dictionary<string, object> memory = new Dictionary<string, object>();
        private readonly Dictionary<string, System.Type> types = new Dictionary<string, System.Type>();

        public bool AllocateType(string key, System.Type type)
        {
            if (type == null)
                throw new System.ArgumentNullException(nameof(type));

            if (types.ContainsKey(key))
                throw new System.ArgumentException($"Type for key {key} has already been allocated");

            types[key] = type;
            return true;
        }

        public bool CanAssign(string key) => types.ContainsKey(key);

        public bool Put(string key, object value)
        {
            if (value == null)
                throw new System.ArgumentNullException(nameof(value));

            if (!CanAssign(key))
                throw new System.ArgumentException($"No type allocated for key {key}");

            if (types[key] != value.GetType())
                throw new System.ArgumentException($"Type of value {value.GetType()} does not match allocated type {types[key]} for key {key}");

            memory[key] = value;
            return true;
        }

        public T Get<T>(string key)
        {
            if (!CanAssign(key))
                throw new System.ArgumentException($"No type allocated for key {key}");

            if (types[key] != typeof(T))
                throw new System.ArgumentException($"Allocated type {types[key]} for key {key} does not match type {typeof(T)}");

            return memory.TryGetValue(key, out object result) ? (T)result : default(T);
        }

        public void DellocateType(string key)
        {
            if (!types.ContainsKey(key))
                throw new System.ArgumentException($"No type allocated for key {key}");

            types.Remove(key);
            memory.Remove(key);
        }

        public System.Type GetRequiredType(string key)
        {
            if (!types.ContainsKey(key))
                return null;

            return types[key];
        }
    }
}
