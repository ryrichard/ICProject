using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] int sceneVal;

    public void OnPointerEnter()
    {
        //do something
    }

    public void OnPointerClick()
    {
        TeleportPlayer();
    }

    void TeleportPlayer()
    {
        if (sceneVal != 0)
            SceneManager.LoadScene(sceneVal);
        else
            Debug.Log("SceneVal should not equal 0"); //subject to change since, scene[0] should be the hub level
    }
}
