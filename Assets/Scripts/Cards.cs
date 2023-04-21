using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    

    public bool hasBeenPlayed;

    public int handIndex;


    private GameManager gm;

    public Card card;

    private void OnMouseDown()
    {
        Debug.Log(gm.cardSlots[handIndex].gameObject.name);
        
        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 1;
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            Invoke("moveToDiscardPile", 1f);
            gm.cardSlots[handIndex].gameObject.GetComponent<CardDisplay>().moveToDiscardPile();
        }

    }

    public void testClick()
    {
        Debug.Log(gm.cardSlots[handIndex].gameObject.name);

        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 1;
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            Invoke("moveToDiscardPile", 1f);
            gm.cardSlots[handIndex].gameObject.GetComponent<CardDisplay>().moveToDiscardPile();
        }
    }

   void moveToDiscardPile()
    {
        //gm.discardPile.Add(this);
        //gm.hand.Remove(this);
        //gameObject.SetActive(false);
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
