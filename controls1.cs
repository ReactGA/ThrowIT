using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controls1 : MonoBehaviour
{
    public GameObject end;
    public GameObject win;
    public GameObject loose;
    public GameObject gooal;
    public GameObject pausemenu;
    public Text time;
    public Text goals;
    int goalcount = 0;
    float timecounts ;
    bool stop = false;
    public underhoop hp;
    float NoOfGoals;
    float timecountsNo;
    public AudioSource click;
    public AudioSource clap;
    public Camerashake cs;
    public GameObject ball;
    [HideInInspector]
    public bool isplaying = false;
    public TrailRenderer t;
    public echoeffect e;
    
    void Start()
    {
        if(PlayerPrefs.GetInt("level") == 1){
            timecountsNo = 180f;
            NoOfGoals = 10f;
        }else if(PlayerPrefs.GetInt("level") == 2){
            timecountsNo = 150f;
            NoOfGoals = 15f;
        }
        else if(PlayerPrefs.GetInt("level") == 3){
            timecountsNo = 120;
            NoOfGoals = 20f;
        }
        timecounts = timecountsNo;
        isplaying = true;
        if(PlayerPrefs.GetInt("trail")== 0){
            t.enabled = true;
            e.enabled = false;
        }else if(PlayerPrefs.GetInt("trail")== 1){
            t.enabled = false;
            e.enabled = true;
        }else if(PlayerPrefs.GetInt("trail")== 2){
            t.enabled = false;
            e.enabled = false;
        }
    }

    
    void FixedUpdate()
    {
        timecounts -= Time.deltaTime;
        if(goalcount == NoOfGoals){
            win.SetActive(true);
            gooal.SetActive(false);
            isplaying = false;
            if (PlayerPrefs.GetInt("sd") ==1){
            clap.Play();
        }
            Invoke("endgame",3f);
        }else if(timecounts <= 0){
            timecounts = 0f;
            loose.SetActive(true);
            isplaying = false;
            Invoke("endgame",3f);
        }
        if(hp.scored == true && stop == false)
        {
            stop = true;
            goalcount +=1;
            if (PlayerPrefs.GetInt("sd") ==1){
            clap.Play();
        }
            StartCoroutine("goaltxt");
            StartCoroutine(cs.shake(2f,0.1f));
        }
        time.text = timecounts.ToString("0");
        goals.text = goalcount.ToString("0");

    }

    IEnumerator goaltxt(){
    
        gooal.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gooal.SetActive(false);
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
        isplaying = false;
        SceneManager.LoadScene(0);
    }
    void endgame(){
        win.SetActive(false);
        loose.SetActive(false);
        end.SetActive(true);
        Time.timeScale = 0f;
        stop = false;
    }
}
