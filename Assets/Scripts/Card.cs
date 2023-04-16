using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public int energyCost;
    public string _name;

    public bool hasBeenPlayed;

    public int handIndex;

    private GameManager gm;

    private void OnMouseDown()
    {
        if(hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 1;
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            Invoke("moveToDiscardPile", 2f);
        }
    }

   void moveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gm.hand.Remove(this);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
