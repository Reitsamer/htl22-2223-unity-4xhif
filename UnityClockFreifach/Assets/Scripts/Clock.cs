using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TMPro.TextMeshProUGUI myText;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DateTime.Now.ToString("HH:mm:ss"));
        myText.text = DateTime.Now.ToString("HH:mm:ss");
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = DateTime.Now.ToString("HH:mm:ss");
    }

    public void OnStartButtonClicked()
    {
        
    }
}
