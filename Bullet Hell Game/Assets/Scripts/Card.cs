using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite artwork;

    public int cardCost;
    public string effect;

    public void Print() 
    {
        Debug.Log(cardName + description + cardCost);
    }
}
