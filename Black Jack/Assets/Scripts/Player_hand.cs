using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hand : MonoBehaviour
{
    [SerializeField] internal int player_total;
    [SerializeField] private RectTransform player_hand;
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

        newCard.PrepareCard();

        AddPlayerTotal(newCard.value);
    }

    internal void Deal()
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
