using UnityEngine;

public class UI_RobotDialoguePanel : MonoBehaviour
{
    [SerializeField] private GameObject robotDialoguePanel;
    void OnTriggerEnter2D(Collider2D collision)
    {
        robotDialoguePanel.SetActive(true);
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        robotDialoguePanel.SetActive(false);
    }
}
