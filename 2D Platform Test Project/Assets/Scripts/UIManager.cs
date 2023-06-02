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

    void Start()
    { 
        lootText.text += " 100";
        currentLives = maxLives;
        heartImages = new Image[maxLives];
        gameManager = GameManager.Instance;
        for (int i = 0; i < maxLives; i++)
        {
            Vector3 pos = heartTransform.localPosition;
            pos.x += i * offset;
            InstantiateHeart(pos, i);
        }
    }
    private void InstantiateHeart(Vector3 position, int index)
    {
        Image newHeart = Instantiate(heart, position, Quaternion.identity);;
        newHeart.transform.SetParent(uiCanvas.transform, false);
        heartImages[index] = newHeart;
    }


    // Update is called once per frame
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
