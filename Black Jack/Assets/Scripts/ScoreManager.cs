using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI drawText;
    [SerializeField] private TextMeshProUGUI loseText;

    private int winCount = 0;
    private int drawCount = 0;
    private int loseCount = 0;

    internal void AddToWinCount()
    {
        winCount++;
        UpdateScoreText();
    }

    internal void AddToLoseCount()
    {
        loseCount++;
        UpdateScoreText();
    }

    internal void AddToDrawCount()
    {
        drawCount++;
        UpdateScoreText();
    }
    internal void UpdateScoreText()
    {
        winText.SetText(winCount.ToString());
        drawText.SetText(drawCount.ToString());
        loseText.SetText(loseCount.ToString());
    }
}
