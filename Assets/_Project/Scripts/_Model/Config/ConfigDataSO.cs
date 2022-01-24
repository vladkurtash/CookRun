using UnityEngine;

namespace CookRun.Model
{
    public class ConfigDataSO<T> : SingletonScriptableObject<ConfigDataSO<T>>
        where T : IConfigData
    {
        [SerializeField] private T _data;

        public ConfigDataSO(T data)
        {
            _data = data;
        }

        public T Data => _data;
    }

    public interface IConfigData
    { }
}