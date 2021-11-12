using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hand : MonoBehaviour
{
    [SerializeField] internal int player_total;
    [SerializeField] private Deck deck_access;

    public void AddCard()
    {
        //  PICK RANDOM CARD SETTING FROM DECK
        int rand = Random.Range(0, deck_access.deck.Count);
        //  INSTANTIATE A CARD
        Card newCard = Instantiate(deck_access.card_prefab, transform);
        //  ASSIGN SETTING
        newCard.CardSO = deck_access.deck[rand];
        //  MOVE TO PLAYER HAND 
        newCard.transform.position = transform.position;

        newCard.PrepareCard();
    }

    private void Awake()
    {
            
    }

    internal void AddPlayerTotal(int _value)
    {
        player_total += _value;
        if(player_total > 21)
        {
            Debug.Log("You lost");
        }
    }

    private bool isTooMuch()
    {
        if (player_total > 21)
            return true;

        return false;
    }
   
}
