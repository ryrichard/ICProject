using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGoogleDrive;

public class GDrive : MonoBehaviour
{

    private GoogleDriveFiles.ListRequest list_request;
    private GoogleDriveFiles.GetRequest request_get;
    [SerializeField]public Dictionary<string, string> results;
    private string query = string.Empty;
    public int ResultsPerPage = 100;
    private string fileId = string.Empty;
    private string result;

    // Start is called before the first frame update
    void Start()
    {
        //var downloadRequest = new GoogleDriveFiles.DownloadRequest("1d6qRTsme_ybQhNWujhYM_DBQdllBy-ZK");
        //ListFiles();
        //filePath = "1d6qRTsme_ybQhNWujhYM_DBQdllBy-ZK";
        FolderFile("1d6qRTsme_ybQhNWujhYM_DBQdllBy-ZK");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ListFiles(string nextPageToken = null)
    {
        list_request = GoogleDriveFiles.List();
        list_request.Fields = new List<string> { "nextPageToken, files(id, name, size, createdTime)" };
        list_request.PageSize = ResultsPerPage;
        if (!string.IsNullOrEmpty(query)) {
            list_request.Q = string.Format("name contains '{0}'", query);
            Debug.Log("first if");
        }
            
        if (!string.IsNullOrEmpty(nextPageToken))
        {
            list_request.PageToken = nextPageToken;
            Debug.Log("second if");

        }
            
        list_request.Send().OnDone += BuildResults;
    }

    private void BuildResults(UnityGoogleDrive.Data.FileList fileList)
    {

        Debug.Log("BuildResults");

        results = new Dictionary<string, string>();

        foreach (var file in fileList.Files)
        {
            var fileInfo = string.Format("Name: {0} Size: {1:0.00}MB Created: {2:dd.MM.yyyy}",
                file.Name,
                file.Size * .000001f,
                file.CreatedTime);
            results.Add(file.Id, fileInfo);
            Debug.Log("Adding to dictionary ...");
        }

        foreach(var file in results )
        {
            Debug.Log("results:" + results);
            Debug.Log("listing...");
     
        }

  
    }

    private void FolderFile (string fileId)
    {
        request_get = GoogleDriveFiles.Get(fileId);
        list_request.Fields = new List<string> { "name, size, createdTime" };
        //request_get.Send().OnDone += BuildResultString;
    }

    private void BuildResultString(UnityGoogleDrive.Data.FileList filelist)
    {
        results = new Dictionary<string, string>();

        foreach(var file in filelist.Files)
        {
            result = string.Format("Name: {0} Size: {1:0.00}MB Created: {2:dd.MM.yyyy HH:MM:ss}",
               file.Name,
               file.Size * .000001f,
               file.CreatedTime);
        }

       
    }
}
