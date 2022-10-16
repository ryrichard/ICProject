using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public struct Data
{
    public string name;
    public string ImageURL;
}

public class imageJSON : MonoBehaviour
{
    [SerializeField] GameObject slide;
    private Texture2D image;
    //private Texture2D [] images;
    //public GameObject[] slides;

    //private Sprite websprite;
    
    
    // URL to the Json file 
    string jsonURL = "https://drive.google.com/uc?export=download&id=1iWvScmDZXRw9W6Ri1qVhuCUuVCNnkL6D";

    void Start()
    {
        StartCoroutine(GetData(jsonURL));
    }

    //It gets the Json 
    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Network Connection error!");
        }
        else
        {
            Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text); //gets json file text
            Debug.Log(data.name);
            StartCoroutine(GetImage(data.ImageURL)); 
        }

        request.Dispose(); // it closes the url request 
    }

    //<Summary>
    //It gets the image from google drive and sets it to an object
    IEnumerator GetImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Network Connection error!");
        }
        else
        {
            image = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite websprite = CreateSpriteFromTexture(image);
            slide.GetComponent<Image>().sprite = websprite;
            Debug.Log("image successfully acquired!");
            //Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text);
            //Debug.Log(data.name);
            
        }

        request.Dispose();// it closes the url request 
    }

   Sprite CreateSpriteFromTexture (Texture2D texture) //creates a new sprite from a texture
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    /*
    void populateImages(Texture2D [] images, GameObject [] slides)
    {
        //StartCoroutine(GetData(jsonURL));

        for (int i = 0; i < images.Length; i++)
        {
            websprite = CreateSpriteFromTexture(images[i]);
            //images[i] = slides[i].GetComponent<Image>().sprite = websprite;
        }
    }*/



   
}
