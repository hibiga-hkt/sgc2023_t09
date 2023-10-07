using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance { get { return instance != null ? instance : instance = GameObject.FindObjectOfType<T>(); } }
}
