using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string animalName;
    //Light, medium, heavy, etc
    public ClassType playerClassType;

    public int totalEnergy;
    // Each animal will have it's own deck that get's shuffled together to form the main deck
    public List<Cards> deck = new List<Cards>();

    public Animal(string name)
    {
        animalName = name;
        // Possibly a function to determine what class type the animal is either in this contstructor or when this animal is add to the party and sent to this constructor
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
