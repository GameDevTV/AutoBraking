using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AEB : MonoBehaviour {

    [SerializeField] Radar frontBumperRadar;

    CarController carController;
    Rigidbody myRigidBody;

	// Use this for initialization
	void Start ()
    {
        carController = GetComponent<CarController>();
        myRigidBody = GetComponent<Rigidbody>();

        myRigidBody.velocity = 20f * Vector3.forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool drivingForward = myRigidBody.velocity.z > 0;
        if (!drivingForward) { return; }

        float distanceToObstacle = frontBumperRadar.GetDistance();
        print("Obstacles detected at: " + distanceToObstacle);
        if (distanceToObstacle > 70f) // todo parameterise
        {
            carController.Move(0, 1f, 0, 0);
        }
        else if (distanceToObstacle < 40f)
        {
            carController.Move(0, 0, -1f, 0);
        }
    }
}
