using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

    [SerializeField] Text speedText;
    [SerializeField] Car carToDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        speedText.text = carToDisplay.GetCurrentSpeed().ToString();
	}
}
