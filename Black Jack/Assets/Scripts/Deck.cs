using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] internal List<CardSO> deck;
    [SerializeField] internal Card card_prefab;
}
