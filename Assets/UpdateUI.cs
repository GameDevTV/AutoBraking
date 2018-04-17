using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class UpdateUI : MonoBehaviour {

    [SerializeField] Text speedText, distText, scoreText;
    [SerializeField] CarController carController;

    void Update()
    {
        speedText.text = carController.CurrentSpeed.ToString();
    }

}
