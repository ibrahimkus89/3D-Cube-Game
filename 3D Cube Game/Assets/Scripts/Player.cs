using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float dodgeSpeed;
    float xInput;
    void Start()
    {
        
    }

    
    void Update()
    {
       xInput = Input.GetAxis("Horizontal");

        transform.Translate(xInput*dodgeSpeed*Time.deltaTime,0,0);
    }
}