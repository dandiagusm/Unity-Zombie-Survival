using UnityEngine;
using UnityEngine.UI;

public class ScoreIndicator : MonoBehaviour
{

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("STATUS INDICATOR: No score text object referenced!");
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score = " + score;
    }

}
