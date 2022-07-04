using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTrigger : MonoBehaviour
{
    [SerializeField] string SceneName;

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneName);
    }
}
