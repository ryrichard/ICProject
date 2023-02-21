using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accept : MonoBehaviour
{
    public GameObject window;

    public void close_window()
    {
        window.SetActive(false);
    }
}
