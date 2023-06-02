using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    //protected Singleton()
    //{
    //    Debug.Log(typeof(T).Name);
    //}
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

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}

