using UnityEngine;

public class SetDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Display.displays.Length > 1)
        {
            Display.displays[0].Activate();
        }
    }

}
