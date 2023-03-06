using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class TargetDummy : MonoBehaviour, IAttackable
{

    public float hp = 100f;

    public NavMeshAgent agent;

    public Renderer dummyRenderer;
    public Color flashColor;

    private Material dummyMat;
    private Color startColor;
    private Tween flashTween;

    private bool canTakeDamage = true;

    public float knockBackAmount = 2f;
    public float knockBackTime = 0.2f;

    public PlayerController playerRef;
    public float movementSpeed = 10f;

    public GameObject hitFx;

    void Start()
    {
        playerRef = FindObjectOfType<PlayerController>();

        dummyMat = dummyRenderer.material;
        startColor = dummyMat.color;
    }

    private void FixedUpdate()
    {
        if (!canTakeDamage) return;

        agent.SetDestination(playerRef.transform.position);

    }
    public void TakeDamage(float damageAmount, Transform interactorRef, Vector3 hitPoint)
    {
        if (!canTakeDamage) return;

        hp -= damageAmount;
        Flash();
        Destroy(Instantiate(hitFx, hitPoint, Quaternion.identity), 3f);

        canTakeDamage = false;
        agent.enabled = false;

        transform.DOMove(transform.position + Vector3.Scale(new Vector3(1, 0, 1), (transform.position - playerRef.transform.position).normalized * knockBackAmount), knockBackTime)
        .SetEase(Ease.OutSine)
        .OnComplete(() =>
        {
            agent.enabled = true;
            canTakeDamage = true;
        });
    }

    private void Flash()
    {
        dummyMat.color = flashColor;
        flashTween?.Kill();
        flashTween = dummyMat.DOColor(startColor, 0.5f).SetEase(Ease.OutSine);
    }
}
