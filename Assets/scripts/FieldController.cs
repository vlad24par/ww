using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    private List<Sell> _fieldCells = new List<Sell>();

    public void AddSell(Sell sell)
    {
        _fieldCells.Add(sell);
    }

    public void StartGame()
    {
        
    }
}