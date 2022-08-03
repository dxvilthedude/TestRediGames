using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text[] playersScore;
    [SerializeField] private TMP_Text WinnerText;
    public List<PlayerScore> playersScoreScript;
    private int winnerIndex = 1;
    public void SetScoreVisuals()
    {
        for (int i = 0; i < playersScore.Length; i++)
        {
            playersScore[i].transform.parent.gameObject.SetActive(i < playersScoreScript.Count ? true : false);
        }
    }

    public void HideScoreVisuals()
    {
        foreach (var scoreVisual in playersScore)
        {
            scoreVisual.transform.parent.gameObject.SetActive(false);
        }
    }

    public void UpdatePoints(int playerIndex, int scorePoints)
    {
        playersScore[playerIndex].text = "SCORE: " + scorePoints.ToString();
    }

    public void SetWinnerText()
    {
        int score = 0;
        foreach (var player in playersScoreScript)
        {
            
            if (player.CurrentScore > score)
            {
                score = player.CurrentScore;
                winnerIndex = player.playerIndex + 1;
            }
        }

        
        WinnerText.text = score > 0 ? "Player " + winnerIndex + " won !!!" : "Youre all losers lol...";

    }
}
