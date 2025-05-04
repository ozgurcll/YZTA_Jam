using UnityEngine;

public class UI_PanoInteraction : MonoBehaviour
{
    [SerializeField] private GameObject panoInteractionPanel;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            panoInteractionPanel.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            panoInteractionPanel.SetActive(false);
    }
}
