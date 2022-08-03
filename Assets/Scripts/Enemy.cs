using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpawnPoint point;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private int phase;
    private bool isActive;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SetEnemy(SpawnPoint spawnPoint, GameManager manager)
    {
        point = spawnPoint;
        gameManager = manager;
        isActive = true;
        phase = 1;
        ActivateNewPhase(1);
        StartCoroutine(NextPhase());
    }

    private void ReleaseSpawnSpot()
    {
        point.ReleaseSpot();
        gameManager.ReleaseSpot(point);
    }
    IEnumerator NextPhase()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(2f);
            ChangePhase();
        }
    }
    

    private void ChangePhase()
    {      
        phase++;

        ActivateNewPhase(phase);       
    }

    private void ActivateNewPhase(int phase)
    {
        meshRenderer.material = enemyManager.GetPhaseMaterial(phase);

        switch (phase)
        {
            case 1:
                return;
            case 2:
                return;
            case 3:
                return;
            case 4:
                
                return;
            case 5:
                Death();
                return;
        }
    }

    public void Death()
    {
        phase = 1;
        ReleaseSpawnSpot();
        isActive = false;
        ReleaseToPool();
    }
    private void GivePoints(PlayerScore pScore)
    {
        pScore.AddPoints();
    }
    public void TakeDamage(PlayerScore pScore)
    {
        switch (phase)
        {
            case 2:
                Death();
                GivePoints(pScore);
                return;
            case 3:
                StopAllCoroutines();
                phase = 2;
                ActivateNewPhase(2);
                StartCoroutine(NextPhase());
                return;
        }
    }

    private void ReleaseToPool()
    {
        gameObject.transform.parent = enemyManager.transform;
        gameObject.transform.localPosition = Vector3.zero;
        enemyManager.AddToList(gameObject);
    }
}
