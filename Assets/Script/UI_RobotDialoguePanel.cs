using UnityEngine;

public class UI_RobotDialoguePanel : MonoBehaviour
{
    [SerializeField] private GameObject robotDialoguePanel;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            robotDialoguePanel.SetActive(true);

    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            robotDialoguePanel.SetActive(false);
    }
}
