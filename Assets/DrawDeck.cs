using UnityEngine;
using System.Collections.Generic;

public class DrawDeck : MonoBehaviour
{
    public CardScriptableObject card;
    public CardScriptableObject bosch;
    List<CardScriptableObject> bingusbongus = new List<CardScriptableObject>();

    public void drawCard()
    {
        card = bingusbongus[0];
        Card.changeCard(card);
        bingusbongus.Remove(bingusbongus[0]);
    }
}
