using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    DataController dc;

    [SerializeField] VoiceController vc;

    public GameObject player
    {
        private set;
        get;
    }

    //singleton - makes sure this data is the only one to exist in any scene
    private void Awake()
    {
        if (dc != null)
            Destroy(gameObject);
        else
        {
            dc = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
