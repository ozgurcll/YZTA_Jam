using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossDeathController : MonoBehaviour
{
    public Image whiteFlash;
    public Animator bossAnimator;
    public ParticleSystem deathEffect;

    public void TriggerBossDeath()
    {
        StartCoroutine(BossDeathSequence());
    }

    IEnumerator BossDeathSequence()
    {
        // 1. Ekran sarsýlýr
        yield return StartCoroutine(ScreenShake(0.4f, 0.2f));

        // 2. Zaman yavaþlar
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 1f;

        // 3. Beyaz ýþýk efekti
        yield return StartCoroutine(FlashExpand());

        // 4. Boss animasyon veya efekt
        if (bossAnimator != null)
        {
            bossAnimator.SetTrigger("Die");
        }

        if (deathEffect != null)
        {
            deathEffect.Play();
        }

        // 5. Ýstersen burada sahne geçiþi, skor ekraný vs. tetiklenebilir
    }

    IEnumerator ScreenShake(float duration, float magnitude)
    {
        Vector3 originalPos = Camera.main.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            Camera.main.transform.localPosition = originalPos + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.localPosition = originalPos;
    }

    IEnumerator FlashExpand()
    {
        whiteFlash.gameObject.SetActive(true);
        Color c = whiteFlash.color;
        c.a = 0;
        whiteFlash.color = c;
        whiteFlash.transform.localScale = Vector3.zero;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t);
            whiteFlash.color = c;
            whiteFlash.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 3f, t);
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);
        whiteFlash.gameObject.SetActive(false);
    }
}
