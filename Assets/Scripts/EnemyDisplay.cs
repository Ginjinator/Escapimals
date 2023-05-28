using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyDisplay : MonoBehaviour
{

    public Image artwork;
    public Text health;
    public Image defenseImage;
    public Text defenseAmount;
    public Text enemyName;
    public Image action;
    public Image specialAction1;
    public Text actionAmount;
    public Enemy enemy;
    public GameManager gm;
    public bool isBossLevel;

    // Start is called before the first frame update
    void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }


    public void generateAction(){
        Effect effect;
        var amount = 0;
        if(isBossLevel){
            var randomEffect = Random.Range(0, 3);
            effect = enemy.effects[randomEffect];
        
            amount = generateBossActionAmount();
        } else {
            var randomEffect = Random.Range(0, 2);
            effect = enemy.effects[randomEffect];
        
            amount = generateEnemyActionAmount();
        }
        actionAmount.text = amount.ToString();
        switch(effect.name){
            case "enemy-defend":
                Debug.Log("Defend");
                action.sprite = enemy.defenseSprite;
                break;
            case "enemy-attack":
                Debug.Log("Attack");
                action.sprite = enemy.attackSprite;
                break;
            case "special-action-1":
                Debug.Log("Special Move 1");
                action.sprite = enemy.specialSprite1;
                break;
            default:
                Debug.Log("You shouldn't see this!");
                break;
        }
        enemy.currentEffect = effect;
    }

    //Maybe add variable for random chance for harder enemy
    public int modifyEnemyHealth(int baseHealth) {
        int modifier = Random.Range(0, 9);

        return baseHealth + modifier;
    }

    public int generateEnemyActionAmount(){
        int actionAmount = Random.Range(2, 6);

        return actionAmount;
    }

    //public void generateBossAction(){
    //    var randomEffect = Random.Range(0, 3);
    //    Effect effect = enemy.effects[randomEffect];
    //    
    //    var amount = generateBossActionAmount();
    //    actionAmount.text = amount.ToString();
    //    switch(effect.name){
    //        case "enemy-defend":
    //            Debug.Log("Defend");
    //            action.sprite = enemy.defenseSprite;
    //            break;
    //        case "enemy-attack":
    //            Debug.Log("Attack");
    //            action.sprite = enemy.attackSprite;
    //            break;
    //        default:
    //            Debug.Log("You shouldn't see this!");
    //            break;
    //    }
    //    enemy.currentEffect = effect;
    //}
//
    public int generateBossActionAmount(){
        int actionAmount = Random.Range(10, 20);

        return actionAmount;
    }

    public void endTurn(){
        resolveEnemyEffects();
        generateAction();
    }

    public void resolveEnemyEffects(){
        switch (enemy.currentEffect.name){
            case "enemy-defend":
                //Currently just replaces does not add to existing, can add to existing if we want
                var amount = int.Parse(actionAmount.text);
                defenseAmount.text = amount.ToString();
                break;
            case "enemy-attack":
                Debug.Log("You've been attacked");
                break;
            case "special-action-1":
                Debug.Log("Special Move!");
                var newAmount = int.Parse(actionAmount.text);
                var currentDefense = int.Parse(defenseAmount.text);
                newAmount = currentDefense + (newAmount/2);
                defenseAmount.text = newAmount.ToString();
                break;
            default:
                Debug.Log("Uh oh.");
                break;
        }
    }
}
