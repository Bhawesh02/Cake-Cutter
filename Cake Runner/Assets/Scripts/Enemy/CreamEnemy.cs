using System.Collections;
using UnityEngine;

public class CreamEnemy : Enemy
{
    [SerializeField] private Cream m_creamPrefab;
    [SerializeField] private Vector2 m_creamDropDelay;
    
    protected override void Init()
    {
        m_enemyType = EnemyTypes.CREAMY;
    }
    
    protected override void AttackPlayer()
    {
        StartCoroutine(DropCream());
    }

    private IEnumerator DropCream()
    {
        Cream cream;
        Vector3 creamDropPosition;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(m_creamDropDelay.x, m_creamDropDelay.y));
            creamDropPosition = transform.position;
            creamDropPosition.y = 0f;
            cream = Instantiate(m_creamPrefab, creamDropPosition, Quaternion.identity);
            cream.Init(m_playerTransform);
        }
    }
}