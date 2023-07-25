using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnabled : MonoBehaviour
{
    BoxCollider2D weaponsCollider;

    private void Start()
    {
        weaponsCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerManager.Instance.CanAttack = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerManager.Instance.CanAttack = false;
        }
        
    }
}
