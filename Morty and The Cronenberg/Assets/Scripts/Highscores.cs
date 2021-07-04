using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;

[Serializable]
public class Highscores
{
    public List<HighscoreEntry> highscoreEntryList;
    //public int score;
    //public string name;
}

/*
 * Represents a single High score entry
 * */
[Serializable]
public class HighscoreEntry
{
    public int score;
    public string username;
}