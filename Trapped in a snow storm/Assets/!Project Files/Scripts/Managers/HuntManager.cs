using System.Collections;
using UnityEngine;

namespace Thermine.TrappedInASnowStorm.Assets.ProjectFiles.Scripts.Managers
{
    public class HuntManager : MonoBehaviour
    {
        #region Variables
        // GameObjects

        [Header("GameObjects"), Tooltip("Objects that used in hunt mode")]
        [SerializeField] private GameObject bow;
        [SerializeField] private GameObject deer;


        // UI objects

        [Header("UI"), Tooltip("UI text to ")]
        [SerializeField] private GameObject missedText; // text when we missing a deer while hunting
        [SerializeField] private GameObject killText; // text when we killing a deer while hunting
        [SerializeField] private GameObject huntZoneText; // text when we coming into the hunting zone


        // Floats

        [SerializeField] private float damage;
        [SerializeField] private float shootingRange;


        // Other

        [Header("Camera"), Tooltip("Player camera for raycasting (used in shooting)")]
        [SerializeField] private Camera playerCamera;

        private string deerinfo; // used to detect object of shooting
        private bool isHuntEnded = false;

        #endregion

        #region Methods

        public void OnTriggerStay(Collider other) // coming into the hunt zone
        {
            if (this.gameObject.CompareTag("Player") && other.CompareTag("Forest Zone") && isHuntEnded == false) // hunt mode
            {
                huntZoneText.SetActive(true);
                bow.SetActive(true);
                if (Input.GetButtonDown("Fire1"))
                {
                    Shooting();
                }
            }
        }

        public void OnTriggerExit(Collider other) // leaving the hunt zone
        {
            if (this.gameObject.CompareTag("Player") && other.CompareTag("Forest Zone"))
            {
                huntZoneText.SetActive(false);
                bow.SetActive(false);
            }
        }

        private void Shooting()
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootingRange))
            {
                Debug.Log(hit.transform.name);
                deerinfo = hit.transform.name;
                if (deerinfo == "deer") // if target is a deer than debug 'kill' and destroy
                {
                    StartCoroutine(KillText());
                    Destroy(deer);

                    isHuntEnded = true;

                }
                else if (deerinfo != "deer") // if target is not a deer than debug 'miss'
                {
                    StartCoroutine(MissText());
                }

            }
        }

        // UI's 

        private IEnumerator MissText()
        {
            missedText.SetActive(true);
            yield return new WaitForSeconds(1f);
            missedText.SetActive(false);
        }

        private IEnumerator KillText()
        {
            killText.SetActive(true);
            yield return new WaitForSeconds(1f);
            killText.SetActive(false);
        }

        #endregion
    }
}
