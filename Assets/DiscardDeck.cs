using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DiscardDeck : MonoBehaviour
{
    public CardScriptableObject card;
    public Card sceneCard;
    public List<CardScriptableObject> dingusdongus = new List<CardScriptableObject>();
    public List<CardScriptableObject> bingusbongus = new List<CardScriptableObject>();
    int pick = 0;
    int deck_Size;

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

    public void restoreDrawDeck()
    {
        bingusbongus.AddRange(dingusdongus);
        dingusdongus = new List<CardScriptableObject>();
    }

    public List<CardScriptableObject> shuffleDiscardDeck(List<CardScriptableObject> list)
    {
        List<CardScriptableObject> newdingusdongus = new List<CardScriptableObject>();
        deck_Size = list.Count;
        while (deck_Size > 0)
        {
            int pick = Random.Range(0, deck_Size);
            newdingusdongus.Add(dingusdongus[pick]);
            dingusdongus.Remove(dingusdongus[pick]);
            deck_Size--;
            deck_Size = list.Count;
        }
        dingusdongus = newdingusdongus;
        return dingusdongus;
    }
}
