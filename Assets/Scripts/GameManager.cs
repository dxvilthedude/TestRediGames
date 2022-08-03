using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] enemySpawnLocations;
    [SerializeField] private List<SpawnPoint> availablePoints;
    [SerializeField] private Score score;

    [SerializeField] private GameObject timers;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private EnemyManager enemyPool;
    [SerializeField] private GameObject enemiesList;
    [SerializeField] private Menu menu;

    private bool gameOn = false;

    void Start()
    {
        foreach (SpawnPoint point in enemySpawnLocations)
        {
            availablePoints.Add(point);
        }      
    }

    public void BeginGame()
    {
        gameOn = true;
        StartCoroutine(SpawnTimer());
        score.SetScoreVisuals();
    }
    public void EndGame()
    {
        menu.DeletePlayers();
        score.HideScoreVisuals();
        gameOn = false;
        StopAllCoroutines();
        
        timers.gameObject.SetActive(false);
        score.SetWinnerText();
        endScreen.SetActive(true);
        DestroyAllEnemies();
    }

    IEnumerator SpawnTimer()
    {
        while (gameOn)
        {        
            yield return new WaitForSeconds(2f);
            SpawnEnemy();
        }
    }


    private void SpawnEnemy()
    {
        if (availablePoints.Count <= 0)
            return;
        
        int randomPoint = Random.Range(0, availablePoints.Count -1);

        GameObject enemy = enemyPool.SpawnEnemyFromPool();
        enemy.transform.parent = enemiesList.transform;
        enemyPool.RemoveFromList(0);
        enemy.transform.position = availablePoints[randomPoint].spawnPosition;
        enemy.GetComponent<Enemy>().SetEnemy(availablePoints[randomPoint], this);
        
        availablePoints.RemoveAt(randomPoint);
    }

    public void ReleaseSpot(SpawnPoint point)
    {
        availablePoints.Add(point);
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform child in enemiesList.transform)
        {
            child.GetComponent<Enemy>().Death();
        }
    }
}
