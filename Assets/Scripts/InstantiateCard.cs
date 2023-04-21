using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCard : MonoBehaviour
{
    Card card;
    
    // Start is called before the first frame update
    void Start()
    {
        card = (Card)ScriptableObject.CreateInstance(typeof(Card));

    }

}
