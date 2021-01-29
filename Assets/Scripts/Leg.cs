using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    public FixedJoint2D joint;

    public KeyCode key;

    public float response;

    public float targetY;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(key))
        {
            targetY = 1;
        }
        else
        {
            targetY = 0;
        }

        joint.anchor = new Vector2(0, Mathf.Lerp(joint.anchor.y, targetY, response));
    }
}
