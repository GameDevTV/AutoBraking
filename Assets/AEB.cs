using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AEB : MonoBehaviour
{    
    [SerializeField] float testSpeed = 40f;

    [Header("For Network Control")]
    [Range(0,1f)] [SerializeField] float brakingPower = 0f;

    CarController carController;
    Rigidbody myRigidBody;

	// Use this for initialization
	void Start ()
    {
        carController = GetComponent<CarController>();
        myRigidBody = GetComponent<Rigidbody>();

        myRigidBody.velocity = testSpeed * Vector3.forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (myRigidBody.velocity.z < 2f)
        {
            carController.Move(0, 0, -1f, 1f); // apply handbrake
            return;
        }

        if (brakingPower < Mathf.Epsilon)
        {
            MaintainTestSpeed();
        }
        else
        {
            carController.Move(0, 0, -brakingPower, 0);
        }
    }

    private void MaintainTestSpeed()
    {
        if (myRigidBody.velocity.z < testSpeed)
        {
            carController.Move(0, .2f, 0, 0);
        }
        else if (myRigidBody.velocity.z > testSpeed)
        {
            carController.Move(0, 0, .2f, 0);
        }
    }
}
