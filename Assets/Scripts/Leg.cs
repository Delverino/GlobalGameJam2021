using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class Leg : MonoBehaviour
{
    public FixedJoint2D joint;

    public enum LimbType
    {
        Left_Arm,
        Left_Leg,
        Right_Leg,
        Right_Arm
    }
    public LimbType limbType;

    public float response;

    public float targetY;

    private Player player;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetButton(limbType.ToString().Replace('_', ' ')))
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
