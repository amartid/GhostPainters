using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popups : MonoBehaviour
{   
    public string popUp;
    void Update()
    {
        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
        pop.PopUp();
    }
}
