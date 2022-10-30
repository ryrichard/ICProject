using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuestDisplay : MonoBehaviour
{
   
    public static QuestDisplay qd
    {
        private set;
        get;
    }
    private void Awake()
    {
        if (qd != null && qd != this)
        {
            Destroy(gameObject);
        }
        else
            qd = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Museum"))
        {
            Destroy(qd);
        }
        else
        {
            GameObject.DontDestroyOnLoad(qd);
        }
        
    }

    
}
