using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;

public class CoinSystem : MonoBehaviour
{
    
    [SerializeField] Modular3DText coins3DText;

    int totalBoxoins;
    
    public void AddBoxoins(int boxoinsToAdd)
    {
        totalBoxoins += boxoinsToAdd;
        UpdateBoxoinsText();
    }
    public void SpendBoxoins(int boxoinsToSpend)
    {
        totalBoxoins -= boxoinsToSpend;
        UpdateBoxoinsText();
    }

    private void UpdateBoxoinsText()
    {
        coins3DText.UpdateText(totalBoxoins + " bx");
    }
}
