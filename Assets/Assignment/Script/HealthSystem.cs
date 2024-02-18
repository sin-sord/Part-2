using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Slider healthSlide;

    public void HurtPlayer(float thorn)
    {
        healthSlide.value -= thorn;
    }
}
