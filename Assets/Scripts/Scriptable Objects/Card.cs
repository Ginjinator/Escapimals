using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName="Card/Generic Card")]
public class Card : ScriptableObject
{
    public new string name;
    public Sprite artwork;
    public int manacost;
    public string description;
    public Animal owner;
    public List<Effect> effects;
    public List<int> effectModifiers;
    public List<cardEffect> cardEffects;
    public bool isUpgraded;
    

    [System.Serializable]
    public struct cardEffect
    {
        public Effect eff;
        public int modifier;
        public int range;

        public string getDescription(bool packLead)
        {
            var mod = packLead ? (int)modifier * 2 : modifier;
            return eff.getDescription(mod);
        }

        
    }
}
