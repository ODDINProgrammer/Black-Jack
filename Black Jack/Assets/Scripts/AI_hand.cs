using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_hand : MonoBehaviour
{
    [SerializeField] internal int ai_total;
    [SerializeField] internal RectTransform ai_hand;
    [SerializeField] private Deck deck_access;
    [SerializeField] private Sprite card_backface;

    public void AddCard()
    {
        //  PICK RANDOM CARD SETTING FROM DECK
        int rand = Random.Range(0, deck_access.deck.Count);
        //  INSTANTIATE A CARD
        Card newCard = Instantiate(deck_access.card_prefab, ai_hand);
        //  ASSIGN SETTING
        newCard.CardSO = deck_access.deck[rand];
        //  MOVE TO PLAYER HAND 
        newCard.transform.position = ai_hand.position;
        //  SET CARD VALUES 
        newCard.PrepareCard();
        //  IF DEALT CARD IS ACE AND TOTAL VALUE WILL BE LARGER THAN 21, SET ACE VALUE TO 1
        if (newCard.CardSO.type == CardSO.Card_type.ace && ai_total + newCard.value > 21)
            newCard.value = 1;

        AddAITotal(newCard.value);
    }

    public void RevealCard()
    {
        ai_hand.GetChild(1).GetComponent<Card>().GetComponentInChildren<Image>().sprite = ai_hand.GetChild(1).GetComponent<Card>().CardSO.Sprite;
    }

    internal void Deal()
    {
        AddCard();
        AddCard();
        HideSecondCard();
    }

    private void AddAITotal(int _value)
    {
        ai_total += _value;
    }

    private void HideSecondCard()
    {
        ai_hand.GetChild(1).GetComponent<Card>().GetComponentInChildren<Image>().sprite = card_backface;
    }
}
