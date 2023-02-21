using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directions : MonoBehaviour
{
    public GameObject directions_window;

    public Text titleText;
    public Text description;

    public void OpenDirectionsWindow()
    {
        directions_window.SetActive(true);
    }

    public void CloseDirectionsWindow()
    {
        directions_window.SetActive(false);
    }
}
