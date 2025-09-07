using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;

public class TableSettings : MonoBehaviour
{
    public Modular3DText settingsText;
    [SerializeField]string[] settingName;

    [SerializeField] GameObject AudioOptions;
    [SerializeField] GameObject GraphicsOptions;
    [SerializeField] GameObject GameplayOptions;

    GameObject activeOptions;
    int settingNum = 0;

    private void OnEnable()
    {
        UpdateSettingPanel();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ChangeSetting(int backOrNext)
    {
       settingNum +=backOrNext;
       UpdateSettingPanel();
            
    }

    void UpdateSettingPanel()
    {
        switch (settingNum)
        {
            case -1:
                settingNum = 2;
                UpdateSettingPanel();
                break;
            case 0:
                LoadAudioPanel();

                break;
            case 1:
                LoadGraphicsPanel();

                break;
            case 2:
                LoadGameplayPanel();

                break;
            case 3:
                settingNum = 0;
                UpdateSettingPanel();
                break;
        }
        Debug.Log(settingNum);
    }

   void LoadAudioPanel()
   {
        settingsText.UpdateText(settingName[0]);
        if (activeOptions)
        {
            activeOptions.SetActive(false);
            activeOptions = AudioOptions;
            activeOptions.SetActive(true);
        }
        else
        {
            activeOptions = AudioOptions;
            activeOptions.SetActive(true);
        }
        

   }
   void LoadGraphicsPanel()
   {
        settingsText.UpdateText(settingName[1]);
        if (activeOptions)
        {
            activeOptions.SetActive(false);
            activeOptions = GraphicsOptions;
            activeOptions.SetActive(true);
        }
        else
        {
            activeOptions = GraphicsOptions;
            activeOptions.SetActive(true);
        }
    }
   void LoadGameplayPanel()
   {
        settingsText.UpdateText(settingName[2]);
        if (activeOptions)
        {
            activeOptions.SetActive(false);
            activeOptions = GameplayOptions;
            activeOptions.SetActive(true);
        }
        else
        {
            activeOptions = GameplayOptions;
            activeOptions.SetActive(true);
        }
    }
}
