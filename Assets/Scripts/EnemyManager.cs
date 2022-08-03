using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private Material phase1;
    [SerializeField] private Material phase2;
    [SerializeField] private Material phase3;
    [SerializeField] private Material phase4;
    public Material GetPhaseMaterial(int phase)
    {
        switch (phase)
        {
            case 1: return phase1;
            case 2: return phase2;
            case 3: return phase3;
            case 4: return phase4;        
        }
        return phase1;
    }
    void Start()
    {
        foreach (Transform child in transform)
        {
            enemies.Add(child.gameObject);
        }
    }

    public GameObject SpawnEnemyFromPool()
    {      
        return enemies[0];
    }
    public void RemoveFromList(int index)
    {
        enemies.RemoveAt(index);
    }
    public void AddToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }
}
