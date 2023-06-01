using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    [SerializeField]
    Slider slider;

    [SerializeField]
    public int maxHealth = 40;
    private int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (slider.value <= 0.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SetMaxHealth()
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        currentHealth = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    //public void SetCurrentHealth(int health)
    //{
    //    currentHealth = health;
    //    slider.value = health;
    //}




    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        SetHealth(currentHealth);

    }

    public bool HasNoHealth()
    {
        return currentHealth <= 0;
    }
}
