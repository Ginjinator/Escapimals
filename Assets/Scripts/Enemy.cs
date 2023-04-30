using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;

    public Sprite artwork;
    public int baseHealth;

    //Attack and damamge or block amount
    public Sprite action;
    public int actionAmount;

}
