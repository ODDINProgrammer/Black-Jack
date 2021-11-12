using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AI_hand ai;
    [SerializeField] private Player_hand player;
    [SerializeField] internal ButtonManager BM;
    [SerializeField] internal ScoreManager SM;

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
        CheckResults();
    }

    public void NewDeal()
    {
        ResetGame();

        BM.DisableDealButton();
        BM.ActivateKeepButton();
        BM.ActivateTakeButton();

        IEnumerator coroutine = DealAfter(0.05f);
        StartCoroutine(coroutine);
    }
    #endregion

    private void Awake()
    {
        SM.UpdateScoreText();
    }

    private void ResetGame()
    {
        //  REMOVE CARDS FROM AI
        foreach (Transform child in ai.ai_hand)
            GameObject.Destroy(child.gameObject);
        //  REMOVE CARDS FROM PLAYER
        foreach (Transform child in player.player_hand)
            GameObject.Destroy(child.gameObject);
        //  RESET TOTAL VALUE OF HANDS
        player.player_total = 0;
        ai.ai_total = 0;
    }

    //  IENUMERATORS
    #region
    private IEnumerator AI_take_card(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ai.AddCard();
        AI_turn();
    }

    private IEnumerator DealAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.FirstDeal();
        ai.Deal();
    }
    #endregion

    //  RESULT METHODS
    #region 
    internal void PlayerWin()
    {
        SM.AddToWinCount();

        BM.ActivateDealButton();
        BM.DisableKeepButton();
        BM.DisableTakeButton();
    }

    internal void PlayerLost()
    {
        SM.AddToLoseCount();

        BM.ActivateDealButton();
        BM.DisableKeepButton();
        BM.DisableTakeButton();
    }

    internal void Draw()
    {
        SM.AddToDrawCount();

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

        if (ai.ai_total == player.player_total)
            Draw();
    }
    #endregion
}
