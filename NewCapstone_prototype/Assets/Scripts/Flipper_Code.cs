using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper_Code : MonoBehaviour
{
    private new HingeJoint2D hingeJoint;
    private JointMotor2D hingeJM;

    public float RestPosition;
    public float ActivePosition;

    public string InputKey;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        hingeJM = hingeJoint.motor;

    }

    void Update()
    {
        FlipperActive();
    }

    void FlipperActive()
    {
        if (Input.GetAxis(InputKey) == 1)
        {
            hingeJM.motorSpeed = ActivePosition * 10;
            hingeJoint.motor = hingeJM;
            //Debug.Log("input is detected");
        }
        else
        {
            hingeJM.motorSpeed = RestPosition * 10;
            hingeJoint.motor = hingeJM;
            //Debug.Log("else is active");
        }

    }
}

    //public float upperAngle;
    //public float lowAngle;
    //public float rotateSpeed;
    //public float restPosition;
    //public float activePosition;
    //
    //public string InputName;
    //
    //public HingeJoint2D hingejoint;
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    hingejoint = GetComponent<HingeJoint2D>();
    //    hingejoint.useMotor = true;
    //    hingejoint.useLimits = true;
    //
    //    rotateSpeed = hingejoint.motor.motorSpeed;
    //    Debug.Log("motorspeed is access");
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    //var motorComp = hingejoint.motor;
    //    //motorComp.motorSpeed = restPosition;
    //    //var motorComp = hinges.motor;
    //    //motorComp.motorSpeed = restPosition;
    //
    //
    //    //var springComp = new HingeJoint();
    //    //springComp.motor.motorSpeed = rotateSpeed;
    //    //springComp.damper = flipperDamper;
    //
    //    if (Input.GetAxis(InputName) == 1)
    //    {
    //        rotateSpeed = activePosition;
    //        
    //        //springComp.targetPosition = pressedPosition;
    //
    //    }
    //    else
    //    {
    //        rotateSpeed = restPosition;
    //    }
    //    //else
    //    //{
    //    //    //springComp.targetPosition = restPosition;
    //    //}
    //
    //    //hinges.spring = springComp;
    //    //hinges.useLimits = true;
    //}
//}
