using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider force;
    public Swipe sp;


    // Update is called once per frame
    void Update()
    {
        sp.throwForce = force.value;
        
    }
}
