using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class ScreenControl : MonoBehaviour, ICarControl {

    [SerializeField] Slider pedalSlider;

    CarController carController;
    float pedalPos;

	// Use this for initialization
	void Start ()
    {
        carController = GetComponent<CarController>();
	}

    void Update()
    {
        print(carController.AccelInput + " " + carController.BrakeInput);
        if (pedalPos >= 0)
        {
            carController.Move(0f, pedalPos, 0f, 0f);
        }
        else
        {
            carController.Move(0f, 0f, pedalPos, 0f);
        }
    }

    public void SinglePedalPosition(float pedalPos)
    {
        this.pedalPos = pedalPos;
    }
}
