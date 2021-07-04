/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class HighscoreTable : MonoBehaviour {

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Update() {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreENtryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //if (ScoreAPIController.jsnData == null) {
        //    // There's no stored table, initialize
        //    Debug.Log("Initializing table with default values...");
        //    AddHighscoreEntry(1000000, "CMK");
        //    AddHighscoreEntry(897621, "JOE");
        //    AddHighscoreEntry(872931, "DAV");
        //    AddHighscoreEntry(785123, "CAT");
        //    // Reload
        //    jsonString = PlayerPrefs.GetString("highscoreTable");
        //    highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //}

        //// Sort entry list by Score
        //for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
        //    for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
        //        if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
        //            // Swap
        //            HighscoreEntry tmp = highscores.highscoreEntryList[i];
        //            highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
        //            highscores.highscoreEntryList[j] = tmp;
        //        }
        //    }
        //}

        if (ScoreAPIController.jsnData != null)
        {
            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry x in ScoreAPIController.jsnData.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(x, entryContainer, highscoreEntryTransformList);
            }
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
        default:
            rankString = rank + "TH"; break;

        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.username;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;
        
        // Highlight First
        if (rank == 1) {
            entryTransform.Find("PosText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("ScoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("NameText").GetComponent<Text>().color = Color.green;
        }

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, username = name };
        
        // Load saved Highscoresss
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
}
