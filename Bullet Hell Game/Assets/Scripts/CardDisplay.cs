using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text cardNameText;
    public TMP_Text descText;

    public Image artworkImage;

    public TMP_Text cardCostText;
    public TMP_Text effectText;


    void Start()
    {
        cardNameText.text = card.cardName;
        descText.text = card.description;
        artworkImage.sprite = card.artwork;
        cardCostText.text = card.cardCost.ToString();;
        effectText.text = card.effect;

    }


}
