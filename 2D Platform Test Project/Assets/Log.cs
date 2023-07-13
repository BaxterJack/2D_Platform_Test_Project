using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Log : MonoBehaviour
{
    TMP_Text pickupDialogue;
    string pickUp = "Press E to pick up Log";
    public float textYOffset = 0.5f;
    public TMP_Text textPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CreatePickupText();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pickup log");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestroyPickupText();
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
