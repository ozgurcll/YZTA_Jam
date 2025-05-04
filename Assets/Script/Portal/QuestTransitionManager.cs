using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestTransitionManager : MonoBehaviour
{
    public GameObject portalEffect;

    public SceneFader sceneFader;

    public float portalDelay = 1f;
    public float dissolveDelay = 1.5f;

    public void StartTransition(int sceneIndex)
    {
        StartCoroutine(TransitionSequence(sceneIndex));
    }

    IEnumerator TransitionSequence(int sceneIndex)
    {
        portalEffect.transform.position = PlayerManager.instance.player.transform.position + new Vector3(0f, 4f, 0f);
        portalEffect.SetActive(true);

        yield return new WaitForSeconds(portalDelay);

        PlayerManager.instance.player.stateMachine.ChangeState(PlayerManager.instance.player.tpState);

        yield return new WaitForSeconds(dissolveDelay);

        // 4. Fade ve sahne ge�i�i
        sceneFader.FadeToScene(sceneIndex.ToString()); // SceneFader string al�yor
    }

    void Start()
    {
        portalEffect.SetActive(false); // Ba�ta g�r�nmesin
    }
}
