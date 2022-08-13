using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GOSUpdateScore : MonoBehaviour
{
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] TextMeshProUGUI text1TMP;
    [SerializeField] TextMeshProUGUI text2TMP;
 

    // Start is called before the first frame update
    void Start()
    {
        text1TMP.text = text1.text;
        text2TMP.text = text2.text;
    }


}
