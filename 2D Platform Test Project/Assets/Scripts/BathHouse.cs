using Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BathHouse : MonoBehaviour
{
    TMP_Text dropDialogue;
    public TMP_Text textPrefab;
    string dropLog = "Press R to drop the Log";
    Vector3 textOffset = new Vector3(1.5f, 1.5f, 0);
    GameManager gameManager;
    public List<GameObject> constructionStages;

    void CreatePickupText()
    {
        dropDialogue = Instantiate(textPrefab);
        dropDialogue.text = dropLog;
        dropDialogue.gameObject.transform.position = GetDialogueTextPosition();
    }
    Vector3 GetDialogueTextPosition()
    {
        Vector3 logPos = this.transform.position;
        logPos += textOffset;
        return logPos;
    }
    void DestroyPickupText()
    {
        if (dropDialogue != null)
        {
            Destroy(dropDialogue.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Log log = collision.gameObject.GetComponentInChildren<Log>();
            if(log != null)
            {
                CreatePickupText();
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            DestroyPickupText();
        }
    }

    void Start()
    {
        gameManager = GameManager.Instance;
        if (!gameManager.IsBathHouseConstructed())
        {
            constructionStages = new List<GameObject>();
            foreach (Transform child in this.transform)
            {
                if (child.name == "FLOOR 2" || child.name == "ROOF")
                {
                    constructionStages.AddRange(child.GetComponentsInChildren<Transform>(true)
                        .Where(t => t != child)
                        .Select(t => t.gameObject));
                }
            }
        }
    }

    IEnumerator ActivateConstructionStagesCoroutine()
    {
        PlayConstructionFX();
        for (int i = 0; i < constructionStages.Count; i++)
        {
            constructionStages[i].SetActive(true);
            yield return new WaitForSeconds(0.1f); 
        }

        StopConstructionFX();
        gameManager.BathHouseConstructed = true;
        gameManager.InstatiateLepidina();


    }

    void PlayConstructionFX()
    {
        AudioManager.Instance.PlaySound("Construction");
    }

    void StopConstructionFX()
    {
        AudioManager.Instance.StopSound("Construction");
    }
    public void ActivateConstructionStages()
    {
        StartCoroutine(ActivateConstructionStagesCoroutine());
    }

    void Update()
    {

    }


}
