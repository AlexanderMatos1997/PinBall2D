using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper_Code : MonoBehaviour
{
    private new HingeJoint2D hingeJoint;
    private JointMotor2D hingeJM;

    public float RestPosition;
    public float ActivePosition;

    public bool audioOnce = false;
    AudioSource flipperAudio;

    public string InputKey;

    void Start()
    {
        flipperAudio = GetComponent<AudioSource>();
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
            if (!audioOnce)
            {
                flipperAudio.Play();
                //FindObjectOfType<AudioManager>().Play("Flipper_SoundEffect");
                audioOnce = true;
            }
            //Debug.Log("input is detected");
        }
        else
        {
            hingeJM.motorSpeed = RestPosition * 10;
            hingeJoint.motor = hingeJM;
            audioOnce = false;
            //Debug.Log("else is active");
        }

    }
}
