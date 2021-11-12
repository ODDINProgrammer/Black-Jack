using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum Card_type { two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace };
    private Card_type type;

    private int value;
    [SerializeField] internal CardSO CardSO;
    [SerializeField] private GameManager GM;

    private void OnValidate()
    {
        SetCardValue();
    }

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void SetCardValue()
    {
        switch (type)
        {
            case Card_type.two:
                value = 2;
                break;
            case Card_type.three:
                value = 3;
                break;
            case Card_type.four:
                value = 4;
                break;
            case Card_type.five:
                value = 5;
                break;
            case Card_type.six:
                value = 6;
                break;
            case Card_type.seven:
                value = 7;
                break;
            case Card_type.eight:
                value = 8;
                break;
            case Card_type.nine:
                value = 9;
                break;
            case Card_type.ten:
                value = 10;
                break;
            case Card_type.jack:
                value = 10;
                break;
            case Card_type.queen:
                value = 10;
                break;
            case Card_type.king:
                value = 10;
                break;
            case Card_type.ace:
                value = 11;
                break;
        }
    }

    internal void PrepareCard()
    {
        type = (Card_type)CardSO.type;
        GetComponentInChildren<Image>().sprite = CardSO.Sprite;
        SetCardValue();
        GM.GetComponent<Player_hand>().AddPlayerTotal(value);
    }
}
