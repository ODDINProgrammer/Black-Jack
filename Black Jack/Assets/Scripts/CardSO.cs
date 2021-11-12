using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardSO : ScriptableObject
{
    public enum Card_type { two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace };
    public Card_type type;
    public Sprite Sprite;
}
