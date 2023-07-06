using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    int maxLives = 3;
    int currentLives;
    int score = 0;

    [SerializeField]
    TMP_Text scoreText;
    
    [SerializeField]
    TMP_Text lootText;
    GameManager gameManager;

    [SerializeField]
    Image heart;

    [SerializeField]
    RectTransform heartTransform;

    [SerializeField]
    Canvas uiCanvas;

    [SerializeField]
    GameObject gameOverUI;

    Image[] heartImages;

    int offset = 25;

    private CanvasGroup canvasGroup;

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

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void HideUI()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
    }

    public void ShowUI()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
    }

    void Start()
    {
        lootText.text += " 100";
        currentLives = maxLives;
        heartImages = new Image[maxLives];
        gameManager = GameManager.Instance;
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


    // Update is called once per frame
    void Update()
    {
        if(GameSceneManager.Instance.CurrentScene == GameSceneManager.SceneState.Fort)
        {
            HideUI();
        }
        
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
            GameManager manager = GameManager.Instance;
            manager.GameOver();
            gameOverUI.gameObject.SetActive(true);
        }
    }

    public void IncreaseLives()
    {
        if (currentLives < maxLives)
        {
            
            heartImages[currentLives].gameObject.SetActive(true);
            currentLives++;
        }
    }


    


}
