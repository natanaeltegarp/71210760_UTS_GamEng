using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float kecepatan;
    public string axis;
    public float tepiKanan;
    public float tepiKiri;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    float gerak = Input.GetAxis(axis)*kecepatan*Time.deltaTime;
    float nextPos = transform.position.x + gerak;
    if(nextPos > tepiKanan){
        gerak = 0;
    }
    if(nextPos < tepiKiri){
        gerak = 0;
    }
    transform.Translate(gerak, 0, 0);
    }
}