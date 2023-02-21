using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSessionInstance : MonoBehaviour
{
    public static ARSessionInstance Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
