using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PopUpSystem : MonoBehaviour{

    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;


    public void PopUp()
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");
    }
}
