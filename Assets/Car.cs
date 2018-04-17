using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float startDistance = 100f;
    [SerializeField] float startSpeed = 40f;
    [SerializeField] float maxBraking = 10f;

    float currentSpeed, currentDistance;
    bool isBraking = true;
    float pedalPosition;

	// Use this for initialization
	void Start ()
    {
        currentSpeed = startSpeed;
        currentDistance = startDistance;
	}

    void FixedUpdate()
    {
        UpdateSpeed();

        currentDistance -= currentSpeed * Time.deltaTime;
    }


    public void SetSinglePedal(float pedalPosition)
    {
        this.pedalPosition = Mathf.Clamp(pedalPosition, -1f, 1f);
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public float GetCurrentDist()
    {
        return currentDistance;
    }

    private void UpdateSpeed()
    {
        float deltaV = maxBraking * pedalPosition * Time.deltaTime;
        bool isMoving = currentSpeed > Mathf.Abs(deltaV) + Mathf.Epsilon;
        if (!isMoving)
        {
            currentSpeed = 0f;
            return;
        }

        if (pedalPosition < 0 && isMoving)
        {
            currentSpeed += deltaV;
        }
    }

}
