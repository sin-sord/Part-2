using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Slider healthSlide;  // for the slider component in the UI for the health

    public void HurtPlayer(float thorn)
    {
        healthSlide.value -= thorn;  // the slider value will decrease by 1 each time it touches the spike
    }
}
