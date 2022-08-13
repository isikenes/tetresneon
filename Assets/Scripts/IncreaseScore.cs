using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IncreaseScore : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text text2;
    int score = 0;
    // Start is called before the first frame update
    private void Start()
    {
        text2.text = "HIGHSCORE: " + PlayerPrefs.GetInt("hs", 0);
    }

    public void IncraseScore()
    {
        score++;
        text.text = "Lines: " + score/10;
        int s = score / 10;
        if(s>PlayerPrefs.GetInt("hs",0))
        {
            PlayerPrefs.SetInt("hs", score / 10);
            text2.text = "HIGHSCORE: " + (score / 10);
        }
    }
}
