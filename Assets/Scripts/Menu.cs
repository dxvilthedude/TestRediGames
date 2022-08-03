using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabPlayers;
    [SerializeField][Range(1,4)] private int playersNumber = 1;
    [SerializeField] private GameObject[] playerVisuals;

    [SerializeField] private TMP_Text numberOfPlayers;
    [SerializeField] private GameObject Players;
    [SerializeField] private Score scoreMain;

    private void Start()
    {
        UpdateVisuals();
    }
    public void AddPlayer()
    {
        if (playersNumber < 4)
            playersNumber++;
        numberOfPlayers.text = playersNumber.ToString();
        UpdateVisuals();
    }
    public void RemovePlayer()
    {
        if(playersNumber > 1)
            playersNumber--;
        numberOfPlayers.text = playersNumber.ToString();
        UpdateVisuals();
    }

    void UpdateVisuals()
    {
        for (int i = 1; i < 4; i++)
        {
            if (i < playersNumber)
                playerVisuals[i].SetActive(true);
            else
                playerVisuals[i].SetActive(false);
        }
    }

    public void StartGame()
    {
        scoreMain.playersScoreScript = new List<PlayerScore>();
        for (int i = 0; i < playersNumber; i++)
        {
            var Player = Instantiate(prefabPlayers[i],Players.transform);
            var playerScore = Player.GetComponent<PlayerScore>();
            scoreMain.playersScoreScript.Add(playerScore);
            playerScore.score = scoreMain;
            playerScore.playerIndex = i;
        }
    }

    public void DeletePlayers()
    {
        foreach (Transform child in Players.transform)
            child.GetComponent<PlayerController>().OnGameEnd();
    }
}
