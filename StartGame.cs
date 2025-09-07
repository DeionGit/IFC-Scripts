using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    ScoreText scoreTextScript;
    EnviromentMoving[] enviMoveScripts;

    public CannonManager cannonManager;
    static public StartGame instance;
    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion

    }
    void Start()
    {
        cannonManager = FindObjectOfType<CannonManager>();
        enviMoveScripts = FindObjectsOfType<EnviromentMoving>();
        scoreTextScript = FindObjectOfType<ScoreText>();
    }

   public void StartingRun()
    {
        scoreTextScript.start = true;
        cannonManager.StartCannonGame();
        foreach (EnviromentMoving enviMove in enviMoveScripts)
        {
            enviMove.gameStart = true;
        }
    }
    public void StopRunning()
    {
        foreach(EnviromentMoving enviMove in enviMoveScripts)
        {
            enviMove.speed = 0;
        }
    }
}
