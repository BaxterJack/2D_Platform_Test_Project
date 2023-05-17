using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Point : MonoBehaviour
{
    [SerializeField]
    public float attackRange = 0.4f;

    float point;

    float horizontalMove = 0.0f;

    void Start()
    {
        point = this.transform.localPosition.x;
    }


    void Update()
    {
        Rigidbody2D rigidbody2D = GetComponentInParent<Rigidbody2D>();
        horizontalMove = rigidbody2D.velocity.x;
        if (horizontalMove > 0.0f)
        {
            InvertAttackPosition(-1);
        }
        else if(horizontalMove < 0.0f)
        {
            InvertAttackPosition(1);
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }

    public void InvertAttackPosition(int inversion)
    {
        Vector2 localPoint = this.transform.localPosition;
        localPoint.x = inversion * point;
        this.transform.localPosition = localPoint;
    }
}
