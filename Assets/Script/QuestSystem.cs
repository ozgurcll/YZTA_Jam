using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Animator anim => GetComponent<Animator>();

    [SerializeField] private int sceneIndex;
    [SerializeField] private QuestTransitionManager transitionManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("isHover", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("isHover", false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transitionManager.StartTransition(sceneIndex);
        GameObject.Find("PanoPanel").SetActive(false);
    }
}
