using UnityEngine;

namespace GameLokal.Toolkit
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T) FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogWarning($"Multiple instances of {_instance.gameObject.name} detected in scene.");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        var singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = $"(Singleton) {typeof(T)}";

                        var component = _instance.GetComponent<Singleton<T>>();
                        component.OnCreate();

                        Debug.Log($"[Joyseed Core]Creating singleton of {typeof(T)}");
                    }
                }
                
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (ShouldNotDestroyOnLoad())
            {
                DontDestroyOnLoad(this);
            }

            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnCreate() { }
        protected virtual bool ShouldNotDestroyOnLoad() { return true; }
    }
}