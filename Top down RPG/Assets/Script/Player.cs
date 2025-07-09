using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    private Vector2 direction;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + direction * speed*Time.fixedDeltaTime);
    }
}
