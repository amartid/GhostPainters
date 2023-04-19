using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyCanvas : MonoBehaviour
{
    public Canvas DialogueBox; //Your target for the refference
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {

            DialogueBox.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueBox.enabled = false;
        }
    }
     
    //If you want to be more specific to what gets enabled and store it all in one script you can check tags
     
    // Void OnTriggerEnter(collider :Collider){
    //      if (collider.tag =="NPCName"){
    //            myCanvas.enabled = true;
    //      }
    // }
}
