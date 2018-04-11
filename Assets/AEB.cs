using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AEB : MonoBehaviour
{
    [SerializeField] Radar frontBumperRadar;
    [SerializeField] float startSpeed = 40f;

    [Header("Network Training")]
    [SerializeField] Neuron.TransferType transferType;
    [SerializeField] float weight;
    [SerializeField] float bias;

    [Header("For Network Control")]
    [Range(0,1f)] [SerializeField] float brakingPower = 0f;

    CarController carController;
    Rigidbody myRigidBody;
    Neuron neuron;

    // Use this for initialization
    void Start()
    {
        carController = GetComponent<CarController>();

        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.velocity = startSpeed * Vector3.forward;

        Neuron.NeuronSetup neuronSetup;
        neuronSetup.transferType = transferType;
        neuronSetup.bias = bias;
        neuronSetup.weight = weight;
        neuron = new Neuron(neuronSetup);
    }

    // Update is called once per frame
    void Update ()
    {
        DisengageBelowSetSpeed(3f);
        CalculateBrakingPower();
        carController.Move(0, 0, -brakingPower, 0);
    }

    private void CalculateBrakingPower()
    {
        float neuralInput = frontBumperRadar.GetDistance();
        float neuralOutput = neuron.GetOutput(neuralInput);
        brakingPower = neuralOutput;
    }

    private void DisengageBelowSetSpeed(float setSpeed)
    {
        if (myRigidBody.velocity.z < setSpeed)
        {
            carController.Move(0, 0, -1f, 1f); // apply handbrake
            Destroy(this);
        }
    }
}
