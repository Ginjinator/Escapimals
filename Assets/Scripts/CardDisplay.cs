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
        nameText.text = card.name;
        descriptionText.text = card.description;
        manaText.text = card.manacost.ToString();
        artworkImage.sprite = card.artwork;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(hasBeenPlayed == false)
        {
            Debug.Log("Clicked Card");
            transform.position += Vector3.up * 10;
            hasBeenPlayed = true;
            Invoke("moveToDiscardPile", 2f);
        }
        
    }

    public void testClick()
    {
        Debug.Log("here i am");
    }

    public void moveToDiscardPile()
    {
        gameObject.SetActive(false);
        gm.discardPile.Add(this.gameObject);
        gm.hand.Remove(this.gameObject);
        Debug.Log("Card in Discard");
    }

}
