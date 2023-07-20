using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        HealthBar health = collision.gameObject.GetComponentInChildren<HealthBar>();
        if(health != null)
        {
            health.TakeDamage(200);
        }
    }
}
