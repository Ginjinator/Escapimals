using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    public void generateAction(){
        var randomEffect = Random.Range(0, 2);
        Effect effect = effects[randomEffect];
        
        var amount = generateEnemyActionAmount();
        actionAmount = amount;
        switch(effect.name){
            case "defend":
                Debug.Log("Defense");
                action = defenseSprite;
                break;
            case "attack":
                Debug.Log("Attack");
                action = attackSprite;
                break;
            default:
                Debug.Log("You shouldn't see this!");
                break;
        }
    }

    //Maybe add variable for if enemy is boss or random chance for harder enemy
    public int modifyEnemyHealth(int baseHealth) {
        int modifier = Random.Range(0, 9);

        return baseHealth + modifier;
    }

    public int generateEnemyActionAmount(){
        int actionAmount = Random.Range(2, 6);

        return actionAmount;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        generateAction();
    }
}
