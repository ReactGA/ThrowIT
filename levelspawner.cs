using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelspawner : MonoBehaviour
{
    public GameObject[] plank;
    [HideInInspector]
    public GameObject p,p1,p2,p3;
    Vector3 offset,offset1,offset2,offset3;
    float px,py,px1,py1;
    public levels lc;

    private void Awake() {
        p = Instantiate(plank[0],transform.position + new Vector3(-4f,1f,0f),Quaternion.Euler(0f,0f,90f));
        p.transform.localScale += new Vector3(0f,Random.Range(-.5f,.0f),0f);
        p1= Instantiate(plank[1],transform.position + new Vector3(2f,-1f,0f),Quaternion.Euler(0f,0f,-90f));
        p1.transform.localScale += new Vector3(0f,Random.Range(-.5f,.0f),0f);
    }

    public void spawnlevel(){
        p = Instantiate(plank[0],transform.position + offset,Quaternion.Euler(0f,0f,90));
        p.transform.localScale += new Vector3(0f,Random.Range(-.5f,.0f),0f);
        p1= Instantiate(plank[1],transform.position + offset1,Quaternion.Euler(0f,0f,90));
        p1.transform.localScale += new Vector3(0f,Random.Range(-.5f,.0f),0f);
        if(lc.levelcount>= 7){
            p2 = Instantiate(plank[3],transform.position + offset2,Quaternion.Euler(0f,0f,45f));
        }else if (lc.levelcount >= 15){
            p3 = Instantiate(plank[4],transform.position + offset3,Quaternion.Euler(0f,0f,45f));
        }
    }

    private void Update() {
        offset = new Vector3(px,py,0f);
        px= Random.Range(-6.5f,1f);
        py= Random.Range(-1f,0.5f);
        offset1 = new Vector3(px1,py1,0f);
        offset2 = new Vector3(px1,py,0f);
        offset3 = new Vector3(px,py1,0f);
        px1= Random.Range(0f,4f);
        py1= Random.Range(0f,2f);
    }
}
