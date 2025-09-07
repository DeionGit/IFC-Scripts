using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;

public class ButtonCaller : MonoBehaviour
{
    public MText_UI_Button buttonToInvoke;

    void Start()
    {
        buttonToInvoke = GetComponentInParent<MText_UI_Button>(); 
    }

    
    void Update()
    {
        
    }

    public void ClickButton()
    {
        buttonToInvoke.onClick.Invoke();
    }
    public void SelectButton()
    {
        buttonToInvoke.onSelect.Invoke();
    }
     public void UnselectButton()
     {
        buttonToInvoke.onUnselect.Invoke();
     }
}
