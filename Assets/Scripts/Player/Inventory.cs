using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    int _currentTreasure;

    [SerializeField] TMP_Text treasureUpdate;

    public void Start()
    {
        _currentTreasure = 0;
        treasureUpdate.text = "Treasure: " + _currentTreasure;
    }
    public void TreasureIncrease(int amount)
    {
        _currentTreasure += amount;
        treasureUpdate.text = "Treasure: " + _currentTreasure;
    }
}
