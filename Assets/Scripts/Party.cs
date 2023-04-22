using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Party : MonoBehaviour
{

    public List<Animal> party;
    public List<Card> partyDeck;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Animal a in party)
        {
            foreach(Card c in a.starterDeck.cards)
            {
                c.owner = a;
            }
            partyDeck.AddRange(a.starterDeck.cards);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isPackLeader(Card c)
    {
        return party[0] == c.owner;
    }
}
