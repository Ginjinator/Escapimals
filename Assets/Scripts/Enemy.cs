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
    public Sprite attackSprite;
    public Sprite defenseSprite;
    public int actionAmount;
    public List<Effect> effects;
    public List<int> effectModifiers;
    public List<actionEffect> actionEffects;
    

    [System.Serializable]
    public struct actionEffect
    {
        public Effect eff;
        public int modifier;
        public int range;
        
    }

}
