using UnityEngine;

public class ReposingObstacule : MonoBehaviour
{

    Spawner spawnerScript;

    public ObstaculeType obstaculeType;
    void Start()
    {
        spawnerScript = GetComponentInParent<Spawner>();
    }

    
   void ReposGameobject()
   {
       if (obstaculeType == ObstaculeType.Saco) //saco
       {
            Vector3 newPos = new Vector3(spawnerScript.GetSacoX(), 2.6f, spawnerScript.GetSacoZ());
            transform.localPosition = newPos;
       }else if (obstaculeType == ObstaculeType.RightPera)   //RightPera
       {
            Vector3 rightSpawnPos = new Vector3(spawnerScript.GetPeraRightX(), 2, spawnerScript.GetPeraZ());
            transform.localPosition = rightSpawnPos;
       }else if(obstaculeType == ObstaculeType.LeftPera)    //LeftPera
       {
            Vector3 leftSpawnPos = new Vector3(spawnerScript.GetPeraLeftX(), 2, spawnerScript.GetPeraZ());
            transform.localPosition = leftSpawnPos;
       }
   }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="ObstaculeParent")
        {
            ReposGameobject(); 
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ObstaculeParent")
        {
            ReposGameobject();
        }
    }
}
public enum ObstaculeType
{
    Saco,
    LeftPera,
    RightPera
}

