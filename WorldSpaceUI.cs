using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldSpaceUI : MonoBehaviour
{

    private const string shaderMode = "unity_GUIZTestMode";
    [SerializeField] UnityEngine.Rendering.CompareFunction desiredUIComparison = UnityEngine.Rendering.CompareFunction.Always;
    [SerializeField] Graphic[] uiElementsToApplyTo;

    private Dictionary<Material, Material> materialsMappings = new Dictionary<Material, Material>();
    void Start()
    {
        foreach(var graphic in uiElementsToApplyTo)
        {
            Material material = graphic.materialForRendering;
            if(material ==null)
            {
                Debug.Log("Target material does nor have rendering component");
                continue;
            }

            if(materialsMappings.TryGetValue(material,out Material materialCopy) == false)
            {
                materialCopy = new Material(material);
                materialsMappings.Add(material, materialCopy);
            }

            materialCopy.SetInt(shaderMode, (int)desiredUIComparison);
            graphic.material = materialCopy;
        }
    }

}
