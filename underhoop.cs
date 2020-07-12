using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underhoop : MonoBehaviour
{
    public bool scored = false;
    public Transform hoop;
    public hoop hp;
    public Collider2D col;

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("ball")){
           Invoke("changepost",3f);
           scored = true;
           Invoke("rtn",1f);
       }
   }

   void rtn(){
       scored = false;
   }
   void Update()
   {
       transform.position = hoop.position;

       if(hp.MakeScore == false){
           col.isTrigger= false;
       }else if(hp.MakeScore == true){
           col.isTrigger= true;
       }
   }
   void changepost(){
        hoop.transform.position = new Vector3((transform.position.x+(Random.Range(0f,3.4f))),(transform.position.y+(Random.Range(0f,2.5f))),transform.position.z);
    }
}
