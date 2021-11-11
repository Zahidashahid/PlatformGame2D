using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDontDestroy : MonoBehaviour
{
    public static MainMenuDontDestroy instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
