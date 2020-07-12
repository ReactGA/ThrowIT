using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe1 : MonoBehaviour//IPointerUpHandler , IPointerDownHandler, IDragHamdler
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [Range(5f,100f)]
    public float throwForce = 30f;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
            GetComponent<Rigidbody>().AddForce (direction/timeInterval * throwForce);
        }
    }
}
