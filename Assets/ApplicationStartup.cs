using System;
using System.ComponentModel;
using System.Net;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ApplicationStartup : MonoBehaviour
{
    [SerializeField] private string[] urls;

    [SerializeField] private string objectName;
    
    [SerializeField] private ARTrackedImageManager _arTrackedImageManager;
    
    private int urlNumber = 0;
    private WebClient _webClient;
    private string _currentExtension;

    private TrackingController trackingController;
    void Start()
    { 
        trackingController = new TrackingController();
        StartDownloadFiles();
    }

    private void StartDownloadFiles()
    {
        _webClient = new WebClient();

        _webClient.DownloadProgressChanged += DownLoadProgressChanged;
        _webClient.DownloadFileCompleted += DownloadComplete;
        DownLoadFiles(urlNumber);
    }

    private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
        {
          Debug.Log("Завершена");
          if (_currentExtension == "png")
          {
              Debug.Log($"{objectName}" + $"{urlNumber-1}");
          }
        }
        else
        {
            Debug.Log("Error : " + e.Error);
        }

        if (urlNumber < urls.Length)
        {
            DownLoadFiles(urlNumber);
        }
        else
        {
            Texture2D Texture2D = Resources.Load<Texture2D>("Object0");
            trackingController.LoadToLibrary(_arTrackedImageManager,Texture2D);
        }
    }
    


    private void DownLoadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
       // Debug.Log("Download procces " + e.ProgressPercentage +"%");
    }

    private void DownLoadFiles(int number)
    {
       // UnityWebRequestTexture.GetTexture(urls[0]);
        var currentUrl = urls[number];

        int lastDotIndex = currentUrl.LastIndexOf('.');
        _currentExtension = currentUrl.Substring(lastDotIndex + 1);
        
        Debug.Log($"{objectName}" + $"{number}");

        string filePath = Application.dataPath + "/Resources" + $"/{objectName}" + $"{number}." + _currentExtension;

        _webClient.DownloadFileAsync(new Uri(urls[number]), filePath);
        
        urlNumber++;
    }
    
    /*
    public async UniTask<Texture2D> DownloadImageAsync(string uri, CancellationToken cancellationToken)
    {
        using var www = UnityWebRequestTexture.GetTexture(uri);
        
        await www.SendWebRequest().WithCancellation(cancellationToken);
        
        return www.result == UnityWebRequest.Result.Success ? DownloadHandlerTexture.GetContent(www) : null;
    }*/
}