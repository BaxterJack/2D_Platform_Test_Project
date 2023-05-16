using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    [SerializeField]
    Slider slider;

    void Update()
    {
        if (slider.value <= 0.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;  
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
