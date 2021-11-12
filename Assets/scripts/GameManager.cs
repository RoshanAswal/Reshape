using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   public changing ch;
    public GameObject end,pause,play,startPanel,gamePanel,pausePanel,soundOn,soundOff;
    bool s=true;
    static int loadCount = 1;
    private void Start() {
        AdmobAds.instance.requestInterstital();
    }
    private void Awake() {
        FindObjectOfType<AudioManager>().enabled=false;
        FindObjectOfType<AudioManager>().sounds[0].volume=0.3f;
        ch.enabled=false;
        Time.timeScale=0f;
    }

    public void quiting(){
        FindObjectOfType<AudioManager>().Play("click");
        Application.Quit();
    }
    public void Starting(){
        if(s)
            FindObjectOfType<AudioManager>().Play("main");
        FindObjectOfType<AudioManager>().Play("click");
        pausePanel.SetActive(false);
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        pause.SetActive(true);
        play.SetActive(false);
        Time.timeScale=1f;
        ch.enabled=true;
    }
    public void AfterPause(){
        FindObjectOfType<AudioManager>().Play("click");
        pausePanel.SetActive(false);
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        pause.SetActive(true);
        play.SetActive(false);
        Time.timeScale=1f;
        ch.enabled=true;
    }
    public void pausing(){
        ch.enabled=false;
        Time.timeScale=0f;
        pause.SetActive(false);
        play.SetActive(true);
        pausePanel.SetActive(true);
    }
    public void Again(){
        FindObjectOfType<AudioManager>().Play("click");
        ch.enabled=true;
        end.SetActive(false);
        FindObjectOfType<AudioManager>().enabled=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void over(){
        if (loadCount % 3 == 0)  // only show ad every third time
        {
            // AdmobAds.instance.reqBannerAd();
            AdmobAds.instance.ShowInterstitialAd();
            loadCount=1;
        }
        gamePanel.SetActive(false);
        end.SetActive(true);
        Time.timeScale=0f;
        loadCount++;
        FindObjectOfType<AudioManager>().Stop("main");
        ch.enabled=false;
    }
    public void stopSound(){
        s=false;
        FindObjectOfType<AudioManager>().Stop("main");
        soundOn.SetActive(false);
        soundOff.SetActive(true);
    }
    public void PlaySound(){
        s=true;
        // FindObjectOfType<AudioManager>().enabled=true;
        soundOn.SetActive(true);
        soundOff.SetActive(false);
    }
    public void SimpleLoad(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
