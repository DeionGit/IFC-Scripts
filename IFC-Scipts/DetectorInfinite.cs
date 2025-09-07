using UnityEngine;

public class DetectorInfinite : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            GameObject enviromentToRepos = other.gameObject;
            ReposEnviroment(enviromentToRepos);
        }
    }


    void ReposEnviroment(GameObject enviToRepos)
    {
        EnviromentBehaviour[] enviBehaviours = FindObjectsOfType<EnviromentBehaviour>();
        foreach(EnviromentBehaviour enviBehaviour in enviBehaviours)
        {
            if (enviBehaviour.canSpawn)
            {
                enviBehaviour.ReposEnviroment(enviToRepos);

                enviToRepos.GetComponent<Spawner>().DeleteObstacules();

                enviToRepos.GetComponent<Spawner>().SpawnSacoBoxing(3);

                enviToRepos.GetComponent<Spawner>().SpawnPeraBoxing(4);

                enviToRepos.GetComponent<Spawner>().SpawnRingRopes();

                enviToRepos.GetComponent<Spawner>().SpawnWall();

                #region decorationSpawn
                if (enviToRepos.GetComponentInChildren<EnviromentDecoration>().needResetList)// Resetea la decoracion
                {
                    enviToRepos.GetComponentInChildren<EnviromentDecoration>().ListReset();
                }
                if (enviToRepos.GetComponentInChildren<EnviromentDecoration>().needDecoration) // Crea la decoracion
                {
                    enviToRepos.GetComponentInChildren<EnviromentDecoration>().RandomSelectMisc();
                }
                #endregion
            }
        }
    }
}
