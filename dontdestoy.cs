using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestoy : MonoBehaviour
{
    public static dontdestoy instance;

    // Start is called before the first frame update
    void Start()
    {
        
        if(instance ==null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(Input.GetKey("m")){
            SceneManager.LoadScene(0);
        }
    }
}
