using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrabAndDrop : MonoBehaviour
{
    //box where items are dropped
    public GameObject item;
    

   
    private bool isMoving;
    private bool isCorrectPlace = false;
    

    //private Vector3 OriginPos;
    private Vector3 screenPoint;
    private Vector3 startPos;

    
    // Start is called before the first frame update
    void Start()
    {
        //OriginPos = item.GetComponent<Transform>().position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            Debug.Log("Dragging");
            //GetComponent<Renderer>().material.color = Color.blue;


            Vector3 curScreenPointer = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPointer);
            this.transform.position = curPosition;

        }

        
    }

    public void OnPointerDown()
    {
        Debug.Log("Pointer Down");
        startPos = this.gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        isMoving = true;

    }

    public void OnPointerUp()
    {
        Debug.Log("Pointer up");
        isMoving = false;

        if (isCorrectPlace == true)
        {
            ScoreSystem.scoreValue += 1;
            Destroy(gameObject);
        }
        else if (isCorrectPlace == false)
        {
            this.gameObject.transform.position = startPos;
            ScoreSystem.scoreValue -= 1;
        }   
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AllowedBox" && item.gameObject.tag == "Allowed")
        {
            isCorrectPlace = true;

        }
        else if (collision.gameObject.tag == "ContrabandBox" && item.gameObject.tag == "Contraband")
        {

            isCorrectPlace = true;
           
        }
        else
        {
            isCorrectPlace = false;
        }

    }


}
