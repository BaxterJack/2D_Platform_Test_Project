using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Point : MonoBehaviour
{
    [SerializeField]
    public float attackRange = 0.4f;


    void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }

}
