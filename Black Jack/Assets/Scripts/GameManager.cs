using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AI_hand ai;
    [SerializeField] private Player_hand player;

    public void AI_turn()
    {
        //  DISPLAY HIDDEN CARD
        ai.RevealCard();
        //  TAKE CARD
        if (ai.ai_total <= player.player_total)
        {
            IEnumerator turn = AI_take_card(1f);
            StartCoroutine(turn);
        }
    }

    private IEnumerator AI_take_card(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ai.AddCard();
        AI_turn();
    }
}
