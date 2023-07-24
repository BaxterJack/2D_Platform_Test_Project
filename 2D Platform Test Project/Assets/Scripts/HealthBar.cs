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

    Canvas healthCanvas;


    private void Start()
    {
        SetMaxHealth();
        healthCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (slider.value <= 0.0f)
        {
            DisableHealthCanvas();
        }
    }



    public void DisableHealthCanvas()
    {
        healthCanvas.enabled = false;
    }

    public void EnableHealthCanvas()
    {
        healthCanvas.enabled = true;
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        SetHealth(currentHealth);
        StartCoroutine(ApplyRedDamageEffect());
    }

    IEnumerator ApplyRedDamageEffect()
    {
        SpriteRenderer spriteRenderer = GetComponentInParent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.35f);
        spriteRenderer.color = Color.white;
    }

    public bool HasNoHealth()
    {
        return currentHealth <= 0;
    }
}
