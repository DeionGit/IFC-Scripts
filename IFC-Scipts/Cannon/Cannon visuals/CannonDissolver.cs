using UnityEngine;
using DG.Tweening;
using UnityEngine.VFX;
public class CannonDissolver : MonoBehaviour
{
    [SerializeField] MeshRenderer[] bazookaRenderers;

    public float dissolveValue;
    public float undissolveValue;
    public float timeToFade;

    public Tween dissolveSeq;
    public Tween undissolveSeq;

    [SerializeField] VisualEffect vfxGraph;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DissolveCannon();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            UndissolveCannon();
        }
    }

    public void DissolveCannon()
    {
        vfxGraph.Play();
       for(int i=0; i < bazookaRenderers.Length ; i++)
       {
           bazookaRenderers[i].material.DOFloat(dissolveValue, "_DissolveAmmount", timeToFade);

            if(i == bazookaRenderers.Length-1 )
            {
                dissolveSeq = bazookaRenderers[i].material.DOFloat(dissolveValue, "_DissolveAmmount", timeToFade);
            }
       }     
    }
    public void UndissolveCannon()
    {
        for (int i = 0; i < bazookaRenderers.Length; i++)
        {
            bazookaRenderers[i].material.DOFloat(undissolveValue, "_DissolveAmmount", timeToFade);

            if (i == bazookaRenderers.Length - 1)
            {
                undissolveSeq = bazookaRenderers[i].material.DOFloat(undissolveValue, "_DissolveAmmount", timeToFade);
            }
        }
    }

}
