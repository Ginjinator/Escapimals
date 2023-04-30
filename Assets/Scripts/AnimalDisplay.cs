using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalDisplay : MonoBehaviour
{
   
    public Image artwork;
    public Text health;
    public Text defense;
    public int defenseValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        defense.text = defenseValue.ToString();
    }
}
