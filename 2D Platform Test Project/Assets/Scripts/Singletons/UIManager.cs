using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static Cinemachine.DocumentationSortingAttribute;

public class UIManager : Singleton<UIManager>
{

    int score = 0;

//    PlayerManager playerManager;

    Image[] heartImages;

    int offset = 25;

    [SerializeField]
    Image heart;

    Canvas uiCanvas;
    TMP_Text scoreText;
    TMP_Text objective;
    TMP_Text tip;
    GameObject gameOverUI;
    RectTransform heartTransform;
    GameObject continueButton;
    bool isGameOverActive = false;

    protected override void Awake()
    {
        base.Awake();
        uiCanvas = GetComponent<Canvas>();
        //HideUI();
        FindTextComponents();
        FindRectTransforms();
        DisactivateGameOverUI();
        FindContinueButton();
    }

    public void AddToScore(float points)
    {
        score += (int)points;
        UpdateScore();
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int points)
    {
        score += points;
        UpdateScore();
    }

    void FindContinueButton()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            switch (b.name)
            {
                case "ContinueButton":
                    continueButton = b.gameObject;
                    continueButton.SetActive(false);
                    break;
            }
        }
    }

    public TMP_Text Objective
    {
        get { return objective; }
        set { objective = value; }
    }

    public TMP_Text Tip
    {
        get { return tip; }
        set { tip = value; }
    }

    public GameObject ContinueButton 
    {
        get { return continueButton; }
        set { continueButton = value; }
    }

    void FindTextComponents()
    {
        foreach (TMP_Text textComponent in GetComponentsInChildren<TMP_Text>())
        {
            switch (textComponent.name)
            {
                case "Text: Score":
                    scoreText = textComponent;
                    break;
                case "Objective":
                    objective = textComponent;
                    break;
                case "Tip":
                    tip = textComponent;
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
    }

    void UpdateScore()
    {
        string scoreField = "Score: " + score.ToString();
        scoreText.text = scoreField;
    }

    void Start()
    {
        UpdateScore();
        int lives = PlayerManager.Instance.currentLives;
        heartImages = new Image[lives];
        for (int i = 0; i < lives; i++)
        {
            Vector2 anchoredPosition = heartTransform.anchoredPosition;
            anchoredPosition.x += i * offset;
            InstantiateHeart(anchoredPosition, i);
        }
    }

    public void ResetLivesUI()
    {
        foreach(Image image in heartImages)
        {
            image.gameObject.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameOverActive)
            {
                DisactivateGameOverUI();
            }
            else
            {
                ActivateGameOverUI();
            }
        }
    }


    public void RemoveHeart(int currentLives)
    {
        heartImages[currentLives].gameObject.SetActive(false);
    }

    public void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
        isGameOverActive = true;
    }

    public void DisactivateGameOverUI()
    {
        gameOverUI.SetActive(false);
        isGameOverActive = false;
    }


}
