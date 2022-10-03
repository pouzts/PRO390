using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    // create a private static instance
    private static T instance;
    
    // get the instance of the component/object
    public static T Instance {
        get {
            // if the instance is null
            if (instance == null)
            { 
                // find the instance
                instance = FindObjectOfType<T>();

                // if the instance is still null
                if (instance == null)
                {
                    // create the game object
                    GameObject gameObject = new();
                    // set the game object's name to T's name
                    gameObject.name = typeof(T).Name;
                    // set the instance to the game object and add T's component to the game object
                    instance = gameObject.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    // when the game starts
    private void Awake()
    {
        // if the instance is null
        if (instance == null)
        {
            // set the instance to this as T
            instance = this as T;
            // don't destory this game object on load
            DontDestroyOnLoad(gameObject);
        }
        // else
        else 
        { 
            // destroy game object
            Destroy(gameObject);
        }
    }
}
