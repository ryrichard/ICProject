using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Quest quest;
    
    public Player player;
    /*
    private void Awake()
    {
        if (player != null && player != this)
        {
            Destroy(gameObject);
        }
        else
            player = this;
    }
    */
    private void Start()
    {
        //GameObject.DontDestroyOnLoad(player);

        player = FindObjectOfType<Player>();
        player.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -0.9f, 0);


    }

}
