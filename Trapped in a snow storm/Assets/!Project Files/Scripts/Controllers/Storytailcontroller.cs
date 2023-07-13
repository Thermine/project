using UnityEngine;

namespace Thermine.TrappedInASnowStorm.Assets.ProjectFiles.Scripts.Controllers
{
    public class Storytailcontroller : MonoBehaviour
    {
        #region Variables
        // UI

        [Header("UI")]
        [Tooltip("UI window when you coming near character")]
        [SerializeField] private GameObject startToTalkWindow;

        [Tooltip("Window that will open to talk with NPC")]
        [SerializeField] private GameObject interactionNpcWindow;


        [Space]


        // Other

        [Tooltip("Tag of character, which you want to interact")]
        [SerializeField]
        private string characterTag;

        private bool inZone = false;


        // GameObjects

        [SerializeField]
        private GameObject fish;

        #endregion

        #region Methods

        public void OnTriggerStay(Collider other) // start dialogue interaction
        {
            if (this.gameObject.CompareTag(characterTag) && other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Talking();
                }
            }
        }

        public void OnTriggerEnter(Collider other) // giving fish to fisherman
        {
            if (this.gameObject.CompareTag(characterTag) && other.CompareTag("Player"))
            {
                startToTalkWindow.SetActive(true);
                fish.SetActive(false);
            }
        }
        public void OnTriggerExit(Collider other) // leaving dialogue zone
        {
            if (this.gameObject.CompareTag(characterTag) && other.CompareTag("Player"))
            {
                startToTalkWindow.SetActive(false);
                interactionNpcWindow.SetActive(false);
            }
        }

        private void Talking() // UI interaction with NPC characters
        {
            interactionNpcWindow.SetActive(true);
            startToTalkWindow.SetActive(false);
        }

        #endregion
    }
}