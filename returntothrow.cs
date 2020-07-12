using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returntothrow : MonoBehaviour
{
    public Transform ball;
    public Transform throwpoint;
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("ball")){
            Invoke("returnb" ,1f);
            
        }
    }

    void returnb(){
        ball.transform.position = throwpoint.transform.position;
    }
}
