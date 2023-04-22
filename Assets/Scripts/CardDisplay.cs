using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IPointerClickHandler
{
    public Card card;
    public Image artworkImage;
    public Text nameText;
    public Text descriptionText;
    public Text manaText;
    public bool hasBeenPlayed;
    public int handIndex;
    public static GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        manaText.text = card.manacost.ToString();
        artworkImage.sprite = card.artwork;
        gm = FindObjectOfType<GameManager>();
    }
    public void load()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        manaText.text = card.manacost.ToString();
        artworkImage.sprite = card.artwork;
        gm = FindObjectOfType<GameManager>();
    }

    void updateCard(Card newCard)
    {
        card = newCard;
        nameText.text = card.name;
        descriptionText.text = card.description;
        manaText.text = card.manacost.ToString();
        artworkImage.sprite = card.artwork;
    }

    private void Update()
    {
        if (gm.party.isPackLeader(card))
        {
            manaText.text = (2 * card.manacost).ToString();
        }
        else
        {
            manaText.text = card.manacost.ToString();
        }
        nameText.text = card.name;
        descriptionText.text = card.description;
        
        artworkImage.sprite = card.artwork;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(hasBeenPlayed == false)
        {
            Debug.Log("Clicked Card");
            transform.position += Vector3.up * 150;
            hasBeenPlayed = true;
            gm.discardPile.Add(this.gameObject);
            gm.hand.Remove(this.gameObject);
            gm.FitCards();
            Invoke("moveToDiscardPile", 1f);
        }
        
    }

    public void OnMouseEnter()
    {
        Debug.Log("Hovering");
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void OnMouseExit()
    {
        Debug.Log("Dropping");
        transform.localScale = new Vector2(1.0f, 1.0f);
    }



    public void moveToDiscardPile()
    {
        gameObject.SetActive(false);
        Debug.Log("Card in Discard");
    }

}
