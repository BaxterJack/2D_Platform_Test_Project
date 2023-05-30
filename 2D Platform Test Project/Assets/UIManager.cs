using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    int lives = 3;
    int score = 0;

    [SerializeField]
    TMP_Text scoreText;
    
    [SerializeField]
    TMP_Text lootText;

    [SerializeField]
    Transform heartTransform;

    [SerializeField]
    Image heart;
//    Sprite heart;

    Transform newTransform;

    int offset = 25;

    void Start()
    { 
        lootText.text += " 100";
        newTransform = heartTransform;
        for(int i = 0; i < lives; i++)
        {
            Vector3 pos = heartTransform.position;
            pos.x += i * offset;
            Debug.Log(pos);
            newTransform.position = pos;
            Instantiate(heart, newTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            //respawn
        }
        else
        {
            lives--;
            //game over
        }
    }
}
