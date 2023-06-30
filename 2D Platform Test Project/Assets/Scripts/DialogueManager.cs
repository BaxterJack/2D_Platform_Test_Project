using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    [SerializeField]
    Canvas dialogueCanvas;

    void Start()
    {
        sentences = new Queue<string>();
        
    }

    protected override void Awake()
    {
        base.Awake();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            dialogueCanvas.gameObject.SetActive(false);
            return;
        }
        string sentence = sentences.Dequeue();
        //dialogueText.text = senetence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
     
        Debug.Log("End of Conversation.");
    }
}
