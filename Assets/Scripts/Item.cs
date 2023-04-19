using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour{ 
    private Transform speackTarget;
    private Dialogue boxScript;
    public string item;
    
    void Start(){
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        speackTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
    }

    void ShowSpeechText()
    {   
        GameObject boxComponent = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        boxScript = boxComponent.GetComponent<Dialogue>();
        boxScript.speaker=item;
        boxScript.speakerNumber=0;
        Debug.Log("Item "+boxScript.speaker);
        if(!boxScript.isActiveAndEnabled){
            boxComponent.SetActive(true);
            boxScript.Start();    
        }
    }
}