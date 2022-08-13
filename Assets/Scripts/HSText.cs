using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HSText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Highscore: "+PlayerPrefs.GetInt("hs", 0);
    }

    
}
