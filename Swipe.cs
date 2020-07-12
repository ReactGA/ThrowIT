using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
   
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    public float swipecount = 0f;
    public controls c;
    public controls1 c1;
    public levels cl;

    [Range(0.05f,1f)]
    public float throwForce = 0.3f;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
            touchTimeFinish = Time.time;
            timeInterval = 1f + (touchTimeFinish - touchTimeStart);
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
            if(c != null && c.isplaying == true){
                GetComponent<Rigidbody2D>().AddForce(-direction/timeInterval * (2f* throwForce));
                swipecount +=1f;
            }else if(c1 != null && c1.isplaying == true){
                GetComponent<Rigidbody2D>().AddForce(-direction/timeInterval * (2f* throwForce));
                swipecount +=1f;
            }else if(cl != null && cl.isplaying == true){
                GetComponent<Rigidbody2D>().AddForce(-direction/timeInterval * (2f* throwForce));
                swipecount +=1f;
            }
        }

        if(Input.GetMouseButtonDown(0)){
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0)){
            touchTimeFinish = Time.time;
            timeInterval = 1f + (touchTimeFinish - touchTimeStart);
            endPos = Input.mousePosition;
            direction = startPos - endPos;
            if(c != null && c.isplaying == true){
                GetComponent<Rigidbody2D>().AddForce(-direction/timeInterval * (2f* throwForce));
                swipecount +=1f;
            }else if(c1 != null && c1.isplaying == true){
                GetComponent<Rigidbody2D>().AddForce(-direction/timeInterval * (2f *throwForce));
                swipecount +=1f;
            }else if(cl != null && cl.isplaying == true){
                GetComponent<Rigidbody2D>().AddForce(-direction/timeInterval * (2f *throwForce));
                swipecount +=1f;
            }
        }
    }

    
}
