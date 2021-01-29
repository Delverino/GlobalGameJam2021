using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class Torso : MonoBehaviour
{
    public Rigidbody2D body;
    public float torque;

    public float maxAngularVelocity;

    private Player player;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddTorque(torque * -1f * player.GetAxis("Rotate") * Time.fixedDeltaTime);

        body.angularVelocity = Mathf.Clamp(body.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    }
}
