using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAudioDestroy : MonoBehaviour
{
    public static ForAudioDestroy instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
     
    }

}
