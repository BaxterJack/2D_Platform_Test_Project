using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;
using TMPro;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [FoldoutGroup("Reference")]
        public Animator animator;

        [FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        [FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
        }

        [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }

        /////////
        ArtefactCanvasManager artefactCanvasManager;
        public Artefact artefact;
        public float textYOffset;
        public TMP_Text textPrefab;
        TMP_Text openChest;
        string openChestText = "Press E to Open";
        bool isInRange = false;
        private void Start()
        {
            artefactCanvasManager = ArtefactCanvasManager.Instance;
        }
        void OpenChest()
        {
           IsOpened = true;
           artefactCanvasManager.OpenCanvas(artefact);
           artefactCanvasManager.CurrentChest = this;
        }

        public void CollectChest()
        {
            IsOpened = false;
            DestroyOpenChestText();
            AudioManager.Instance.PlaySound("CloseChest");
            Destroy(this.gameObject, 0.5f);

            
        }

        private void Update()
        {
            if(isInRange && Input.GetKeyDown(KeyCode.E))
            {
                
                if (!isOpened)
                {
                    ArtefactCanvasManager.Instance.AddArtefact(artefact);
                }
                OpenChest();
            }
        }

        void CreateOpenChestText()
        {
            openChest = Instantiate(textPrefab);
            openChest.text = openChestText;
            Vector2 chestPosition = this.transform.position;
            chestPosition.y += textYOffset;
            openChest.gameObject.transform.position = chestPosition;
        }

        void DestroyOpenChestText()
        {
            if (openChest != null)
            {
                Destroy(openChest.gameObject);
                
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                CreateOpenChestText();
                isInRange = true;
            }
           
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                DestroyOpenChestText();
                isInRange = false;
            }
          
        }


    }
}
