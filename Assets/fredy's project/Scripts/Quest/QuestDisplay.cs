using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameObject.DontDestroyOnLoad(qd);
    }

    
}
