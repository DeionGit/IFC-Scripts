using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Autohand;
public class BoxingGloves : MonoBehaviour
{
    private List<InputDevice> leftDevices = new List<InputDevice>();
    private List<InputDevice> rightDevices = new List<InputDevice>();

    [SerializeField] Rigidbody rb;
    Autohand.Hand gloveHand;
    Grabbable objGRabbable;
    public float magnitudeMultiplier;
    public float hitCooldown;
    public bool canHit = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objGRabbable = GetComponent<Grabbable>();

    }
    public Vector3 GetDirection()
    {
        Vector3 direction = rb.velocity;

        return Vector3.ClampMagnitude(direction, 12f);
    }
    public float GetMagnitude()
    {
        float magnitude = rb.velocity.magnitude * magnitudeMultiplier;
        Debug.Log(magnitude + "magnitude");
        return magnitude;
    }
    public void CallHitCoolDown()
    {
        StartCoroutine(CoolDownHit());
    }
    IEnumerator CoolDownHit()
    {
        canHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canHit = true;
    }
   
    public void GetGloveHand()
    {
        canHit = true;
        gloveHand = objGRabbable.GetHeldBy()[0];
    }
    public void CallThisGloveHaptics()//Llama a la funcion desde otros scripts
    {
        SendHapticImpulse(gloveHand, 0.7f, 0.3f);
    }
    void SendHapticImpulse(Autohand.Hand hand, float amplitude, float duration) // Activar Vibracion
    {
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftDevices);
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightDevices);

        if (hand == hand.left && leftDevices.Count > 0)
        {
            if (leftDevices[0].TryGetHapticCapabilities(out HapticCapabilities leftCapabilities) && leftCapabilities.supportsImpulse)
            {
                leftDevices[0].SendHapticImpulse(0u, amplitude, duration);
            }
        }
        if (hand == !hand.left && rightDevices.Count > 0)
        {
            if (rightDevices[0].TryGetHapticCapabilities(out HapticCapabilities rightCapabilities) && rightCapabilities.supportsImpulse)
            {
                rightDevices[0].SendHapticImpulse(0u, amplitude, duration);
            }
        }
    }

}
