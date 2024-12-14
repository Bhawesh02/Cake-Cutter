using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{
    private const int JUMP_NUM = 1;
    
    [SerializeField] protected float m_jumpForce;
    [SerializeField] protected Vector2 m_jumpDistance;
    [SerializeField] protected Vector2 m_jumpDuration;
    [SerializeField] protected Vector2 m_jumpDelay;
    
    protected EnemyTypes m_enemyType;
    protected Transform m_playerTransform;
    protected Sequence m_moveTween;
    
    public virtual void Config(Transform playerTransform)
    {
        m_playerTransform = playerTransform;
    }

    private void Start()
    {
        Init();
        AttackPlayer();
    }

    protected void Update()
    {
        MoveCake();
    }

    protected abstract void AttackPlayer();

    protected abstract void Init();

    protected virtual void MoveCake()
    {
        Vector3 nextPosition = GetNextPosition();
        if (m_moveTween == null || !m_moveTween.active)
        {
            m_moveTween = transform
                .DOJump(nextPosition, m_jumpForce, JUMP_NUM, Random.Range(m_jumpDuration.x, m_jumpDuration.y))
                .SetEase(Ease.Linear)
                .SetDelay(Random.Range(m_jumpDelay.x, m_jumpDelay.y));
        }
    }

    private Vector3 GetNextPosition()
    {
        Vector3 newPosition = transform.position;
        Vector3 jumpDirection = m_playerTransform.position - newPosition;
        jumpDirection = jumpDirection.normalized * -1f;
        newPosition += jumpDirection * Random.Range(m_jumpDistance.x, m_jumpDistance.y);
        //TODO : Random x and z
        return newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.transform != m_playerTransform)
            return;
        CakeCut();
    }

    protected virtual void CakeCut()
    {
        GameplayEvent.SendOnCakeCut();
        gameObject.SetActive(false);
    }
}