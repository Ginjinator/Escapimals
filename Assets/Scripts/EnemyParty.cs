using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParty : MonoBehaviour
{
    public Enemy[] enemyParty;
    public GameObject EnemyPrefab;
    public Transform[] spawnLocations;

    void Start() {

        foreach (Enemy e in enemyParty)
        {
            int randSpawnPoint = Random.Range(0, spawnLocations.Length);
            GameObject enemy = Instantiate(EnemyPrefab, spawnLocations[randSpawnPoint].position, Quaternion.identity);
            Debug.Log("Random Spawn Point:" + randSpawnPoint.ToString() + spawnLocations[randSpawnPoint].position);
            enemy.GetComponent<EnemyDisplay>().artwork.sprite = e.artwork;
            enemy.GetComponent<EnemyDisplay>().health.text = e.health.ToString();
            enemy.GetComponent<EnemyDisplay>().enemyName.text = e.enemyName.ToString();
            enemy.GetComponent<EnemyDisplay>().action.sprite = e.action;
            enemy.GetComponent<EnemyDisplay>().actionAmount.text = e.actionAmount.ToString();
            enemy.transform.SetParent(spawnLocations[randSpawnPoint], false);
            enemy.transform.position = spawnLocations[randSpawnPoint].position;
            Debug.Log("Enemy Position:" + enemy.transform.position);
            
        }
    }

    void Update() {

    }
}
