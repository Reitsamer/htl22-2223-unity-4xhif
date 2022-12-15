using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxController : MonoBehaviour
{
    private Vector3 lastCamPostion;
    public float speed;
    [SerializeField] private Transform canvas;
    [SerializeField] private RawImage[] backgrounds;
    [SerializeField] private float parallaxEffect = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        lastCamPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float dist = transform.position.x - lastCamPostion.x;
        float xPosition = transform.position.x;
        canvas.position = new Vector3(xPosition, canvas.position.y, canvas.position.z);
        
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Rect current = backgrounds[i].uvRect;
            current.x += dist * speed * (float)Math.Pow(parallaxEffect, backgrounds.Length - i);
            backgrounds[i].uvRect = current;
        }

        lastCamPostion = transform.position;
    }
}
