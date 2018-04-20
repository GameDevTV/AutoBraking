using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferControl : MonoBehaviour {

    CarStats carStats = new CarStats();

	// Use this for initialization
	void Start ()
    {
        carStats.Speed = 10;
        print(carStats.Speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
