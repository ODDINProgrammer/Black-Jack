using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_hand : MonoBehaviour
{
    [SerializeField] internal int ai_total;
    [SerializeField] private RectTransform ai_hand;
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

        newCard.PrepareCard();

        AddAITotal(newCard.value);
    }

    public void RevealCard()
    {
        ai_hand.GetChild(1).GetComponent<Card>().GetComponentInChildren<Image>().sprite = ai_hand.GetChild(1).GetComponent<Card>().CardSO.Sprite;
    }

    private void Awake()
    {
        AddCard();
        AddCard();
        HideSecondCard();
    }

    private void AddAITotal(int _value)
    {
        ai_total += _value;
        if (ai_total > 21)
        {
            Debug.Log("You lost");
        }
    }

    private void HideSecondCard()
    {
        ai_hand.GetChild(1).GetComponent<Card>().GetComponentInChildren<Image>().sprite = card_backface;
    }
}
