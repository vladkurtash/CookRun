using UnityEngine;

namespace CookRun.Model
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    T[] assets = Resources.LoadAll<T>("Config");
                    if (assets == null || assets.Length < 1)
                    {
                        Debug.LogError($"{typeof(T)}: assets Length is less than one.");
                        return null;
                    }
                    else if (assets.Length > 1)
                    {
                        Debug.LogWarning($"{typeof(T)}: Multiple instances is found in the Recources. Returned first found.");
                    }

                    _instance = assets[0];
                }

                return _instance;
            }
        }
    }
}