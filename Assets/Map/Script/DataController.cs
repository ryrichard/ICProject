using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DataController : MonoBehaviour
{
    public static DataController dc
    {
        private set;
        get;
    }

    public static VoiceController vc
    {
        private set;
        get;
    }

    [SerializeField] public static GameObject player
    {
        private set;
        get;
    }

    static Dictionary<string, Vector3> lastSceneAndPos = new Dictionary<string, Vector3>(); //records players last position in x scene

    [SerializeField] PhysicsRaycaster pr;

    //singleton - makes sure this data is the only one to exist in any scene
    private void Awake()
    {
        if (dc != null && dc != this)
            Destroy(gameObject);
        else
        {
            dc = this;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pr = player.GetComponentInChildren<PhysicsRaycaster>();
        TeleportPlayer(SceneManager.GetActiveScene().name);

        pr.enabled = false; //there seems to be some problen with the XR Cardboard Reticle when using it too soon. So the quick fix is to disable the raycaster for a bit
        Invoke("EnablePhysicsRaycast", 2.0f);
    }

    static public void GetPlayerLastPosAndScene() //get players position old scene before going to new scene
    {
        string lastScene = SceneManager.GetActiveScene().name;
        Vector3 pos = DataController.player.transform.position;

        if (lastSceneAndPos.ContainsKey(lastScene)) //if the player has already visited the old scene, update pos
            lastSceneAndPos[lastScene] = pos;
        else
            lastSceneAndPos.Add(lastScene, pos); //else record both old scene and pos
    }

    void TeleportPlayer(string currScene)
    {
        if (lastSceneAndPos.ContainsKey(currScene)) //returns last pos of player if the scene has been visited before
        {
            player.transform.position = lastSceneAndPos[currScene];
        }
    }

    private void EnablePhysicsRaycast()
    {
        pr.enabled = true;
    }
}
