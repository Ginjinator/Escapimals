using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class Animal : ScriptableObject
{
    public string animalName;
    //Light, medium, heavy, etc
    public string playerClassType;

    public int totalEnergy;
    // Each animal will have it's own deck that get's shuffled together to form the main deck
    public Deck starterDeck;


}
