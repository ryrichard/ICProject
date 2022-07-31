using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testSceneChanger : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("Village");
    }
}
