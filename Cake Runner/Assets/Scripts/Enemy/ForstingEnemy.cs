using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class  ForstingEnemy : Enemy
{
    [SerializeField] 
    private FrostProjectile m_frostPrefab;
    [SerializeField] 
    private Vector2 m_frostFireDelay;
    
    
    protected override void Init()
    {
        m_enemyType = EnemyTypes.FROSTING;
    }
    
    protected override void AttackPlayer()
    {
        StartCoroutine(FireFrostAtPlayer());
    }

    private IEnumerator FireFrostAtPlayer()
    {
        FrostProjectile frostProjectile;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(m_frostFireDelay.x, m_frostFireDelay.y));
            frostProjectile = Instantiate(m_frostPrefab, transform.position, Quaternion.identity);
            frostProjectile.Init(m_playerTransform);
        }
    }
}