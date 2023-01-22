using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGoogleDrive;

public class GDriveFolder : MonoBehaviour
{
    private ExampleGetFileByPath fldr_pth_ID;
    private string folderID;
    private TestFilesList images;

    private GoogleDriveFiles.ListRequest request;//how we make requests to the google drive API
    private Dictionary<string, string> images_name_id; // this is where we store the name and id's of images
    private string query = ""; //the folders id???

    // Start is called before the first frame update
    void Start()
    {
        folderID = fldr_pth_ID.result;
        //images.folderID = folderID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ListFolderChildren(string nextPageToken = null)
    {
        request = GoogleDriveFiles.List();
        request.Fields = new List<string> { "files(name, id)" };
        request.OrderBy = ("name");
        request.Q = ($"mimeType = 'application/vnd.google-apps.folder' and name = '{folderID}'");

    }
}
