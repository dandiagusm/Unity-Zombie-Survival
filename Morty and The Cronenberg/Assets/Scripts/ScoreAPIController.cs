using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ScoreAPIController : MonoBehaviour
{
    public static Highscores jsnData;

    void Start()
    {
        // A correct website page. a
        StartCoroutine(GetRequest("http://134.209.97.218:5051/scoreboards/13517077"));
    }

    IEnumerator GetRequest(string uri)
    {

        WWW _www = new WWW(uri);
        yield return _www;
        if(_www.error == null)
        {
            processData(_www.text);
        } else
        {
            Debug.Log("error");
        }
    }

    private void processData (string _url)
    {
        string jsonString = "{\"highscoreEntryList\":" + _url + "}";
        jsnData = JsonUtility.FromJson<Highscores>(jsonString);
 
        foreach (HighscoreEntry x in jsnData.highscoreEntryList)
        {
            Debug.Log(x.username);
        }
    } 
}