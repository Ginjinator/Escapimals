using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, ENDTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    public bool[] availableCardSlots;
    public Transform[] cardSlots;
    public static GameManager Instance;
    public GameObject handDisplay;
    public GameObject cardPrefab;
    public Transform[] clickable;
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public Text deckSize;
    public Transform start;
    public List<Card> partyDeck;
    public Party party;
    private double gap;
    public BattleState state;

    public void drawCard(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            if (deck.Count == 0 && discardPile.Count >= 1 && hand.Count < 3)
            {
                deck.AddRange(discardPile);
                discardPile.Clear();
                shuffle();
            }
            if (deck.Count >= 1)
            {
                if (hand.Count < 3)
                {
                    var card = deck[0];
                    card.SetActive(true);
                    hand.Add(card);
                    deck.Remove(card);
                    card.GetComponent<CardDisplay>().hasBeenPlayed = false;
                    card.transform.position = start.position;
                    deckSize.text = deck.Count.ToString();
                    FitCards();
                }
                else
                {
                    Debug.Log("Reached Max Hand Size");
                }
            }
        }
    }

 

    public void shuffle()
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            var k = Random.Range(0, i);
            var val = deck[k];
            deck[k] = deck[i];
            deck[i] = val;
        }
    }

    public void FitCards()
    {
        gap = 150.0f;
        if(hand.Count == 0)
        {
            return;
        }

        for(int i = 0; i < hand.Count; i++)
        {
            GameObject obj = hand[i];
            obj.transform.position = start.position;
            obj.transform.position += new Vector3((float)(-i * gap)+ 150.0f, 0, 0);
        }      
    }


    public void resolveEffects(Card card, bool packLead)
    {
        for (int i = 0; i < card.cardEffects.Count; i++)
        {
            var effect = card.cardEffects[i];
            int modifier = packLead && !card.cardEffects[i].eff.name.Contains("draw") ? (int)effect.modifier * 2 : effect.modifier;
            Debug.Log(effect.eff.name + " " + modifier.ToString());
            switch (effect.eff.name)
            {
                case "damage-target":
                    party.displays[0].defenseValue -= modifier;
                    break;
                case "damage-all":
                    foreach (AnimalDisplay a in party.displays)
                    {
                        a.defenseValue -= modifier;
                    }
                    break;
                case "block-target":
                    party.displays[0].defenseValue += modifier;
                    break;
                case "block-all":
                    foreach (AnimalDisplay a in party.displays)
                    {
                        a.defenseValue += modifier;
                    }
                    break;
                case "draw":
                    drawCard(modifier);
                    break;
                default:
                    break;
            }
        }


    }

    public void discardHand()
    {
        var size = hand.Count - 1;
        for (int i = size; i >= 0; i--)
        {
            var discard = hand[i];
            discardPile.Add(discard);
            hand.Remove(discard);
            discard.SetActive(false);
        }
    }

    public void endTurn()
    {
        if(state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            enemyTurn();
        }
        else if(state == BattleState.ENDTURN)
        {
            // discard hand
            discardHand();
            // draw new hand
            drawCard(3);
            // set to player's turn
            state = BattleState.PLAYERTURN;
        }
    }

    public void battleStart()
    {
        int count = 1;
        partyDeck = party.partyDeck;
        foreach (Card i in partyDeck)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newCard.GetComponent<CardDisplay>().card = i;
            newCard.GetComponent<CardDisplay>().load();
            newCard.name = "Card" + count.ToString();
            newCard.transform.SetParent(start.transform, false);
            count++;
            deck.Add(newCard);
        }
        shuffle();
        drawCard(3);
        deckSize.text = deck.Count.ToString();
        state = BattleState.PLAYERTURN;
    }

    public void enemyTurn()
    {
        foreach (GameObject enemy in enemies)
        {
            party.displays[0].defenseValue -= int.Parse(enemy.GetComponent<EnemyDisplay>().actionAmount.text);
        }
        state = BattleState.ENDTURN;
        endTurn();
    }

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        battleStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
