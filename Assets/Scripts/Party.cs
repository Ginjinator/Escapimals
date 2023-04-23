using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Party : MonoBehaviour
{

    public List<Animal> party;
    public List<Card> partyDeck;
    public GameObject AnimalPrefab;
    // Start is called before the first frame update
    void Start()
    {
        float offset = 0;
        foreach (Animal a in party)
        {
            GameObject animal = Instantiate(AnimalPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            animal.GetComponent<AnimalDisplay>().artwork.sprite = a.artwork;
            animal.GetComponent<AnimalDisplay>().health.text = a.health.ToString();
            animal.transform.SetParent(this.transform, false);
            animal.transform.position += new Vector3(150.0f * offset, 0, 0);
            offset += 1;
            Debug.Log(a.starterDeck.cards.Count);
            foreach (Card c in a.starterDeck.cards)
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
