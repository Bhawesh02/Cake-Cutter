using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cream : MonoBehaviour
{
    [SerializeField] private Vector2 m_scaleDuration;

    private Vector3 m_originalScale;
    private Transform m_playerTransform;
    
    public void Init(Transform playerTransform)
    {
        m_originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(m_originalScale, Random.Range(m_scaleDuration.x, m_scaleDuration.y));
        m_playerTransform = playerTransform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == m_playerTransform)
        {
            GameplayEvent.SendOnCreamCollision();
        }
    }
}