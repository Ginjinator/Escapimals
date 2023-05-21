using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyDisplay : MonoBehaviour
{

    public Image artwork;
    public Text health;
    public Text enemyName;
    public Image action;
    public Text actionAmount;
    public Enemy enemy;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }


    public void generateAction(){
        var randomEffect = Random.Range(0, 2);
        Effect effect = enemy.effects[randomEffect];
        
        var amount = generateEnemyActionAmount();
        actionAmount.text = amount.ToString();
        switch(effect.name){
            case "defend":
                Debug.Log("Defense");
                action.sprite = enemy.defenseSprite;
                break;
            case "attack":
                Debug.Log("Attack");
                action.sprite = enemy.attackSprite;
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

    public void test(){
        generateAction();
        Debug.Log("Click");
    }
}
