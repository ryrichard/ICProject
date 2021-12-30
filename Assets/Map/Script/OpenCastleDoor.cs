using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCastleDoor : MonoBehaviour
{
    [SerializeField] GameObject castleDoor;
    Vector3 castleDoorPos;

    float openDoorY = 4.5f;

    private void Awake()
    {
        castleDoor = this.gameObject;
        castleDoorPos = castleDoor.transform.position;
        CloseDoor();
    }

    public void OnPointerLook()
    {
        Debug.Log("Looking at a big a$$ door");
    }

    public void OnPointerClick()
    {
        OpenDoor();
    }

    void CloseDoor()
    {
        castleDoor.transform.position = new Vector3(castleDoorPos.x, castleDoorPos.y - openDoorY, castleDoorPos.z);
    }

    void OpenDoor()
    {
        castleDoor.transform.position = new Vector3(castleDoorPos.x, openDoorY, castleDoorPos.z);
    }
}
