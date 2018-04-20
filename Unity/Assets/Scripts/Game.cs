using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] float timeScale = 1f;
    [SerializeField] float distanceRemaining;

    float score;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = timeScale;
    }

    public float GetScore()
    {
        return score;
    }

    void Update()
    {
        var carSpeed = FindObjectOfType<Car>().GetCurrentSpeed(); // todo think about instances
        if (carSpeed <= Mathf.Epsilon)
        {
            score = CalculateScore();
        }
    }

    private float CalculateScore()
    {
        var endDist = FindObjectOfType<Car>().GetCurrentDist();

        if (endDist < 0)
        {
            return 0; // crashed
        }
        else
        {
            return 1 / endDist;
        }
    }
}
