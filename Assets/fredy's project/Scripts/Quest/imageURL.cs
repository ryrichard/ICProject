using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class imageURL : MonoBehaviour
{
    public Image image;

    Texture2D mytexture;

    void Start()
    {
        StartCoroutine(DownloadImage("https://www.foodsafetynews.com/files/2022/04/cybersecurity.jpg"));  
    }

    
   IEnumerator DownloadImage(string mediaURL)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaURL); //gets the requested image from internet
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) //checks for conection errors
            Debug.Log(request.error);
        else
            mytexture = ((DownloadHandlerTexture)request.downloadHandler).texture; //assigns the requested image to object
            Sprite newSprite = Sprite.Create(mytexture, new Rect(0, 0, mytexture.width, mytexture.height), new Vector2(.5f, .5f));
            image.sprite = newSprite;

    }
}
