using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float dodgeSpeed;
    public float maxX;
    float xInput;
    void Start()
    {
        
    }

    
    void Update()
    {
       xInput = Input.GetAxis("Horizontal");

        transform.Translate(xInput*dodgeSpeed*Time.deltaTime,0,0);

       float limitedX = Mathf.Clamp(transform.position.x,-maxX,maxX);
        transform.position = new Vector3(limitedX,transform.position.y,transform.position.z);
    }
}
