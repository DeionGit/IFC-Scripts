using UnityEngine;
using MText;
using DG.Tweening;

public class ButtonDissolve : MonoBehaviour
{
    MText_UI_Button boxButton;
    public Modular3DText buttonText;
    BoxingObstacules boxingObstacule;
    GameObject text3d;
    void Start()
    {
        boxingObstacule = GetComponent<BoxingObstacules>();
        boxButton = GetComponentInParent<MText_UI_Button>();
        text3d = buttonText.gameObject;
    }
    public void ClickOnButton()
    {
        boxButton.onClick.Invoke();
        buttonText.Text = "Start" + "/n" + "Run "; // Añadirtexto es la unica forma de activar el modulo de físicas al texto 
        DissapearText();
        Debug.Log("boton pulsado");
        StartGame.instance.StartingRun();
        
    }
    public void DissapearText()
    {
        LayoutElement[] allLetters = buttonText.GetComponentsInChildren<LayoutElement>();
        foreach(LayoutElement letter in allLetters)
        {
            if (letter.GetComponent<MeshRenderer>())
            {
                letter.GetComponent<MeshRenderer>().material.DOFade(0, 3f).OnComplete(() =>
                {
                    Destroy(text3d);
                }
                );
            }
        }
    }
}
