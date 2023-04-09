using System.Collections;
using System.Collections.Generic;
using Anthill.Core;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class TargetDummy : MonoBehaviour, IAttackable
{

    public bool IsEngaged = false;
    public Health Health;
    public NavMeshAgent agent;

    public Renderer dummyRenderer;
    public Color flashColor;

    private Material dummyMat;
    private Color startColor;
    private Tween flashTween;

    public float knockBackAmount = 2f;
    public float knockBackTime = 0.2f;

    public PlayerController playerRef;
    public float movementSpeed = 10f;

    public GameObject hitFx;

    private AntEntity _entity;

    void Start()
    {
        playerRef = FindObjectOfType<PlayerController>();

        dummyMat = dummyRenderer.material;
        startColor = dummyMat.color;
        _entity = GetComponent<AntEntity>();
        agent.speed = movementSpeed;
        AntEngine.AddEntity(_entity);
    }

    public void ExecuteMovement()
    {
        if (!Health.CanTakeDamage) return;

        if (!IsEngaged) return;

        agent.SetDestination(playerRef.transform.position);

    }


    public void TakeDamage(float damageAmount, Transform interactorRef, Vector3 hitPoint)
    {
        if (!Health.CanTakeDamage) return;

        Health.cashedDamage += damageAmount;
        AntEngine.Get<Menu>().Get<DamageUIController>().SpawnDamageNumber(damageAmount, transform.position);

        Flash();
        Destroy(Instantiate(hitFx, hitPoint, Quaternion.identity), 3f);

        Health.CanTakeDamage = false;
        agent.enabled = false;

        transform.DOMove(transform.position + Vector3.Scale(new Vector3(1, 0, 1), (transform.position - playerRef.transform.position).normalized * knockBackAmount), knockBackTime)
        .SetEase(Ease.OutSine)
        .OnComplete(() =>
        {
            agent.enabled = true;
            Health.CanTakeDamage = true;

            if (Health.IsDead())
            {
                DeathHandler();
            }
        });
    }

    public void Engage()
    {
        IsEngaged = true;
    }

    private void Flash()
    {
        dummyMat.color = flashColor;
        flashTween?.Kill();
        flashTween = dummyMat.DOColor(startColor, 0.5f).SetEase(Ease.OutSine);
    }

    private void DeathHandler()
    {
        IsEngaged = false;
        Destroy(gameObject);
    }
}
