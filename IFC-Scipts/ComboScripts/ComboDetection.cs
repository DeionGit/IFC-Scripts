using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboDetection : MonoBehaviour
{
    public int comboMultiplier = 0;

    [SerializeField] GameObject holoHolder;
    [SerializeField] ComboHologramUI comboHoloUI;

    public CoinSystem coinSys;
    static public ComboDetection instance;
    private void Awake()
    {
        #region singleTon
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion

        holoHolder = transform.GetChild(0).gameObject;
        comboHoloUI = holoHolder.GetComponent<ComboHologramUI>();
        coinSys = FindObjectOfType<CoinSystem>();
    }
    
    public void CallHoloCombo()
    {
        comboMultiplier++;

        CheckHigherComboInRun(comboMultiplier);

        if (comboMultiplier >= 2)
        {
            if (holoHolder.activeSelf)
            {
                comboHoloUI.GlitchHologramAndUIUpdate(comboMultiplier);
            }
            else
            {
                holoHolder.SetActive(true);
            }
        }
        coinSys.AddBoxoins(comboMultiplier*1); //Al haber golpeado un obstaculo Se suman puntos
        StartCoroutine(DetectIfComboContinue());
    }

    IEnumerator DetectIfComboContinue()
    {
        int actualCombo = comboMultiplier;

        yield return new WaitForSeconds(3.5f);
        if(actualCombo == comboMultiplier)
        {
            comboMultiplier = 0;
            comboHoloUI.HologramOff();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CallHoloCombo();
            Debug.Log("Hello");
        }
    }

    void CheckHigherComboInRun(int combo) //Guarda en "HigherCombo" el mayor combo conseguido en la Run
    {
        if (combo >GetHigherScore.instance.higherComboInRun)
        {
            GetHigherScore.instance.higherComboInRun = combo;
        }
    }
    
}
