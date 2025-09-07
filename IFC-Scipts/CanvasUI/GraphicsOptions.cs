using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using MText;

public class GraphicsOptions : MonoBehaviour
{
    [SerializeField] GameObject volumeObject;
    [SerializeField] Volume volume;
    [SerializeField] Modular3DText gammaText;

    [SerializeField] GameObject postPX, postPTic;
    [SerializeField] GameObject dethpOfFieldX, dethpOfFieldTic;
    LiftGammaGain gammaGain;
    DepthOfField depthOfField;
    void Awake()
    {
        volume.profile.TryGet(out gammaGain);
        volume.profile.TryGet(out depthOfField);
    }
    private void OnEnable()
    {
        UpdateTextGammaAlpha();
        
    }
    private void Start()
    {
        CheckVolumeInterfaz();
        CheckGammaInterfaz();
        CheckDepthOfFieldInterfaz();
    }
    public void OnPostP()
    {
        volume.enabled = true;
        CheckVolumeInterfaz();
    }
    public void OffPostP()
    {
        volume.enabled = false;
        CheckVolumeInterfaz();
    }
    public void ChangeGamma(float gammaAdd)
    {
        if (gammaAdd > 0 && gammaGain.gamma.value.w < 1f)
        {
            gammaGain.gamma.Override(new Vector4(1, 1, 1, gammaGain.gamma.value.w + gammaAdd));

            UpdateTextGammaAlpha();
        }else if(gammaAdd < 0 && gammaGain.gamma.value.w > -0.75f)
        {
            gammaGain.gamma.Override(new Vector4(1, 1, 1, gammaGain.gamma.value.w + gammaAdd));

            UpdateTextGammaAlpha();
        }
    }
    void UpdateTextGammaAlpha()
    {
        gammaText.UpdateText(gammaGain.gamma.value.w);
    }

    public void OnDepthOfField()
    {
        depthOfField.active = true;

        CheckDepthOfFieldInterfaz();
    }
    public void OffDepthOfField()
    {
        depthOfField.active = false;

        CheckDepthOfFieldInterfaz();
    }
    void CheckGammaInterfaz()
    {
        int gammaNum = Mathf.RoundToInt(gammaGain.gamma.value.z);
        gammaText.UpdateText(gammaNum);
    }
    void CheckVolumeInterfaz()
    {
        if (volume.enabled)
        {
            postPX.SetActive(false);
            postPTic.SetActive(true);
        }
        else
        {
            postPX.SetActive(true);
            postPTic.SetActive(false);
        }
    }
    void CheckDepthOfFieldInterfaz()
    {
        if (depthOfField.active)
        {
            dethpOfFieldX.SetActive(false);
            dethpOfFieldTic.SetActive(true);
        }
        else
        {
            dethpOfFieldX.SetActive(true);
            dethpOfFieldTic.SetActive(false);
        }
    }
}
