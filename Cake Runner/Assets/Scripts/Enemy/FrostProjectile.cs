using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class FrostProjectile : MonoBehaviour
{
    [SerializeField] protected float m_jumpForce;
    [SerializeField] protected Vector2 m_jumpDuration;

    private Transform m_playerTransform;
    
    public void Init(Transform playerTransform)
    {
        m_playerTransform = playerTransform;
        transform.DOJump(playerTransform.position, m_jumpForce, 1, Random.Range(m_jumpDuration.x, m_jumpDuration.y)).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                Destroy(gameObject);
            });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == m_playerTransform)
        {
            GameplayEvent.SendOnFrostCollision();
        }
    }
}