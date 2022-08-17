using UnityEngine;

public class OpenCastleDoor : MonoBehaviour
{
    [SerializeField] GameObject castleDoor;
    Vector3 castleDoorPos;

    bool isOpen = false;

    float openDoorY = 5.0f;

    public GameObject telepad;

    //public DialogBox db;

    
    private void Awake()
    {
        castleDoor = this.gameObject;
        castleDoorPos = castleDoor.transform.position;
        castleDoor.GetComponent<BoxCollider>().enabled = true;
        
        //CloseDoor();
    }
    private void Update()
    {
        //castleDoor.GetComponent<OpenCastleDoor>().enabled = false;
        ActivateTelepad();
    }

    public void OnPointerLook()
    {
        Debug.Log("Looking at a big a$$ door");
    }

    public void OnPointerClick()
    {
        OnPointerLook();
        if (isOpen == false)
        {
            OpenDoor();
            isOpen = true;
        }
        else
        {
            CloseDoor();
            isOpen = false;
        }
            
    }

    void CloseDoor()
    {
        //moves object in world postion
        castleDoor.transform.position = new Vector3(castleDoorPos.x, castleDoorPos.y, castleDoorPos.z);
        //updates local position
        //castleDoorPos = new Vector3(castleDoorPos.x, castleDoorPos.y, castleDoorPos.z);

    }

    void OpenDoor()
    {
        //moves object in world position
        castleDoor.transform.position = new Vector3(castleDoorPos.x, openDoorY, castleDoorPos.z);
        //updates local potition
        //castleDoorPos = new Vector3(castleDoorPos.x, openDoorY, castleDoorPos.z);

    }

    void ActivateTelepad()
    {
        if (isOpen)
            telepad.SetActive(true);
        else
            telepad.SetActive(false);
    }
}
