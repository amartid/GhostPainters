using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FollowMe : MonoBehaviour{ 
    public GameObject FloatingTextPrefab;
    public float speed;
    public float stoppingDistance;
    private Transform target;
    private Transform speackTarget;
    public bool follow=false;
    private Dialogue boxScript;

    private Dictionary <string, int> spoken = new Dictionary<string, int>();
    private UnityEngine.GameObject NPCname;
    void Start(){
        GameObject[] painters = GameObject.FindGameObjectsWithTag("Painter");
        //var objectCount = objects.Length;
        foreach (var p in painters)
        {
            Debug.Log(p.name);
            spoken.Add(p.name,1);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speackTarget = target;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        speackTarget = null;
    }

    void Update() 
    {   

        if(speackTarget){
            if( Input.GetKeyDown("space")){
                ShowSpeechText();
            }
        }
        if(target){
            if (follow){
                if(Vector3.Distance(transform.position,target.position) > stoppingDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
        }
        if(FloatingTextPrefab)
        {
            ShowFloatingText();	
        }
    }
    void ShowFloatingText()
    {
        NPCname = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        NPCname.GetComponent<TextMesh>().text = name.ToString();
    }
    void ShowSpeechText()
    {   
        GameObject boxComponent = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        boxScript = boxComponent.GetComponent<Dialogue>();
        boxScript.speaker=name;
        Debug.Log("FollowMe"+boxScript.speaker);
        boxScript.speakerNumber=spoken[name];
        if(!boxScript.isActiveAndEnabled){
            boxComponent.SetActive(true);
            boxScript.Start();
            if(spoken[name]==4){
                spoken[name]=0;
            }
            else{
                spoken[name]+=1;
            }
        }
    }
}