using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levels : MonoBehaviour
{
    public GameObject end,loose,gooal,pausemenu;
    public Text time,score,level;
    float timecounts;
    bool stop = false;
    public underhoop hp;
    [HideInInspector]
    public float timecountsNo,levelcount,scorecount;
    public AudioSource click;
    public AudioSource clap;
    public Camerashake cs;
    public GameObject ball;
    public GameObject slider;
    public float duration;
    public Slider sl;
    bool echobool = false;
    [HideInInspector]
    public int cheatcount;
    [HideInInspector]
    public int echocount;
    public Text echocounttext;
    public Text cheatcounttext;
    public GameObject adspanel,adspanel1;
    [HideInInspector]
    public bool cheatbool = false;
    [HideInInspector]
    public bool isplaying = false;  
    public GameObject p1,p2,p3,p4,p5,p6,p7,p8,p9,p10;
    public GameObject O,E,T;

    void Start()
    {
        timecounts = 30f;
        PlayerPrefs.SetFloat("score",0f);
        levelcount = 1f;
        //levelcount = PlayerPrefs.GetFloat("lastlevel");
        isplaying = true;
    }

    
    void Update()
    {
        #region ifs
        if(PlayerPrefs.GetInt("trail") == 0){
            O.SetActive(true);
            E.SetActive(false);
            T.SetActive(false);
            ball.GetComponent<TrailRenderer>().enabled = false;
            ball.GetComponent<echoeffect>().enabled = false;
        }else if(PlayerPrefs.GetInt("trail")== 1){
            O.SetActive(false);
            E.SetActive(false);
            T.SetActive(true);
            ball.GetComponent<TrailRenderer>().enabled = true;
            ball.GetComponent<echoeffect>().enabled = false;
        }else if(PlayerPrefs.GetInt("trail")== 2){
            O.SetActive(false);
            E.SetActive(true);
            T.SetActive(false);
            ball.GetComponent<TrailRenderer>().enabled = false;
            ball.GetComponent<echoeffect>().enabled = true;
        }
        #endregion

        //scorecount = PlayerPrefs.GetFloat("score") +(timecounts/5f);
        sl.value = duration * 0.1f;
        timecounts -= Time.deltaTime;
        if(timecounts <= 0){
            timecounts = 0f;
            loose.SetActive(true);
            isplaying = false;
            Invoke("endgame",3f);
        }
        if(hp.scored == true && stop == false)
        {
            stop = true;
            if (PlayerPrefs.GetInt("sd") ==1){
            clap.Play();
        }
            PlayerPrefs.SetFloat("score",scorecount);
            StartCoroutine("goaltxt");
            StartCoroutine(cs.shake(2f,0.1f));
        }
        time.text = timecounts.ToString("0");
    }

    IEnumerator goaltxt(){
    
        gooal.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gooal.SetActive(false);
        level.text = levelcount.ToString("0");
        score.text = scorecount.ToString("0");
        levelcount +=1f;
        timecounts = 30f;
        
        
        
        if(levelcount == 5f){
            PlayerPrefs.SetInt("cheatamount", PlayerPrefs.GetInt("cheatamount") + 1);
            PlayerPrefs.SetInt("echoamount", PlayerPrefs.GetInt("echoamount") + 1);
        }else if(levelcount == 10f){
            PlayerPrefs.SetInt("cheatamount", PlayerPrefs.GetInt("cheatamount") + 2);
            PlayerPrefs.SetInt("echoamount", PlayerPrefs.GetInt("echoamount") + 2);
        }
        stop = false;   
    }

    public void pause(){
        if (PlayerPrefs.GetInt("sd") ==1){
            click.Play();
        }
        Time.timeScale = 0f;
        isplaying = false;
        pausemenu.SetActive(true);
    }
    public void resume(){
        if (PlayerPrefs.GetInt("sd") ==1){
            click.Play();
        }
        Time.timeScale = 1f;
        isplaying = true;
        pausemenu.SetActive(false);
    }
    public void restart(){
        if (PlayerPrefs.GetInt("sd") ==1){
            click.Play();
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu(){
        if (PlayerPrefs.GetInt("sd") ==1){
            click.Play();
        }
        Time.timeScale = 1f;
        PlayerPrefs.SetFloat("lastlevel",levelcount);
        isplaying = false;
        SceneManager.LoadScene(0);
    }
    void endgame(){
        loose.SetActive(false);
        end.SetActive(true);
        Time.timeScale = 0f;
        stop = false;
    }

     public void Switch(){
        if(PlayerPrefs.GetInt("switch")== 0){
            PlayerPrefs.SetInt("switch",1);
        }else if(PlayerPrefs.GetInt("switch")== 1){
            PlayerPrefs.SetInt("switch",2);
        }else if(PlayerPrefs.GetInt("switch")== 2){
            PlayerPrefs.SetInt("switch",0);
        }
    }
}
