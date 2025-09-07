using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayOptions : MonoBehaviour
{
   [SerializeField] GameObject leftPointer;
   [SerializeField] GameObject rightPointer;

    BoxingGloves[] gloves;

    public float min, mid, max;
    private void Awake()
    {
        gloves = FindObjectsOfType<BoxingGloves>();
    }
    public void ActiveRightPointer()
    {
        leftPointer.SetActive(false);
        rightPointer.SetActive(true);
    }
    public void ActiveLeftPointer()
    {
        leftPointer.SetActive(true);
        rightPointer.SetActive(false);
    }

    public void MinDiff()
    {
        foreach(BoxingGloves glove in gloves)
        {
            glove.magnitudeMultiplier = min;
        }
    }
    public void MidDiff()
    {
        foreach (BoxingGloves glove in gloves)
        {
            glove.magnitudeMultiplier = mid;
        }
    }
    public void MaxDiff()
    {
        foreach (BoxingGloves glove in gloves)
        {
            glove.magnitudeMultiplier = max;
        }
    }
}
