using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DrawDeck : MonoBehaviour
{
    public CardScriptableObject card;
    public Card sceneCard;
    public List<CardScriptableObject> bingusbongus = new List<CardScriptableObject>();
    public List<CardScriptableObject> dingusdongus = new List<CardScriptableObject>();
    int pick = 0;
    int deck_Size;

    public void drawCard()
    {
        if (bingusbongus.Count == 0)
        {
            return;
        }
        dingusdongus.Add(card);
        card = bingusbongus[0];
        sceneCard.changeCard(card);
        bingusbongus.Remove(bingusbongus[0]);
    }

    public List<CardScriptableObject> shuffleDeck(List <CardScriptableObject> list)
    {
        List<CardScriptableObject> newbingusbongus = new List<CardScriptableObject>();
        deck_Size = list.Count;
        while (deck_Size > 0)
        {
            int pick = Random.Range(0, deck_Size);
            newbingusbongus.Add(bingusbongus[pick]);
            bingusbongus.Remove(bingusbongus[pick]);
            deck_Size--;
            deck_Size = list.Count;
        }
        bingusbongus = newbingusbongus;
        return bingusbongus;
    }



}

