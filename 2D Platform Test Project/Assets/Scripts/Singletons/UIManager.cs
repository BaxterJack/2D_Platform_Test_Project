using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    int maxLives = 3;
    int currentLives;
    int score = 0;

    PlayerManager playerManager;

    Image[] heartImages;

    int offset = 25;

    [SerializeField]
    Image heart;

    Canvas uiCanvas;
    TMP_Text scoreText;
    TMP_Text lootText;
    GameObject gameOverUI;
    RectTransform heartTransform;

    protected override void Awake()
    {
        base.Awake();
        uiCanvas = GetComponent<Canvas>();
        //HideUI();
        FindTextComponents();
        FindRectTransforms();
        DisactivateGameOverUI();

    }


    void FindTextComponents()
    {
        foreach (TMP_Text textComponent in GetComponentsInChildren<TMP_Text>())
        {
            switch (textComponent.name)
            {
                case "Text: Loot":
                    lootText = textComponent;
                    break;
                case "Text: Score":
                    scoreText = textComponent;
                    break;
            }
        }
    }

    void FindRectTransforms()
    {
        foreach (RectTransform rectTransform in GetComponentsInChildren<RectTransform>())
        {

            if (rectTransform.name == "GameOverUI")
            {
                gameOverUI = rectTransform.gameObject;
            }
            if(rectTransform.name == "HeartLocation")
            {
                heartTransform = rectTransform;
            }
        }
    }

    public void HideUI()
    {
        uiCanvas.enabled = false;
    }

    public void ShowUI()
    {
        uiCanvas.enabled = true;
        //Debug.Log("Showing UI");
    }

    void Start()
    {
        lootText.text += " 100";
        currentLives = maxLives;
        heartImages = new Image[maxLives];
        playerManager = PlayerManager.Instance;
        for (int i = 0; i < maxLives; i++)
        {
            Vector2 anchoredPosition = heartTransform.anchoredPosition;
            anchoredPosition.x += i * offset;
            InstantiateHeart(anchoredPosition, i);
        }
    }

    private void InstantiateHeart(Vector2 anchoredPosition, int index)
    {
        Image newHeart = Instantiate(heart);
        RectTransform heartRectTransform = newHeart.GetComponent<RectTransform>();
        heartRectTransform.SetParent(uiCanvas.transform, false);
        heartRectTransform.anchorMin = new Vector2(0f, 1f);
        heartRectTransform.anchorMax = new Vector2(0f, 1f);
        heartRectTransform.pivot = new Vector2(0.5f, 0.5f);
        heartRectTransform.anchoredPosition = anchoredPosition;

        heartImages[index] = newHeart;
    }

    void Update()
    {
        
        if (Input.GetKeyDown("down"))
        {
            DecreaseLives();
        }
        if (Input.GetKeyDown("up"))
        {
            IncreaseLives();
        }
    }
    public void DecreaseLives()
    {
        if(currentLives > 0)
        {
            currentLives--;
            heartImages[currentLives].gameObject.SetActive(false);

        }
        if(currentLives == 0)
        {
           playerManager.GameOver();
           ActivateGameOverUI();
        }
    }

    void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    void DisactivateGameOverUI()
    {
        gameOverUI.SetActive(false);
    }


    public void IncreaseLives()
    {
        if (currentLives < maxLives)
        {
            
            heartImages[currentLives].gameObject.SetActive(true);
            currentLives++;
        }
    }



    //void Start()
    //{
    //    lootText.text += " 100";
    //    currentLives = maxLives;
    //    heartImages = new Image[maxLives];
    //    gameManager = GameManager.Instance;
    //    for (int i = 0; i < maxLives; i++)
    //    {
    //        Vector3 pos = heartTransform.localPosition;
    //        pos.x += i * offset;
    //        InstantiateHeart(pos, i);
    //    }
    //}
    //private void InstantiateHeart(Vector3 position, int index)
    //{
    //    Image newHeart = Instantiate(heart, position, Quaternion.identity); ;
    //    newHeart.transform.SetParent(uiCanvas.transform, false);
    //    heartImages[index] = newHeart;
    //}

}
