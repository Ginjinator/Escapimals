using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text deckSize;
    public Transform start;
    public Deck startDeck;
    private double gap;

    public void drawCard()
    {
        if (deck.Count == 0 && discardPile.Count >= 1 && hand.Count <3)
        {
            deck.AddRange(discardPile);
            discardPile.Clear();
            shuffle();
        }
        if (deck.Count >= 1)
        {
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if(hand.Count < 3)
                {
                    var card = deck[0];
                    card.SetActive(true);
                    hand.Add(card);
                    deck.Remove(card);
                    card.GetComponent<CardDisplay>().hasBeenPlayed = false;
                    card.transform.position = start.position;
                    deckSize.text = deck.Count.ToString();
                    FitCards();
                    return;
                }
                
            }

        }
    }

    public void playCard()
    {
        

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
        gap = 1.0f;
        if(hand.Count == 0)
        {
            return;
        }

        for(int i = 0; i < hand.Count; i++)
        {
            GameObject obj = hand[i];
            obj.transform.position = start.position;
            obj.transform.position += new Vector3((float)(-i * 150.0f)+ 150.0f, 0, 0);
        }      
    }

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        int count = 1;
        foreach (Card i in startDeck.cards)
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
        deckSize.text = deck.Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
