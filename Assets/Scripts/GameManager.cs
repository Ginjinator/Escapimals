using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool[] availableCardSlots;
    public Transform[] cardSlots;
    public static GameManager Instance;

    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<Card> discardPile = new List<Card>();

    public Text deckSize;

    public void drawCard()
    {
        if (deck.Count == 0 && discardPile.Count >= 1 && hasEmptySlots())
        {
            deck.AddRange(discardPile);
            discardPile.Clear();
            shuffle();
        }
        if (deck.Count >= 1)
        {
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if(availableCardSlots[i] == true)
                {
                    var card = deck[0];
                    card.gameObject.SetActive(true);
                    card.handIndex = i;
                    card.hasBeenPlayed = false;
                    card.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(card);
                    hand.Add(card);
                    return;
                }
                
            }

        }
    }

    public bool hasEmptySlots()
    {
        for (int i = 0; i < availableCardSlots.Length; i++)
        {
            if(availableCardSlots[i] == true)
            {
                return true;
            }
        }
        return false;
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



    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deckSize.text = deck.Count.ToString();

        if (Input.GetKeyDown(KeyCode.D))
        {
            drawCard();
        }
    }
}
