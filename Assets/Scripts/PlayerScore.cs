using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Score score;
    public int playerIndex;
    private int currentScore = 0;
    public int CurrentScore => currentScore;

    public KeyCode key;

    private void Start()
    {
        score.UpdatePoints(playerIndex, currentScore);
    }
    public void AddPoints()
    {
        currentScore += 10;
        score.UpdatePoints(playerIndex, currentScore);
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
            AddPoints();
    }
}
