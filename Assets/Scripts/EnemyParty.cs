using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParty : MonoBehaviour
{
    public List<Enemy> enemyParty;
    public GameObject EnemyPrefab;
    public List<Transform> spawnLocations;

    void Start() {

        //Leaving in incase we want to spawn enemys in a different manner for reference (like randomly at spawn points instead of in every spawn point)

        //foreach (Enemy e in enemyParty)
        //{
        //    int randSpawnPoint = Random.Range(0, spawnLocations.Count);
        //    GameObject enemy = Instantiate(EnemyPrefab, spawnLocations[randSpawnPoint].position, Quaternion.identity);
        //    Debug.Log("Random Spawn Point:" + randSpawnPoint.ToString() + spawnLocations[randSpawnPoint].position);
        //    enemy.GetComponent<EnemyDisplay>().artwork.sprite = e.artwork;
        //    enemy.GetComponent<EnemyDisplay>().health.text = e.baseHealth.ToString();
        //    enemy.GetComponent<EnemyDisplay>().enemyName.text = e.enemyName.ToString();
        //    enemy.GetComponent<EnemyDisplay>().action.sprite = e.action;
        //    enemy.GetComponent<EnemyDisplay>().actionAmount.text = e.actionAmount.ToString();
        //    enemy.transform.SetParent(spawnLocations[randSpawnPoint], false);
        //    enemy.transform.position = spawnLocations[randSpawnPoint].position;
        //    Debug.Log("Enemy Position:" + enemy.transform.position);       
        //}

        for (var spawn = 0; spawn < spawnLocations.Count; spawn++)
        {
            int randomEnemy = Random.Range(0, enemyParty.Count);
            Enemy e = enemyParty[randomEnemy];
            GameObject enemy = Instantiate(EnemyPrefab, spawnLocations[spawn].position, Quaternion.identity);
            enemy.GetComponent<EnemyDisplay>().artwork.sprite = e.artwork;
            enemy.GetComponent<EnemyDisplay>().health.text = createEnemyHealth(e.baseHealth).ToString();
            enemy.GetComponent<EnemyDisplay>().enemyName.text = e.enemyName.ToString();
            enemy.GetComponent<EnemyDisplay>().action.sprite = e.action;
            enemy.GetComponent<EnemyDisplay>().actionAmount.text = e.actionAmount.ToString();
            enemy.transform.SetParent(spawnLocations[spawn], false);
            enemy.transform.position = spawnLocations[spawn].position;
        }
    }

    void Update() {

    }

    //Maybe add variable for if enemy is boss or random chance for harder enemy
    public int createEnemyHealth(int baseHealth) {
        int modifier = Random.Range(0, 9);

        return baseHealth + modifier;
    }
}
