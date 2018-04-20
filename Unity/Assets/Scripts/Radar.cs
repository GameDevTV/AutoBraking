using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    [SerializeField] float maxRange = 250f;

    public float GetDistance()
    {
        RaycastHit hitInfo = new RaycastHit();

        Physics.Raycast(
            transform.position,
            Vector3.forward,
            out hitInfo,
            maxRange // todo paramaterise or tie to bumper cam
        ); // todo filter for obstacle layer

        return(hitInfo.distance);
	}
}
