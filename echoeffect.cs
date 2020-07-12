using UnityEngine;

public class echoeffect : MonoBehaviour
{
    float timebtwspawn;
    public float starttimebtwnspwan;
    public GameObject ripple;

    void Update()
    {
        if(timebtwspawn <= 0){
            GameObject Inst = Instantiate(ripple,transform.position,Quaternion.identity);
            Destroy(Inst,0.5f);
            timebtwspawn = starttimebtwnspwan;
        }else{
            timebtwspawn -= Time.deltaTime;
        }
    }
}
