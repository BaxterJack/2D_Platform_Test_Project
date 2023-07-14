using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BathHouse : MonoBehaviour
{
    GameManager gameManager;
    public List<GameObject> constructionStages;
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
    }

    void PlayConstructionFX()
    {
        AudioManager.Instance.PlaySound("Construction");
    }

    void StopConstructionFX()
    {
        AudioManager.Instance.StopSound("Construction");
    }
    void ActivateConstructionStages()
    {
        StartCoroutine(ActivateConstructionStagesCoroutine());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ActivateConstructionStages();
        }
    }
}
