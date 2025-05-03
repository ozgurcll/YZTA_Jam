using UnityEngine;
using TMPro;
using System.Collections;

public class EntityFx : MonoBehaviour
{
    protected Player player;
    protected SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material originalMat;

    [Header("Hit FX")]
    [SerializeField] private GameObject hitFx;


    protected virtual void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        player = PlayerManager.instance.player;
        originalMat = sr.material;
    }



    public void MakeTransprent(bool _transprent)
    {
        if (_transprent)
            sr.color = Color.clear;
        else
            sr.color = Color.white;
    }
    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        Color currentColor = sr.color;
        sr.color = Color.white;

        yield return new WaitForSeconds(flashDuration);

        sr.color = currentColor;
        sr.material = originalMat;
    }

    private void RedColorBlink()
    {
        if (sr.color != Color.white)
            sr.color = Color.white;

        else
            sr.color = Color.red;
    }

    private void CancelColorChange()
    {
        CancelInvoke();
        sr.color = Color.white;
    }

    public void CreateHitFX(Transform _target, bool _critical)
    {
        float zRotation = Random.Range(-90, 90);
        float xPosition = Random.Range(-.5f, .5f);
        float yPosition = Random.Range(-.5f, .5f);

        Vector3 hitFxRotation = new Vector3(0, 0, zRotation);

        GameObject hitPrefab = hitFx;

        GameObject newHitFx = Instantiate(hitPrefab, _target.position + new Vector3(xPosition, yPosition), Quaternion.identity, _target);
        newHitFx.transform.Rotate(hitFxRotation);
        Destroy(newHitFx, .5F);

        HitStopEffect(.1f, .1f);

    }

    public void HitStopEffect(float _duration, float _slowdownFactor)
    {
        player.fx.ScreenShake(player.fx.shakeHighDamage);
        StartCoroutine(HitStop(_duration, _slowdownFactor));
    }

    IEnumerator HitStop(float duration, float slowdownFactor)
    {
        Time.timeScale = slowdownFactor;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}
