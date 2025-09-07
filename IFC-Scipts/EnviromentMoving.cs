using UnityEngine;

public class EnviromentMoving : MonoBehaviour
{
    [SerializeField] public float maxSpeed;
    [SerializeField] public float speed = 0;
    [SerializeField] float runStart;
    [SerializeField] float startTime;
    [SerializeField] Vector3 resetPos;
    public bool gameStart = false;

   public bool StartRunning = false;
    private void Start()
    {
        resetPos = transform.localPosition;
    }
    void Update()
    {
        TweenSpeed(runStart, maxSpeed);
        
    }
    private void FixedUpdate()
    {
        LimitSpeed(maxSpeed);
        Running();
    }
    void Running()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void ResetPosition()
    {
        transform.localPosition = resetPos;
    }
    void LimitSpeed(float limitNum)
    {
        Mathf.Clamp(speed, 0, limitNum);
    }
    void TweenSpeed(float TimeToMaxVel, float totalSpeed)
    {
        if (gameStart)
        {
            float maxVelMultiplier;

            startTime += Time.deltaTime;
            Mathf.Clamp(startTime, 0, TimeToMaxVel);

            maxVelMultiplier = startTime / TimeToMaxVel;

            speed =Mathf.RoundToInt(totalSpeed * maxVelMultiplier);
            if(speed >= totalSpeed)
            {
                gameStart = false;
                startTime = 0;
            }
        }
    }
}
