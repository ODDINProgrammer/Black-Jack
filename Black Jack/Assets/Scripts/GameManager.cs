using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AI_hand ai;
    [SerializeField] private Player_hand player;
    [SerializeField] internal ButtonManager BM;

    private bool isFirstGame = true;

    //  PUBLIC METHODS
    #region
    public void AI_turn()
    {
        //  DISPLAY HIDDEN CARD
        ai.RevealCard();
        //  TAKE CARD IF DEALER HAS LESS THAN PLAYER
        if (ai.ai_total < player.player_total)
        {
            IEnumerator corutine = AI_take_card(1f);
            StartCoroutine(corutine);
        }
        //  EVALUATE RESULTS
        else
        {
            CheckResults();
        }
    }

    public void NewDeal()
    {
        //  RESET GAME
        if (!isFirstGame)
            SceneManager.LoadScene(0);

        if (isFirstGame)
            isFirstGame = false;

        BM.DisableDealButton();
        BM.ActivateKeepButton();
        BM.ActivateTakeButton();

        player.Deal();
        ai.Deal();
    }
    #endregion

    //  IENUMERATORS
    #region
    private IEnumerator AI_take_card(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ai.AddCard();
        AI_turn();
    }
    #endregion

    //  RESULT METHODS
    #region 
    internal void PlayerWin()
    {
        Debug.Log("You won!");
        BM.ActivateDealButton();
        BM.DisableKeepButton();
        BM.DisableTakeButton();
    }

    internal void PlayerLost()
    {
        Debug.Log("You lost!");
        BM.ActivateDealButton();
        BM.DisableKeepButton();
        BM.DisableTakeButton();
    }

    internal void Draw()
    {
        Debug.Log("Draw!");
        BM.ActivateDealButton();
        BM.DisableKeepButton();
        BM.DisableTakeButton();
    }

    private void CheckResults()
    {
        if (ai.ai_total == 21 && player.player_total == 21)
            Draw();
        if (ai.ai_total > 21)
            PlayerWin();
        if (ai.ai_total > player.player_total && ai.ai_total <= 21)
            PlayerLost();
    }
    #endregion
}
