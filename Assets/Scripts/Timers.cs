using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timers : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text gameTimeText;
    [SerializeField] private GameManager gameManager;
    private int countdownTimer = 3;
    private int gameTimer = 60;

    IEnumerator CountdownToStart()
    {
        while (countdownTimer > 0)
        {
            countdownText.text = countdownTimer.ToString();

            yield return new WaitForSeconds(1f);

            countdownTimer--;
        }

        countdownText.text = "START!!!";
        gameManager.BeginGame();

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        StartCoroutine(GameTimeCountdown());
    }

    IEnumerator GameTimeCountdown()
    {
        while (gameTimer > 5)
        {
            gameTimeText.text = gameTimer.ToString();

            yield return new WaitForSeconds(1f);

            gameTimer--;
        }

        while (gameTimer > 0)
        {
            gameTimeText.text = gameTimer.ToString() + " SECONDS LEFT!";
            yield return new WaitForSeconds(1f);
            gameTimer--;
        }

        gameTimeText.text = "TIME IS UP";
        yield return new WaitForSeconds(1f);
        gameTimeText.gameObject.SetActive(false);

        gameManager.EndGame();
        ResetTimers();
    }

    public void StartCountdown()
    {
        StartCoroutine(CountdownToStart());
    }

    public void ResetTimers()
    {
        countdownTimer = 3;
        gameTimer = 60;

        countdownText.gameObject.SetActive(true);
        gameTimeText.text = gameTimer.ToString();
        gameTimeText.gameObject.SetActive(true);
    }

}
