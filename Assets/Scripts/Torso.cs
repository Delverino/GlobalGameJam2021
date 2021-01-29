﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{
    public Rigidbody2D body;
    public float torque;

    public float maxAngularVelocity;

    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(key))
        {
            body.AddTorque(torque * Time.fixedDeltaTime);
        }
        else
        {
            body.AddTorque(-torque * Time.fixedDeltaTime);
        }

        body.angularVelocity = Mathf.Clamp(body.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    }
}
