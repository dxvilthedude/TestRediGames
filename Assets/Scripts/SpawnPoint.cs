using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3 spawnPosition;
    [SerializeField] private bool isBusy;
    
    void Start()
    {
        spawnPosition = new Vector3(transform.position.x, 1, transform.position.z);
        isBusy = false;
    }

    public void PlaceEnemy()
    {
        isBusy = true;
    }

    public void ReleaseSpot()
    {
        isBusy = false;
    }
}
