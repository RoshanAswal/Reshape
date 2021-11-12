using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public bool htrue=false;
    private float temp=0f;
    public Text score;
    public Text highscore;
    bool ins=false,insShow=true,showOnce=true;
    public Text myscore;
    public GameObject congo,instruction;

    private void Start() {
        htrue=false;
        highscore.text=PlayerPrefs.GetFloat("Highscore",0).ToString("0");  
        if(PlayerPrefs.GetFloat("Highscore")>11.5f){
            showOnce=false;
        }
    }

    void Update()
    {
        temp+=1*Time.deltaTime;
        score.text=temp.ToString("0");
        myscore.text=temp.ToString("0");
        if(showOnce){
            if(ins){
            if(Input.touchCount>0){
                insShow=false;
                instruction.SetActive(false);
            }
            }
            if(temp>9.5 && temp<10){
                insShow=true;
            }
            if(temp>5 && temp<12 && insShow){
                ins=true;
                instruction.SetActive(true);
            }
        }

        if(PlayerPrefs.GetFloat("Highscore",0)<temp){
            if(temp>20){
                congo.SetActive(true);
                Invoke("HighScoreDisplay",2f);
            }
            PlayerPrefs.SetFloat("Highscore",temp);
            highscore.text=temp.ToString("0");
            htrue=true;
        }
    }
    void HighScoreDisplay(){
        congo.SetActive(false);
    }
}
