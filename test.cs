using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    /*bool maintainwidth = true;
    float defaultwidth;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultwidth = Camera.main.orthographicSize*Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
       if(maintainwidth){
            Camera.main.orthographicSize = defaultwidth/Camera.main.aspect;
       }
    }/* */

    
    public void startgame(){
        SceneManager.LoadScene(1);
    }
}
