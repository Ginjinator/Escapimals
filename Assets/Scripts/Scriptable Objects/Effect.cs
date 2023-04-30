using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effect")]
public class Effect : ScriptableObject
{
    public string effectDesciption;

    public string getDescription(int modifier)
    {
        return string.Format(effectDesciption,modifier) + " ";
    }
    public string target;
}
