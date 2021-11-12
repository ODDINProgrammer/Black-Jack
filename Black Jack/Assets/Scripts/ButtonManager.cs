using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button Take;
    [SerializeField] private Button Keep;
    [SerializeField] private Button Deal;

    public void DisableTakeButton()
    {
        Take.interactable = false;
    }
    public void DisableKeepButton()
    {
        Keep.interactable = false;
    }
    public void DisableDealButton()
    {
        Deal.interactable = false;
    }

    public void ActivateTakeButton()
    {
        Take.interactable = true;
    }
    public void ActivateKeepButton()
    {
        Keep.interactable = true;
    }
    public void ActivateDealButton()
    {
        Deal.interactable = true;
    }
}
