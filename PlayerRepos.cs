using UnityEngine;
using UnityEngine.UI;

public class PlayerRepos : MonoBehaviour
{
    [SerializeField] Transform resetTransform;
    [SerializeField] GameObject player;
    [SerializeField] Camera playerHead;

    [SerializeField] Image reposImage;

    bool pressing = false;
    float holdPres = 0;

    static public PlayerRepos instance;
    private void Awake()
    {
        #region Singleton
        if (instance== null)
        {
            instance = this;
        }else
        {
            Destroy(this);
        }
        #endregion
    }
    private void Update()
    {
        if (pressing)
        {
            FillImageRepos();
        }
        else
        {
            UnfillImageRepos();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            PressedButton();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            ReleasedButton();
        }
    }
    public void ResetPosition()
    {
        var rotationAngleY = resetTransform.transform.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        transform.position = new Vector3(transform.position.x, playerHead.transform.position.y, transform.position.z);

        var distanceDiff = resetTransform.position - playerHead.transform.position;
        player.transform.position += distanceDiff;
    }

    public void PressedButton()
    {
        pressing = true;
    }

    void FillImageRepos()
    {
        holdPres += Time.deltaTime * 0.75f;
        reposImage.fillAmount = holdPres;
        if (holdPres >= 1)
        {
            ResetPosition();
            pressing = false;
            holdPres = 0;
            reposImage.fillAmount = 0;
        }
    }
    void UnfillImageRepos()
    {
        if (holdPres > 0)
        {
            holdPres -= Time.deltaTime * 0.75f;
            reposImage.fillAmount = holdPres;
            if (holdPres <= 0)
            {
                holdPres = 0;
                reposImage.fillAmount = 0;
            }
        }
    }

    public void ReleasedButton()
    {
        pressing = false;
    }
}
