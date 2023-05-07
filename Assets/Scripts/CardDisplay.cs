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
    public Image owner;
    public static GameManager gm;
    private bool packLead;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void load()
    {
        gm = FindObjectOfType<GameManager>();
        nameText.text = card.name;
        
        manaText.text = card.name;
        artworkImage.sprite = card.artwork;
        owner.sprite = card.owner.artwork;
        packLead = gm.party.isPackLeader(card);
        string tempDescription = "";
        for (int i = 0; i < card.cardEffects.Count; i++)
        {
            tempDescription += card.cardEffects[i].getDescription(packLead && !card.cardEffects[i].eff.name.Contains("draw"));
        }
        descriptionText.text = tempDescription;
    }


    private void Update()
    {
        manaText.text = card.manacost.ToString();
        nameText.text = card.name;
        string tempDescription = "";
        for (int i = 0; i < card.cardEffects.Count; i++)
        {
            tempDescription += card.cardEffects[i].getDescription(packLead && !card.cardEffects[i].eff.name.Contains("draw"));
        }
        descriptionText.text = tempDescription;
        
        artworkImage.sprite = card.artwork;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(gm.state == BattleState.PLAYERTURN)
        {
            playCard();
        }
    }

    public void OnMouseEnter()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void OnMouseExit()
    {

        transform.localScale = new Vector2(1.0f, 1.0f);
    }


    public void playCard()
    {
        if(hasBeenPlayed == false)
        {
            Debug.Log("Clicked Card");
            transform.position += Vector3.up * 150;
            hasBeenPlayed = true;
            gm.discardPile.Add(this.gameObject);
            gm.hand.Remove(this.gameObject);
            gm.resolveEffects(card, packLead);
            gm.FitCards();
            Invoke("moveToDiscardPile", 2f);
        }
    }


    public void moveToDiscardPile()
    {
        gameObject.SetActive(false);
        Debug.Log("Card in Discard");
    }

}
