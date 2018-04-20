using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class UpdateUI : MonoBehaviour {

    [SerializeField] Text speedText, distText, scoreText;
    [SerializeField] CarController carController;
    [SerializeField] Slider pedalSlider;

    void Update()
    {
        speedText.text = Mathf.RoundToInt(carController.CurrentSpeed).ToString();
        if (carController.AccelInput > 0)
        {
            pedalSlider.value = carController.AccelInput;
        }
        else
        {
            pedalSlider.value = -carController.BrakeInput;
        }
    }

}
