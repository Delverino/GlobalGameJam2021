using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class Limb : MonoBehaviour
{
    public enum LimbType
    {
        Left_Arm,
        Left_Leg,
        Right_Leg,
        Right_Arm
    }
    public LimbType limbType;

    public float maxMotorSpeed;

    private Player player;
    private HingeJoint2D joint;
    private JointAngleLimits2D defaultLimits;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(0);
        joint = GetComponent<HingeJoint2D>();
        defaultLimits = joint.limits;
    }

    void FixedUpdate()
    {
        if (player.GetButton(limbType.ToString().Replace('_', ' ')))
        {
            float angle = joint.jointAngle;
            if (angle < 5f && angle > -5f)
            {
                JointAngleLimits2D limits = new JointAngleLimits2D();
                limits.max = 0f;
                limits.min = 0f;
                joint.limits = limits;
            }
            JointMotor2D motor = new JointMotor2D();
            float mid = (defaultLimits.min + defaultLimits.max) / 2f;
            float sign = Mathf.Sign(angle - mid);
            motor.motorSpeed = -maxMotorSpeed * sign;
            motor.maxMotorTorque = 10000f;
            joint.motor = motor;
            joint.useMotor = true;
        }
        else
        {
            joint.useMotor = false;
            joint.limits = defaultLimits;
        }
    }
}
