using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParty : MonoBehaviour
{
    public List<Enemy> enemyParty;
    public GameObject EnemyPrefab;
    public List<Transform> spawnLocations;
    public static GameManager gm;
    public bool isBossLevel;

    void Start() {
        //Set this when level is selected/starts, not hardcoded to value
        gm = FindObjectOfType<GameManager>();
        if (isBossLevel){
            spawnBoss(gm);
        } else {
            spawnNormalEnemies(gm);
        }
    }

    void Update() {

    }

    void spawnBoss(GameManager gm){
        Enemy e = enemyParty[2];
        GameObject enemy = Instantiate(EnemyPrefab, spawnLocations[2].position, Quaternion.identity);
        enemy.GetComponent<EnemyDisplay>().enemy = e;
        enemy.GetComponent<EnemyDisplay>().generateAction();
        enemy.GetComponent<EnemyDisplay>().artwork.sprite = e.artwork;
        enemy.GetComponent<EnemyDisplay>().health.text = enemy.GetComponent<EnemyDisplay>().modifyEnemyHealth(e.baseHealth).ToString();
        enemy.GetComponent<EnemyDisplay>().defenseImage.sprite = e.defenseSprite;
        enemy.GetComponent<EnemyDisplay>().defenseAmount.text = e.defenseAmount.ToString();
        enemy.GetComponent<EnemyDisplay>().enemyName.text = e.enemyName.ToString();
        enemy.GetComponent<EnemyDisplay>().action.sprite = e.action;
        enemy.GetComponent<EnemyDisplay>().actionAmount.text = e.actionAmount.ToString();
        enemy.GetComponent<EnemyDisplay>().isBossLevel = isBossLevel;
        enemy.transform.SetParent(spawnLocations[2], false);
        enemy.transform.position = spawnLocations[2].position;
        gm.enemies.Add(enemy);
    }

    void spawnNormalEnemies(GameManager gm){

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
            enemy.GetComponent<EnemyDisplay>().enemy = e;
            enemy.GetComponent<EnemyDisplay>().generateAction();
            enemy.GetComponent<EnemyDisplay>().artwork.sprite = e.artwork;
            enemy.GetComponent<EnemyDisplay>().health.text = enemy.GetComponent<EnemyDisplay>().modifyEnemyHealth(e.baseHealth).ToString();
            enemy.GetComponent<EnemyDisplay>().defenseImage.sprite = e.defenseSprite;
            enemy.GetComponent<EnemyDisplay>().defenseAmount.text = e.defenseAmount.ToString();
            enemy.GetComponent<EnemyDisplay>().enemyName.text = e.enemyName.ToString();
            enemy.GetComponent<EnemyDisplay>().action.sprite = e.action;
            enemy.GetComponent<EnemyDisplay>().actionAmount.text = e.actionAmount.ToString();
            enemy.transform.SetParent(spawnLocations[spawn], false);
            enemy.transform.position = spawnLocations[spawn].position;
            gm.enemies.Add(enemy);
        }
    }

}
