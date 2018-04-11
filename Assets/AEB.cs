using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEB : MonoBehaviour {

    [SerializeField] Radar frontBumperRadar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(frontBumperRadar.GetDistance()); 
	}
}
