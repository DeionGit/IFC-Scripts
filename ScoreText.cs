using System.Collections;
using UnityEngine;
using MText;

public class ScoreText : MonoBehaviour
{
    public float runMetres;
    [SerializeField] int pointPerUpdate;
    [SerializeField] Modular3DText MetresText3D;
    public bool start = false;
    bool controlLvlProgres;


    LvlDifficulty lvlDifficulty;
    void Start()
    {
        lvlDifficulty = FindObjectOfType<LvlDifficulty>();
        MetresText3D = GetComponent<Modular3DText>();
        MetresText3D.Text = "Runned Metres: " + 0;
    }

    
    void Update()
    {
        AddingMetres();
    }
    void AddingMetres()
    {
        if (start)
        {
            runMetres += pointPerUpdate * Time.deltaTime;
        }
        SetUpInText();
    }
    void SetUpInText()
    {
        int score;
        score = Mathf.FloorToInt(runMetres);
        CheckLvlProgres(score);
        MetresText3D.Text = "Runned Metres: " + score;
    }

    void CheckLvlProgres(int score)
    {
        if (score % 150==0 && score!=0 && !controlLvlProgres)
        {
            lvlDifficulty.SetNewSpeedToMap();
            StartCoroutine(OnlyOneSpeedUp());
        }
    }

    IEnumerator OnlyOneSpeedUp()
    {
        controlLvlProgres = true;
        yield return new WaitForSeconds(0.2f);
        controlLvlProgres = false;
    }
    public void ReStartGame()
    {
        start = false;
        runMetres = 0;
        SetUpInText();
    }
}
