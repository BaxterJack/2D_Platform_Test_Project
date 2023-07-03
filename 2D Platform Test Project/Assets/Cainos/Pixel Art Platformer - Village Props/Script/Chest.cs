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

    }
}
