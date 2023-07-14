using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Log : MonoBehaviour
{
    Vector3 logOffset = new Vector3(0, 0.2f, 0);

    GameObject player = null;
    TMP_Text pickupDialogue;
    string pickUp = "Press E to pick up Log";
    public float textYOffset = 0.5f;
    public TMP_Text textPrefab;
    bool isPlayerInRange = false;
    bool isLogCarried = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player == null)
            {
                player = collision.gameObject;
            }
            
            CreatePickupText();
            isPlayerInRange = true;
        }
    }


    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupLog();

        }
        if(isLogCarried && Input.GetKeyDown(KeyCode.R))
        {
            DropLog();
        }
    }

    void PickupLog()
    {
        isLogCarried = true;
        transform.SetParent(player.transform);
        transform.localPosition = logOffset;
        ApplyPhysics(true);
    }

    void ApplyPhysics(bool isPhysicsDisabled)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = isPhysicsDisabled;
    }

    void DropLog()
    {
        isLogCarried = false;
        transform.SetParent(null);
        ApplyPhysics(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestroyPickupText();
            isPlayerInRange = false;
        }
    }
    void CreatePickupText()
    {
        pickupDialogue = Instantiate(textPrefab);
        pickupDialogue.text = pickUp;
        pickupDialogue.gameObject.transform.position = GetDialogueTextPosition();
    }

    void DestroyPickupText()
    {
        if (pickupDialogue != null)
        {
            Destroy(pickupDialogue.gameObject);
        }
    }



    Vector3 GetDialogueTextPosition()
    {
        Vector3 npcPosition = this.transform.position;
        npcPosition.y += textYOffset;
        return npcPosition;
    }
}
