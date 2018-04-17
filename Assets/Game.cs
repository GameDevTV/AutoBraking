using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField] [Range(1f, 10f)] float timeScale = 1f;
    [SerializeField] float distanceRemaining;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = timeScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StoppedWithDistanceRemaining(float distanceRemaining)
    {
        this.distanceRemaining = distanceRemaining;
    }
}
