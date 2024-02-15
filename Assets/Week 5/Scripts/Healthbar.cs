using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("HealthStat", slider.value);
        SendMessage("HealthValue", slider.value, SendMessageOptions.DontRequireReceiver);
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
        HealthSave();
    }

    public void HealthSave()
    {
        PlayerPrefs.SetFloat("HealthStat", slider.value);
    }

}
