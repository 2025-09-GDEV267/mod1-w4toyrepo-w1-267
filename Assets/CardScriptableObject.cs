using UnityEngine;
[CreateAssetMenu(menuName = "Cards/Card")]
public class CardScriptableObject : ScriptableObject

{
    public string cardName;
    public string cardType;
    public int HP;
    public int ATK;
    public int SWN;
    public int CRT;
}
