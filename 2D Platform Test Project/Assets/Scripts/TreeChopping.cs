using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChopping : MonoBehaviour
{
    float treeHealth;
    Animator animator;
    [SerializeField]
    GameObject log;
    bool isTreeChopped = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        treeHealth = 100f;
    }

    private void Update()
    {
        if(treeHealth <= 0 && !isTreeChopped)
        {
            TreeFallAnimation();
            isTreeChopped = true;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            treeHealth = 0;
        }
    }
    public void TakeDamage()
    {
        treeHealth -= 100;
    }

    void TreeFallAnimation()
    {
        animator.SetTrigger("IsChopped");
        PlaySoundFX();
    }

    void DestroyTree()
    {
        Destroy(gameObject, 5);
    }

    void SpawnLog()
    {
        GameObject instantiatedLog = Instantiate(log, transform.position, Quaternion.identity);
        instantiatedLog.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        DestroyTree();
    }

    void PlaySoundFX()
    {
        AudioManager.Instance.PlaySound("TreeFall");
    }
}
