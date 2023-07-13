using UnityEngine;

namespace Thermine.TrappedInASnowStorm.Assets.ProjectFiles.Scripts.Controllers
{
    public class BookController : MonoBehaviour
    {
        // GameObjects

        [SerializeField] private GameObject notebookPanel;
        [SerializeField] private GameObject notebookPanelother;
        [SerializeField] private GameObject notebookPanelotherone;


        // Booleans

        private bool notebookStay = false;
        private bool notebookStayother = false;
        private bool notebookStayotherone = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeNotebookState();
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                ChangeNotebookStateOther();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                ChangeNotebookStateOtherOne();
            }
        }
        private void ChangeNotebookState()
        {
            notebookStay = !notebookStay;
            notebookPanel.SetActive(notebookStay);
        }
        private void ChangeNotebookStateOther()
        {
            notebookStayother = !notebookStayother;
            notebookPanelother.SetActive(notebookStayother);
        }
        private void ChangeNotebookStateOtherOne()
        {
            notebookStayotherone = !notebookStayotherone;
            notebookPanelotherone.SetActive(notebookStayotherone);
        }
    }
}