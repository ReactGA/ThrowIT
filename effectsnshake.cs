using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectsnshake : MonoBehaviour
{
    public GameObject effects;
    public AudioSource bounce;
    public Camerashake cs;


    private void OnCollisionEnter2D(Collision2D other) {
        if (PlayerPrefs.GetInt("sd") ==1){
            bounce.Play();
        }
        GameObject Instance = Instantiate(effects,transform.position,Quaternion.identity);
        Destroy(Instance,1f);
        StartCoroutine(cs.shake(0.1f,0.05f));
    }
}
