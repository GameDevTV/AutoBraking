using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarControlWrapper : MonoBehaviour, ICarControl {
    
    CarController carController;
    float pedalPos;

    // Use this for initialization
    void Start()
    {
        carController = GetComponent<CarController>();
    }

    void Update()
    {
        if (pedalPos >= 0)
        {
            carController.Move(0f, pedalPos, 0f, 0f);
        }
        else
        {
            carController.Move(0f, 0f, pedalPos, 1f);
        }
    }

    public void SetPedalPos(float pedalPos)
    {
        this.pedalPos = pedalPos;
    }

    public float GetSpeed()
    {
        return carController.CurrentSpeed;
    }
}
