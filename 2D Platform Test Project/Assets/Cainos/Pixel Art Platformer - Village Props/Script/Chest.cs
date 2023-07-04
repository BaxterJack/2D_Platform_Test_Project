using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

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
        public GameObject chestText;
        public float textYOffset;
        private void Start()
        {
            artefactCanvasManager = ArtefactCanvasManager.Instance;
        }
        void OpenChest()
        {
           IsOpened = true;
            artefactCanvasManager.OpenCanvas(artefact);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {

                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Open Chest?");
                    OpenChest();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SetTextPosition();
            chestText.gameObject.SetActive(true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            chestText.gameObject.SetActive(false);
        }

        void SetTextPosition()
        {
            Vector2 chestPosition = this.transform.position;
            chestPosition.y += textYOffset;
            chestText.transform.position = chestPosition;
        }
    }
}
