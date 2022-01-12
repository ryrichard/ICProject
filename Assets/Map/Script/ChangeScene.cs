using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string SceneName;

    public void OnPointerEnter()
    {
        //do something
    }

    public void OnPointerClick()
    {
        MoveToNewScene();
    }

    void MoveToNewScene()
    {
        DataController.GetPlayerLastPosAndScene();
        SceneManager.LoadScene(SceneName);
    }
}
