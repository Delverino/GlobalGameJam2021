using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{
    public Rigidbody2D _body;
    public float _torque;

    public KeyCode _key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            _body.AddTorque(_torque);
        }
        else
        {
            _body.AddTorque(-_torque);
        }
    }
}
