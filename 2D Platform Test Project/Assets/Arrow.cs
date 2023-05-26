using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
//    [SerializeField]
    GameObject player;
    private Rigidbody2D rigidBody;
    public float arrowSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); // Find better way to do this!!!
        Vector2 direction;
        direction.x = player.transform.position.x - transform.position.x;
        direction.y = 0;
        rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * arrowSpeed;
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
           
            player.GetComponentInChildren<HealthBar>().TakeDamage(20);


            //rigidBody.velocity = new Vector2(0, 0);
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            gameObject.transform.SetParent(player.transform, true);
            //player.transform.SetParent(this.gameObject.transform);
            //gameObject.transform.parent = player.transform;
        }
    }

}
