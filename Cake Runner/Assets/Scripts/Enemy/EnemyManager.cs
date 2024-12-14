using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Player m_player;
    [SerializeField] private Enemy[] m_enemyPrefabs;
    [SerializeField] private int m_enemiesToSpawn;
    [SerializeField] private float m_enemyCheckRadius;
    [SerializeField] private float m_spawnRange;
    
    private int m_numOfEnemiesSpawned;

    private void Awake()
    {
        GameplayEvent.OnCakeCut += HandelOnCakeCut;
    }

    private void OnDestroy()
    {
        GameplayEvent.OnCakeCut -= HandelOnCakeCut;
    }

    private void HandelOnCakeCut()
    {
        m_numOfEnemiesSpawned--;
    }


    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        //TODO:
        Enemy enemy;
        for (int index = 0; index < m_enemiesToSpawn; index++)
        {
            Enemy enemyPrefab = m_enemyPrefabs[Random.Range(0, m_enemyPrefabs.Length)];
            enemy = Instantiate(enemyPrefab,
                NewEnemySpawnPosition(),
                Quaternion.identity);
            enemy.Config(m_player.transform);
            m_numOfEnemiesSpawned++;
        }
    }

    private Vector3 NewEnemySpawnPosition()
    {
        RaycastHit raycastHit;
        Vector3 newPosition = m_player.transform.position + new Vector3(Random.Range(-m_spawnRange, m_spawnRange), 0f, Random.Range(-m_spawnRange, m_spawnRange));
        bool isEnemyThere = Physics.SphereCast(newPosition, m_enemyCheckRadius, transform.forward,out raycastHit, 0f, LayerMask.NameToLayer("Enemy"));
        while (isEnemyThere)
        {
            newPosition = m_player.transform.position + new Vector3(Random.Range(-m_spawnRange, m_spawnRange), 0f, Random.Range(-m_spawnRange, m_spawnRange));
            isEnemyThere = Physics.SphereCast(newPosition, m_enemyCheckRadius, transform.forward,out raycastHit, 0f, LayerMask.NameToLayer("Enemy"));
        }
        return newPosition;
    }
}
