using System.Collections;
using UnityEngine;

public class QuestTransitionManager : MonoBehaviour
{
    public GameObject portalEffect;
    public Animator playerAnimator;
    public SceneFader sceneFader;

    public float portalDelay = 1f;
    public float dissolveDelay = 1.5f;

    public void StartTransition(int sceneIndex)
    {
        StartCoroutine(TransitionSequence(sceneIndex));
    }

    IEnumerator TransitionSequence(int sceneIndex)
    {
        // 1. Portal karakterin üstüne yerleþtirilir
        portalEffect.transform.position = playerAnimator.transform.position + new Vector3(0f, 4f, 0f);
        portalEffect.SetActive(true);

        // 2. Portal animasyonu varsa tetikle
        Animator portalAnim = portalEffect.GetComponent<Animator>();
        if (portalAnim != null)
            portalAnim.SetTrigger("Open");

        yield return new WaitForSeconds(portalDelay);

        // 3. Karakter dissolve animasyonu
        playerAnimator.SetTrigger("Teleport");

        yield return new WaitForSeconds(dissolveDelay);

        // 4. Fade ve sahne geçiþi
        sceneFader.FadeToScene(sceneIndex.ToString()); // SceneFader string alýyor
    }

    void Start()
    {
        portalEffect.SetActive(false); // Baþta görünmesin
    }
}
