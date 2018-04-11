using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] GameObject explosionSquib;

    void OnCollisionEnter(Collision collision)
    {
        explosionSquib.gameObject.SetActive(true);
    }
}
