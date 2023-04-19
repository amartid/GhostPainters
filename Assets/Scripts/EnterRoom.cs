using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterRoom : MonoBehaviour
{
    
    public bool correctInArea = false;

    private string objTag = "Painter";
    public Dictionary <string, bool> insideTable = new Dictionary<string, bool>();
    GameObject[] painters;
    [SerializeField]
    private string objName;
    void Start(){
        painters = GameObject.FindGameObjectsWithTag("Painter");
        //var objectCount = objects.Length;
        foreach (var p in painters)
        {
            Debug.Log(p.name);
            insideTable.Add(p.name,false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag==objTag)
        {
            insideTable[other.gameObject.name]=true;
            if (other.gameObject.name == objName)
            {
                correctInArea = true;
                Debug.Log(objName + "is inside!");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag==objTag)
        {
            insideTable[other.gameObject.name]=false;
            if (other.gameObject.name == objName)
            {
                correctInArea = false;
                Debug.Log(objName + "is outside!");
            }
        }
    }
}