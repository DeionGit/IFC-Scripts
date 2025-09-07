using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivePanel : MonoBehaviour
{
    [SerializeField] GameObject buttonPanel;
    bool panelOn = false;
    public void GoPanel()
    {
        if (!panelOn && !PanelsController.instance.activePanel == buttonPanel)
        {
            buttonPanel.SetActive(true);
            panelOn = true;

            PanelsController.instance.activePanel = buttonPanel;
        }else if(panelOn)
        {
            buttonPanel.SetActive(false);
            panelOn = false;

            PanelsController.instance.activePanel = null;
        }
       
    }
  
}
