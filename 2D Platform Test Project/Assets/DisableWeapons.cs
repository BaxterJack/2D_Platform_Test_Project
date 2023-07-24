using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWeapons : MonoBehaviour
{
    BoxCollider2D weaponsCollider;

    private void Start()
    {
        weaponsCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager.Instance.CanAttack = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerManager.Instance.CanAttack = true;
    }
}
