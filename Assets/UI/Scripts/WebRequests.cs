using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
public static class WebRequests
{
    private class WebRequestsMonoBehaviour : MonoBehaviour { }

    private static WebRequestsMonoBehaviour webRequestsMonoBehaviour;
    private static void Init()
    {
        if (webRequestsMonoBehaviour == null)
        {
            GameObject gameObject = new GameObject("WebRequests");
            webRequestsMonoBehaviour = gameObject.AddComponent<WebRequestsMonoBehaviour>();
        }
    }
    public static void Get(string url, Action<string> onError, Action<string> onSuccess)
    {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetCoroutine(url, onError, onSuccess));
    }
    private static IEnumerator GetCoroutine(string url, Action<string> onError, Action<string> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
            unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
            unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);//Error
            }
            else
            {
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }
    }
    public static void GetJson(string url, string jsonData, Action<string> onError, Action<string> onSuccess)
    {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetJsonCoroutine(url, jsonData, onError, onSuccess));
    }
    private static IEnumerator GetJsonCoroutine(string url, string jsonData, Action<string> onError, Action<string> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            unityWebRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
            unityWebRequest.SetRequestHeader("Content-Type", "application/json");
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
            unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
            unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);
            }
            else
            {
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }
    }
    public static void PostJson(string url, string jsonData, Action<string> onError, Action<string> onSuccess)
    {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetCoroutinePostJson(url, jsonData, onError, onSuccess));
    }
    private static IEnumerator GetCoroutinePostJson(string url, string jsonData, Action<string> onError, Action<string> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            unityWebRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            unityWebRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWebRequest.SetRequestHeader("Content-Type", "application/json");
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
            unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
            unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);
            }
            else
            {
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }
    }
    public static void PutJson(string url, string jsonData, Action<string> onError, Action<string> onSuccess)
    {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetCoroutinePutJson(url, jsonData, onError, onSuccess));
    }
    private static IEnumerator GetCoroutinePutJson(string url, string jsonData, Action<string> onError, Action<string> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Put(url, jsonData))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            unityWebRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            unityWebRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            unityWebRequest.SetRequestHeader("Content-Type", "application/json");
            yield return unityWebRequest.SendWebRequest();
            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
            unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
            unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);
            }
            else
            {
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }
    }

}


 /*   private static IEnumerator GetTextureCoroutine(string url, Action<string> onError, Action<Texture2D> onSuccess) {
        using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url)) {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
		    unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
		    unityWebRequest.result == UnityWebRequest.Result.ProtocolError) {
                onError(unityWebRequest.error);
            } else {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                onSuccess(downloadHandlerTexture.texture);
            }
        }
    }  
*/

/*public static void Post(string url, string postData, Action<string> onError, Action<string> onSuccess) {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetCoroutinePost(url, postData, onError, onSuccess));
    }*/
/*public static void Post(string url, Dictionary<string, string> formFields, Action<string> onSuccess) {
        Init();
        webRequestsMonoBehaviour.StartCoroutine(GetCoroutinePost(url, formFields, onError, onSuccess));
    }*/
/*    private static IEnumerator GetCoroutinePost(string url, string postData, Action<string> onError, Action<string> onSuccess) {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Post(url, postData)) {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
		    unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
		    unityWebRequest.result == UnityWebRequest.Result.ProtocolError) {
                onError(unityWebRequest.error);
            } else {
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }
    }*/
/*   private static IEnumerator GetCoroutinePost(string url, Dictionary<string, string> formFields, Action<string> onError, Action<string> onSuccess) {
       using (UnityWebRequest unityWebRequest = UnityWebRequest.Post(url, formFields)) {
           yield return unityWebRequest.SendWebRequest();

           if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
           unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
           unityWebRequest.result == UnityWebRequest.Result.ProtocolError) {
               onError(unityWebRequest.error);
           } else {
               onSuccess(unityWebRequest.downloadHandler.text);
           }
       }
   }*/