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
    [SerializeField] Neuron.OutputFunction outputFunction;
    [Tooltip("Related to fixed braking distance")][SerializeField] float weight;
    [Tooltip("Related to speed adjustment factor")][SerializeField] float weight2;
    [Tooltip("Offset which scales weights")][SerializeField] float bias;

    [Header("For Network Control")]
    [Range(0,1f)] [SerializeField] float brakingPower = 0f;

    CarController carController;
    Rigidbody myRigidBody;
    Neuron neuron;
    bool brakingStated = false;

    // Use this for initialization
    void Start()
    {
        carController = GetComponent<CarController>();

        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.velocity = startSpeed * Vector3.forward;

        SetupSingleNeuron();
    }

    private void SetupSingleNeuron()
    {
        Neuron.NeuronSetup neuronSetup;
        neuronSetup.outputFunction = outputFunction;
        neuronSetup.bias = bias;
        neuronSetup.weight = weight;
        neuronSetup.weight2 = weight2;
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
        float input1 = frontBumperRadar.GetDistance();
        float neuralOutput = neuron.GetOutput(input1, myRigidBody.velocity.z);
        brakingPower = neuralOutput;
        if (brakingPower > 0 && !brakingStated)
        {
            brakingStated = true;
        }
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
