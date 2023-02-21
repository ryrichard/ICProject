using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class imageURL : MonoBehaviour
{
    //public Image image;

    //Texture2D mytexture;

    [SerializeField] private Image image;
    
    private void Start()
    {
        /*StartCoroutine(DownloadImage("https://www.foodsafetynews.com/files/2022/04/cybersecurity.jpg"));
        string url = "";
        Get(url, (string error) => {
            //error
            Debug.Log("Error " + error);
        }, (string text)=> {
            //successfully contacted URL
            Debug.Log("Received: " + text);
        });*/

        string url = "https://www.foodsafetynews.com/files/2022/04/cybersecurity.jpg";
        GetTexture(url, (string error) => {
            //error
            Debug.Log("Error " + error);
        }, (Texture2D texture2D) => {
            //successfully contacted URL
            //Debug.Log("Received: " + text);
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(.5f, .5f), 10);
            image.sprite = sprite;
        });
    }

    /*
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

    }*/

   
    private void Get(string url, Action<string> onError, Action<string> onSuccess)
    {
        StartCoroutine(GetCoroutine(url, onError,onSuccess));
    }

    private IEnumerator GetCoroutine(string url, Action<string> onError, Action<string> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError){
                onError(unityWebRequest.error);
                //Debug.Log("Error " + unityWebRequest.error);
            }else{
                //Debug.Log("Received: " + unityWebRequest.downloadHandler.text);
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }

    }

    private void GetTexture(string url, Action<string> onError, Action<Texture2D> onSuccess)
    {
        StartCoroutine(GetTextureCoroutine(url, onError, onSuccess));
    }

    private IEnumerator GetTextureCoroutine(string url, Action<string> onError, Action<Texture2D> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                onError(unityWebRequest.error);
                //Debug.Log("Error " + unityWebRequest.error);
            }
            else
            {
                //Debug.Log("Received: " + unityWebRequest.downloadHandler.text);
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                onSuccess(downloadHandlerTexture.texture );
            }
        }

    }


}
