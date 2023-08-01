using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonDestroy<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                throw new UnityException($"Singleton instance of type {typeof(T).Name} is null.");
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<T>();
        //DontDestroyOnLoad(gameObject);

    }

}
