using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

    [SerializeField] Text speedText, distText, scoreText;
    [SerializeField] Car carToDisplay;

    Game game;

	// Use this for initialization
	void Start ()
    {
        game = FindObjectOfType<Game>();    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        speedText.text = carToDisplay.GetCurrentSpeed().ToString();
        distText.text = carToDisplay.GetCurrentDist().ToString();
        scoreText.text = game.GetScore().ToString();
	}
}
