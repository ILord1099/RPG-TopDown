using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    
    private Rigidbody2D rig;
    public float speed;
    private Vector2 _direction;

    public Vector2 direction // faz com que acesse valores em outra classe 
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + _direction * speed*Time.fixedDeltaTime);
    }
}
