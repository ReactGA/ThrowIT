using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoop : MonoBehaviour
{
    public underhoop uh;
    [HideInInspector]
    public bool MakeScore = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(transform.position.x>6.5f){
            transform.position = new Vector3(3.4f,transform.position.y,transform.position.z);
        }else if(transform.position.x<0f){
            transform.position = new Vector3(0f,transform.position.y,transform.position.z);
        }else if(transform.position.y>2.5f){
            transform.position = new Vector3(transform.position.x,0f,transform.position.z);
        }else if(transform.position.y<0f){
            transform.position = new Vector3(transform.position.x,0f,transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ball")){
            MakeScore = true;
            Invoke("rtn", .5f);
        }
    }


    void rtn(){
        MakeScore = false;
    }
}
