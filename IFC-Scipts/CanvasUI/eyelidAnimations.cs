using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class eyelidAnimations : MonoBehaviour
{
    [SerializeField] Image upperEyelid;
    [SerializeField] Image downEyelid;
    
    [Header("PlayerComponentes")]
    [SerializeField] ParticleSystem[] dieParts;
    [Header("ButtonToStartGame")]
    [SerializeField] GameObject Button;
    [SerializeField] Transform buttonHold;
    public bool eyesClosed = false;

    [Header("ClosingEyelidPositions")]
    [SerializeField] float upperLidYclose;
    [SerializeField] float downLidYclose;
    [Header("OpeningEyelidPositions")]
    [SerializeField] float upperLidYopen;
    [SerializeField] float downLidYopen;
    [Header("ClosingEyelidTime")]
    [SerializeField] float upperLidTime;
    [SerializeField] float downLidTime;

    ScoreText scoreText;
    Spawner[] spawners;
    LvlDifficulty lvldiffScript;
    CannonManager cannonManager;
    PlayerHP playerHP;
    private void Start()
    {
        //Getting all needed referencess
        lvldiffScript = FindObjectOfType<LvlDifficulty>();
        spawners = FindObjectsOfType<Spawner>();
        scoreText = FindObjectOfType<ScoreText>();
        cannonManager = FindObjectOfType<CannonManager>();
        playerHP = FindObjectOfType<PlayerHP>();
        buttonHold = GameObject.FindGameObjectWithTag("ButtonHolder").transform;
        //Get Eyelid Open position
        upperLidYopen = upperEyelid.transform.localPosition.y;
        downLidYopen = downEyelid.transform.localPosition.y;
    }
    void KnockOutParticles()
    {
        foreach (ParticleSystem diePart in dieParts)
        {
            diePart.Play();
        }
    }
    void CloseEyes()
    {

        upperEyelid.transform.DOLocalMoveY(upperLidYclose, upperLidTime).SetEase(Ease.InCubic);
        downEyelid.transform.DOLocalMoveY(downLidYclose, downLidTime).SetEase(Ease.InCubic).OnComplete(() =>
        {
            eyesClosed = true;
        Invoke("CallEyelidAnimation", 1f);
        ResetGame();
        });
        StartGame.instance.StopRunning();//<-Deja de moverse el mapa (Te quedas quieto) 
    }
    void OpenEyes()
    {
        upperEyelid.transform.DOLocalMoveY(upperLidYopen, upperLidTime).SetEase(Ease.InCubic);
        downEyelid.transform.DOLocalMoveY(downLidYopen, downLidTime).SetEase(Ease.InCubic).OnComplete(() =>
        {
            eyesClosed = false;
        });
    }
    
    public void CallEyelidAnimation()
    {
        if (!eyesClosed)
        {
            Invoke("KnockOutParticles", 0.15f);
            CloseEyes();
        }
        else if (eyesClosed)
        {
            OpenEyes();
        }
    }

    private void ResetGame()//Resetea los parametros para volver a empezar otra partida
    {
        AllDecorationReset.instance.ResetRunDecoration();//<-Reset all the spawned decoration
        PlayerRepos.instance.ResetPosition();//<-Te devuelve al punto de inicio
        HighScoreTable.instance.SetScores(Mathf.RoundToInt(scoreText.runMetres), GetHigherScore.instance.higherComboInRun);

        scoreText.ReStartGame();//<----------Para el contador y lo pone a 0
        GetHigherScore.instance.ResetHigherComboInRun(); //<-Resetea la variable HigherCombo


        ResetObstacules();            //<----Desactiva todos los obstaculos spawneados
        lvldiffScript.ResetNewSpeed();//<----Resetea la variable de aumentar la velocidad
        cannonManager.ResetCannon();//<----Desactivan el cañon
        playerHP.ResetHp();//<---------------Devuelve la vida al player
        //Spawn BotonDeBoxeo
        if (!FindObjectOfType<ButtonDissolve>())//Si no hay un botton 
        {
            Instantiate(Button, buttonHold, false);//Lo spawnea
        }
       
    }
    void ResetObstacules()//Desactiva obstaculos Spawneados
    {
        foreach(Spawner spawner in spawners)
        {
            spawner.DeleteObstacules();
        }
    }
}
