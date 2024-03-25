using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Analytics : MonoBehaviour
{
    string URL = "https://docs.google.com/forms/d/e/1FAIpQLSfYqvkOq-JMVyZKIsPyyGUV7eEUoOIuyndzBir0wxA1opyAQw/formResponse";
    // https://docs.google.com/forms/u/2/d/e/1FAIpQLSfYqvkOq-JMVyZKIsPyyGUV7eEUoOIuyndzBir0wxA1opyAQw/formResponse?usp=pp_url&entry.760059763=DebugTest
    string[] information = new string[4];
    
    [Button]
    void DebugPost() {
        information[0] = "Debug";
        StartCoroutine(Post());
    }

    public void AddAnalyticData(string info, int slot) {
        if (slot > 0 && slot < information.Length) {
            information[slot] = info;
        }
    }

    public void Send() {
        StartCoroutine(Post());
    }

    IEnumerator Post() {

        WWWForm form = new WWWForm();
        form.AddField("entry.760059763", information[0]);
        
        // Add as needed
        //form.AddField("entry.", information[1]);
        //form.AddField("entry.", information[2]);
        //form.AddField("entry.", information[3]);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.LogError(www.error);
        } else {
            Debug.Log("Form upload complete!");
        }

    }

    IEnumerator GetRequest(string uri) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result) {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

}
