using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;

public class HighScoreTable : MonoBehaviour
{
   [SerializeField] Modular3DText metresHS;
   [SerializeField] Modular3DText comboHS;

    public int scoreMetres;
    public int scoreCombos;

    PlayerScores playerScores;
    public static HighScoreTable instance;
    private void Awake()
    {
        #region
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion
        LoadHighScores();
    }
    public void SetScores(int metres,int combos)
    {
        if (metres > scoreMetres)
        {
            scoreMetres = metres;
        }
        if (combos > scoreCombos)
        {
            scoreCombos = combos;
        }
        UpdateHighScoreTable();
        SaveManager.SavePlayerScores(this);
    }
    public void LoadHighScores()
    {
        playerScores = SaveManager.LoadPlayerData();
        if (playerScores == null) return;
        else
        {
            scoreMetres = playerScores.score;
            scoreCombos = playerScores.combo;

            UpdateHighScoreTable();
        }
           
    }
    void UpdateHighScoreTable()
    {
        
        metresHS.UpdateText("Metres: " + scoreMetres);
        comboHS.UpdateText("Combo: " + scoreCombos);
    }
}

[System.Serializable]
public class PlayerScores
{
    public int score;
    public int combo;

    public PlayerScores(HighScoreTable scoreSys)
    {
        score = scoreSys.scoreMetres;
        combo = scoreSys.scoreCombos;
    }

}
