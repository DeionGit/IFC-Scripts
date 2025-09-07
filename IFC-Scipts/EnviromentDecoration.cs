using System.Collections.Generic;
using UnityEngine;

public class EnviromentDecoration : MonoBehaviour
{
    List<Transform> miscList;
    List<Transform> modulesList;
    List<Transform> objectsList;

    public bool needResetList = false;
    public bool needDecoration = true;
    
    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach(Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }
    public void RandomSelectMisc() //Recoge y activa solo uno de los "Miscelanous"
    {
        miscList = GetChildren(transform);
        
        for (int i = 0; i < miscList.Count; i++)
        {
            int num = Random.Range(0, 2);
            if (num > 0)
            {
                miscList[i].gameObject.SetActive(true);
   
                RandomSelectModules(miscList[i]);
                needResetList = true;
                needDecoration = false;
                break;
            }         
        }
    }

    void RandomSelectModules(Transform activeMisc)
    {
        modulesList = GetChildren(activeMisc);

        for (int i =0;i< modulesList.Count; i++)
        {
           int num = Random.Range(0, 3);
            if (num > 0)
            {
                modulesList[i].gameObject.SetActive(true);
                RandomSelectObjects(modulesList[i]);
            }
        }
    }
    void RandomSelectObjects(Transform boxingObject)
    {
        objectsList = GetChildren(boxingObject);
        
        for (int i=0; i< objectsList.Count; i++)
        {
            int num = Random.Range(0, 3);
            if (num > 0) 
            {
                objectsList[i].gameObject.SetActive(true);
            }
        }
    }

    public void ListReset()
    {  //-------------------------------------------------------Disable objects and reset objects List
        foreach(Transform boxingObject in objectsList)
        {
            if (boxingObject.gameObject.activeSelf)
            {
                boxingObject.gameObject.SetActive(false);
            }
        }
        objectsList.Clear();
        //------------------------------------------------------ Disable Modules and Reset modules List
        foreach (Transform module in modulesList)
        {
            if (module.gameObject.activeSelf)
            {
                module.gameObject.SetActive(false);
            }
        }
        modulesList.Clear();
        //------------------------------------------------------ Disable Miscelanous parents and Reset misc List
        foreach (Transform misc in miscList)
        {
            if (misc.gameObject.activeSelf)
            {
                misc.gameObject.SetActive(false);
            }
        }
        miscList.Clear();
        needResetList = false;
        needDecoration = true;

    }
    
}
