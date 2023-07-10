using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogueManager dialogueManager;

   public float textYOffset;

    public TMP_Text textPrefab;
    TMP_Text startDialogue;
    string startDialogueText = "Press E to Talk";

    void CreateStartDialogueUI()
    {
        startDialogue = Instantiate(textPrefab);
        startDialogue.text = startDialogueText;
        startDialogue.gameObject.transform.position = GetDialogueTextPosition();
    }

    void DestroyStartDialogueUI()
    {
        if(startDialogue != null)
        {
            Destroy(startDialogue.gameObject);
        }
    }

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
        textYOffset = 0.5f;
    }


    public void TriggerDialogue()
    {
        dialogueManager.EnableCanvas();
        dialogueManager.AssignCurrentNPC(GetComponent<NPC>());
        dialogueManager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CreateStartDialogueUI();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bool isTabletOpen = TabletManager.Instance.IsTabletCanvasActive;
            if (Input.GetKey(KeyCode.E) && !isTabletOpen || dialogue.ForcedDialogue)
            {
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestroyStartDialogueUI();
            dialogueManager.DisableCanvas();
        }
    }

    Vector3 GetDialogueTextPosition()
    {
        Vector3 npcPosition = this.transform.position;
        npcPosition.y += textYOffset;
        return npcPosition;
    }
}
