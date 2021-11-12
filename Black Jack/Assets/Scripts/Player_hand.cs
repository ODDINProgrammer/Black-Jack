using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hand : MonoBehaviour
{
    [SerializeField] internal int player_total;
    [SerializeField] internal RectTransform player_hand;
    [SerializeField] private Deck deck_access;
    [SerializeField] private GameManager GM;

    public void AddCard()
    {
        //  PICK RANDOM CARD SETTING FROM DECK
        int rand = Random.Range(0, deck_access.deck.Count);
        //  INSTANTIATE A CARD
        Card newCard = Instantiate(deck_access.card_prefab, player_hand);
        //  ASSIGN SETTING
        newCard.CardSO = deck_access.deck[rand];
        //  MOVE TO PLAYER HAND 
        newCard.transform.position = player_hand.position;
        //  SET CARD VALUES 
        newCard.PrepareCard();
        //  IF DEALT CARD IS ACE AND TOTAL VALUE WILL BE LARGER THAN 21, SET ACE VALUE TO 1
        if (newCard.CardSO.type == CardSO.Card_type.ace && player_total + newCard.value > 21)
            newCard.value = 1;

        AddPlayerTotal(newCard.value);
    }

    internal void FirstDeal()
    {
        //  DEAL TWO CARDS
        AddCard();
        AddCard();
        //  CHECK IF 21 WAS DEALT 
        //  IF 21 WAS DEALT COUNT PLAYER WIN
        if (player_total == 21)
            GM.PlayerWin();
    }

    internal void AddPlayerTotal(int _value)
    {
        player_total += _value;
        if (player_total > 21)
            GM.PlayerLost();

        if (player_total == 21)
            GM.PlayerWin();
    }
}
