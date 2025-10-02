using NUnit.Framework;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    CardScriptableObject[] deck;
    

    public Card card;
    public void cardDraw()
    {
        if (deck.Length > 0)
        {
            card.changeCard(deck[deck.Length - 1]);
            deck.
        }
    }
}
