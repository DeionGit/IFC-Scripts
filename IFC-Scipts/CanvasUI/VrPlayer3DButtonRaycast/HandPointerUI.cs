using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HandPointerUI : MonoBehaviour
{

    public float cooldownClick = 0.3f;
    bool canClick = true;

    public InputActionProperty clickAction;

    MenuAudioController uiAudioController;

    ButtonCaller selectedButton;
    LaserController laserCont;
    private void Awake()
    {
        laserCont = GetComponent<LaserController>();
        uiAudioController = FindObjectOfType<MenuAudioController>();
    }

    private void Start()
    {
        clickAction.action.Enable();
        clickAction.action.performed += (e) => { ClickOnButton(); };
    }
    void Update()
    {
        UIRay();
    }

    void UIRay()
    {
       RaycastHit hit;
        Debug.DrawRay(transform.localPosition, transform.forward);
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            if (hit.collider.TryGetComponent<ButtonCaller>(out ButtonCaller button))
            {
                laserCont.LineEnable();
                if (selectedButton == null || selectedButton != button)
                {
                    selectedButton = button;
                    selectedButton.SelectButton();
                    Debug.Log(selectedButton.name);
                }
                laserCont.SetLaserDistance(hit);
            }else if(hit.collider.tag == "UIPanel")
            {
                laserCont.LineEnable();
            }
        }
        else 
        {
            if (selectedButton != null)
            {
                selectedButton.UnselectButton(); 
                selectedButton = null;
            }
            laserCont.LineDisable();
        }

    }
    IEnumerator ClickCoolDown(float cooldown)
    {
        canClick = false;

        yield return new WaitForSeconds(cooldown);

        canClick = true;
    } 
    public void ClickOnButton()
    {
        if(selectedButton != null && canClick)
        {
            StartCoroutine(ClickCoolDown(cooldownClick));
            uiAudioController.ClickSound();
            selectedButton.ClickButton();
        }
    }

}
