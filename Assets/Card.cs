using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardScriptableObject card;

    public TMP_Text cardName;
    public TMP_Text cardDesc;
    public TMP_Text HP;
    public TMP_Text ATK;
    public TMP_Text SWN;
    public TMP_Text CRT;


    public void changeCard(CardScriptableObject newCard)
    {
        card = newCard;
    }

    void updateCard()
    {
        cardName.text = card.cardName;
        cardDesc.text = card.cardDesc;
        HP.text = card.HP.ToString();
        ATK.text = card.ATK.ToString();
        SWN.text = card.SWN.ToString();
        CRT.text = card.CRT.ToString();
    }
}
