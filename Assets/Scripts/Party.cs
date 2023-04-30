using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Party : MonoBehaviour
{

    public List<Animal> party;
    public List<Card> partyDeck;
    public GameObject AnimalPrefab;
    public List<AnimalDisplay> displays;
    // Start is called before the first frame update
    void Start()
    {
        float offset = 0;
        foreach (Animal a in party)
        {
            GameObject animal = Instantiate(AnimalPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            var animalDisplay = animal.GetComponent<AnimalDisplay>();
            animalDisplay.artwork.sprite = a.artwork;
            animalDisplay.defense.text = "0";
            animalDisplay.defenseValue = 0;
            animalDisplay.health.text = a.health.ToString();
            animal.transform.SetParent(this.transform, false);
            animal.transform.position += new Vector3(150.0f * offset, 0, 0);
            displays.Add(animalDisplay);
            offset -= 1;
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
