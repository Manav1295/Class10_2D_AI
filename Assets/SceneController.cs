using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private GameObject carrotPrefab;
    [SerializeField] private GameObject plantEnemyPrefab;
    [SerializeField] private GameObject slugEnemyPrefab;
    [SerializeField] private GameObject beeEnemyPrefab;

    [SerializeField] private Transform[] starSpawnPt;
    [SerializeField] private Transform[] carrotSpawnPt;
    [SerializeField] private Transform[] plantEnemySpawnPt;
    [SerializeField] private Transform[] slugEnemySpawnPt;
    [SerializeField] private Transform[] beeEnemySpawnPt;

   

    // Start is called before the first frame update
    void Start()
    {
        spawnStars();
        spawnCarrots();
        spawnPlantEnemies();
        spawnslugEnemies();
        spawnbeeEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnStars()
    {
        foreach (Transform spawnPoint in starSpawnPt)
        {
            Instantiate(starPrefab, spawnPoint.position, Quaternion.identity);
        }
            
    }
    void spawnCarrots()
    {
        foreach (Transform spawnPoint in carrotSpawnPt)
        {
            Instantiate(carrotPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    void spawnPlantEnemies()
    {
        foreach (Transform spawnPoint in plantEnemySpawnPt)
        {
            Instantiate(plantEnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    void spawnslugEnemies()
    {
        foreach (Transform spawnPoint in slugEnemySpawnPt)
        {
            Instantiate(slugEnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    void spawnbeeEnemies()
    {
        foreach (Transform spawnPoint in beeEnemySpawnPt)
        {
            Instantiate(beeEnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
