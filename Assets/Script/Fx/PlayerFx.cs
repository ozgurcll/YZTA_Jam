using Unity.Cinemachine;
using UnityEngine;

public class PlayerFx : EntityFx
{
    [Header("Screen Shake FX")]
    private CinemachineImpulseSource screenShake;
    [SerializeField] private float shakeMultiplier;
    public Vector3 shakeHighDamage;
<<<<<<< HEAD
    public Vector3 shakeDestroyObstacle;
    public Vector3 shakeFall;
=======
>>>>>>> 532d528f9a1b6bdb817c291f4e8123d13176bfaa

    [Space]
    [SerializeField] private ParticleSystem dustFx;
    protected override void Start()
    {
        base.Start();
        screenShake = GetComponent<CinemachineImpulseSource>();
    }

    public void ScreenShake(Vector3 _shakePower)
    {
        screenShake.DefaultVelocity = new Vector3(_shakePower.x * player.facingDir, _shakePower.y) * shakeMultiplier;
        screenShake.GenerateImpulse();
    }
    public void PlayDustFX()
    {
        if (dustFx != null)
            dustFx.Play();
    }
}
