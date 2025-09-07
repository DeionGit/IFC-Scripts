using UnityEngine;

public class EnviromentBehaviour : MonoBehaviour
{
    [SerializeField] Transform spawnTransform;
    [SerializeField] GameObject GymEnviroment;

    public bool canSpawn = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            canSpawn = false;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            canSpawn = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            canSpawn = true;
        }

    }
    public void ReposEnviroment(GameObject enviromentToRepos)
    {
        if (canSpawn)
        {
            enviromentToRepos.transform.position = spawnTransform.position;
        }
    }
}
