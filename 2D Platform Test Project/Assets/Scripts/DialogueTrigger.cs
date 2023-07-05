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
   GameObject dialogueText;
   public float textYOffset;



    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
    }


    public void TriggerDialogue()
    {
        dialogueCanvas.gameObject.SetActive(true);
        dialogueManager.AssignCurrentNPC(GetComponent<NPC>());
        dialogueManager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetTextPosition();
            dialogueText.gameObject.SetActive(true);   
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bool isTabletOpen = TabletManager.Instance.IsTabletCanvasActive;
            if (Input.GetKey(KeyCode.E) && !isTabletOpen)
            {
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogueText.gameObject.SetActive(false);
            dialogueCanvas.gameObject.SetActive(false);
        }
    }

    void SetTextPosition()
    {
        Vector2 npcPosition = this.transform.position;
        npcPosition.y += textYOffset;
        dialogueText.transform.position = npcPosition;
    }
}
