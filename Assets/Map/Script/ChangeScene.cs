using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string SceneName;
    public string EnterMessage;

    private QuestEvent qe;

    public void OnPointerEnter()
    {
        Debug.Log(EnterMessage);
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

    private void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnsceneLoaded;
    }

    void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        
        
    }

    public void OnTriggerEnter(Collider other)
    {
        MoveToNewScene();
    }


}
