using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torso : MonoBehaviour
{
    public float torque;
    public float maxAngularVelocity;

    private Rigidbody2D body;
    private Player player;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        player = ReInput.players.GetPlayer(0);
    }

    void FixedUpdate()
    {
        body.AddTorque(torque * -1f * player.GetAxis("Rotate") * Time.fixedDeltaTime);

        body.angularVelocity = Mathf.Clamp(body.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    }
}
