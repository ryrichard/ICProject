using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkmark : MonoBehaviour
{


    public Button buttonComponent;
    public RawImage icon;

    public Sprite currentImage;
    public Sprite waitingImage;
    public Sprite doneImage;



    public Text description;
    public Text hint;

    public QuestEvent thisEvent;

    QuestEvent.EventStatus status;

    private void Awake()
    {
        //finds the button when app starts 
        buttonComponent.onClick.AddListener(ClickHandler);
    }


    public void SetUp (QuestEvent e, GameObject background)
    {
        thisEvent = e;
        buttonComponent.transform.SetParent(background.transform, false);
        description.text = thisEvent.description;
        hint.text = thisEvent.stepTitle;
        status = thisEvent.status;
        icon.texture = waitingImage.texture;
        buttonComponent.interactable = false;
        //Debug.Log(status);
        //Debug.Log(hint);
        

    }

    public void UpdateImage(QuestEvent.EventStatus s)
    {
        status = s;

        if(status == QuestEvent.EventStatus.done)
        {
            icon.texture = doneImage.texture;
            buttonComponent.interactable = false;
        }
        else if (status == QuestEvent.EventStatus.wating)
        {
            icon.texture = waitingImage.texture;
            buttonComponent.interactable = false;
        }
        else if(status == QuestEvent.EventStatus.current)
        {
            icon.texture = currentImage.texture;
            buttonComponent.interactable = true;
        }
    }

    public void ClickHandler()
    {

    }

}
