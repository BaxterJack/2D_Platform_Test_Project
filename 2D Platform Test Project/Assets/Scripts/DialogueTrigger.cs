using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogueManager dialogueManager;
    [SerializeField]
    Canvas dialogueCanvas;

    [SerializeField]
    GameObject player;




    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
    }


    public void TriggerDialogue()
    {
        dialogueCanvas.gameObject.SetActive(true);
        dialogueManager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            dialogueCanvas.gameObject.SetActive(false);
        }
    }
}
