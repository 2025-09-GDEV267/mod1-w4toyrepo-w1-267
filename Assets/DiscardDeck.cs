using UnityEngine;
using System.Collections.Generic;

public class DiscardDeck : MonoBehaviour
{
    public CardScriptableObject card;
    public Card sceneCard;
    List<CardScriptableObject> dingusdongus = new List<CardScriptableObject>();

    public void discardCard()
    {
        dingusdongus.Add(card);
        sceneCard.cardName.text = "Name";
        sceneCard.cardDesc.text = "Description";
        sceneCard.HP.text = "1";
        sceneCard.ATK.text = "1";
        sceneCard.SWN.text = "1";
        sceneCard.CRT.text = "1";
    }
}
