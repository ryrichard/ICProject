using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTrigger : MonoBehaviour
{
    [SerializeField] string SceneName;

    static int loadCount = 0;
    public void OnTriggerEnter(Collider other)
    {
        if(loadCount < 1)
        {
            loadCount ++;
            SceneManager.LoadScene(SceneName);
        }
    }
}
