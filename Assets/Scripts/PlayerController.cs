using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float Speed;
    public bool move=false;
    Rigidbody2D rigid;
    public FollowMe follower;
    public bool isFollowing=false;
    

    float h;
    float v;
    bool isHorizonMove;
    
    
    
    private Dialogue boxScript;
    private GameObject boxComponent;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Painter")
        {
            if (isFollowing==false)
            {
                follower = GameObject.Find(other.name).GetComponent<FollowMe>();
            }
        }
    }

    void Update()
    {   
        if(follower)
        {
            if (Input.GetKeyDown("left shift"))
            {
                if (isFollowing==false)
                {
                    follower.follow = true;
                    Debug.Log("TRUE FOLLOWER");
                    isFollowing=true;
                }else{
                    follower.follow = false;
                    Debug.Log("FAKE FOLLOWER");
                    isFollowing=false;
                    follower=null;
                    checkWin();
                }
            }
        }        
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");
        
        
        
        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;
        
    } 

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h,0) : new Vector2(0,v);
        if (move)
            rigid.velocity = moveVec * Speed;
        else
            rigid.velocity=moveVec*0;
    }

    void checkWin(){
        var rooms = GameObject.FindGameObjectsWithTag("Room");
        bool win = true;
        int fullRooms = 0;
        if(!this.isFollowing){
            if(rooms.Length!=0)
            {    
                foreach (var room in rooms) {
                    if(room.GetComponent<EnterRoom>()!=null){
                        if(!room.GetComponent<EnterRoom>().correctInArea){
                            win = false;
                        }
                        bool someoneInside = false;
                        foreach(var item in room.GetComponent<EnterRoom>().insideTable)
                        {
                            if(item.Value){
                                someoneInside = true;
                            }
                        }
                        if(someoneInside){
                            fullRooms=fullRooms+1;
                        }
                    }
                }
                Debug.Log("fullRooms "+fullRooms);
            }
            
            if(win){
                boxComponent = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
                boxScript = boxComponent.GetComponent<Dialogue>();
                boxScript.speaker = "Win";
                Debug.Log("PlayerName "+boxScript.speaker);
                if(!boxScript.isActiveAndEnabled){
                    boxComponent.SetActive(true);
                    boxScript.Start();
                }
            }else{
                if(fullRooms==6){
                    boxComponent = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
                    boxScript = boxComponent.GetComponent<Dialogue>();
                    boxScript.speaker = "Not Win";
                    if(!boxScript.isActiveAndEnabled){
                        boxComponent.SetActive(true);
                        boxScript.Start();
                    }

                }
            }
        }
    }
}


