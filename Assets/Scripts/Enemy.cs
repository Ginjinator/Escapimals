using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;

    public Sprite artwork;
    public int health;

    //Attack and damamge or block amount
    public Sprite action;
    public int actionAmount;

    public void Awake()
    {
        var randomHealth = Random.Range(0, 12);
        //Try to set random stats at start
        //health = randomHealth;
    }
}
