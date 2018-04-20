using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenControl : MonoBehaviour, ICarControl
{
    [SerializeField] Slider pedalSlider;

    public void SetPedalPos(float pedalPos)
    {
        GetComponent<CarControlWrapper>().SetPedalPos(pedalPos);
    }
}
