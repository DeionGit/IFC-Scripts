using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;
using DG.Tweening;

public class ComboHologramUI : MonoBehaviour
{
    [SerializeField] Modular3DText comboUI;
    [SerializeField] MeshRenderer[] holograms;
    [Header("ComboVariables")]
    
    [Header("ShaderParameters")]
    [SerializeField] const float glitchStrengthOn = 0.06f;
    [SerializeField] const float glitchStrengthOff = 0;


    private void OnEnable()
    {
        HologramOn(ComboDetection.instance.comboMultiplier);
    }

    private void Awake()
    {
        GetModular3DText();
        GetHolograms();
    }

    void GetModular3DText()
    {
        comboUI = transform.GetChild(0).GetComponent<Modular3DText>();
        comboUI.combineMeshDuringRuntime = true;
    }

    void GetHolograms()
    {
        MeshRenderer holoHolder = GetComponent<MeshRenderer>();
        MeshRenderer holoCombo = transform.GetChild(0).GetComponent<MeshRenderer>();
        holograms = new MeshRenderer[2] { holoHolder, holoCombo };
    }
    void Update()
    {
        
    }

    public void GlitchHologramAndUIUpdate(int comboMultiplier)
    {
        foreach (MeshRenderer render in holograms)
        {
            render.material.SetInt("_Glitch", 1);
            render.material.DOFloat(glitchStrengthOn, "_GlitchStrength", 0.15f).SetEase(Ease.OutElastic).OnComplete(() =>
            {
                //--------------------------------
                ComboUIUpdate(comboMultiplier);//<----|Function That update UI|
                //--------------------------------
                render.material.DOFloat(-glitchStrengthOn, "_GlitchStrength", 0.15f).SetEase(Ease.OutElastic).OnComplete(() =>
                {
                    render.material.DOFloat(glitchStrengthOff, "_GlitchStrength", 0.2f).SetEase(Ease.OutBounce).OnComplete(() =>
                    {
                        render.material.SetInt("_Glitch", 0);
                    });
                    
                });
            });
        }
    }
    public void HologramOn(int comboMultiplier)
    {
        ComboUIUpdate(comboMultiplier);
        foreach (MeshRenderer render in holograms)
        {
            render.material.DOFloat(2, "_Alpha", 0.8f).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                if (!gameObject.activeSelf)
                {
                    gameObject.SetActive(true);
                }
            });
        }
    }
    public void HologramOff()
    {
        foreach(MeshRenderer render in holograms)
        {
            render.material.DOFloat(0, "_Alpha", 0.3f).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                if (gameObject.activeSelf)
                {
                    gameObject.SetActive(false);
                }
            });
        }
    }
    void ComboUIUpdate(int comboNum)
    {
        comboUI.Text = "X" + comboNum;
    }
   
}
