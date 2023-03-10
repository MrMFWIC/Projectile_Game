using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField]Projectile curProjectile;
    [SerializeField]CanvasManager cm;
    public Player player;

    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public Transform enemySpawnPoint;
    public int enemyCounter = 0;
    public Enemy basicEnemy;
    public Enemy bossEnemy;
    public bool spawnEnemy = true;

    Coroutine enemySpacer;

    void Start()
    {

    }

    void Update()
    {
        if (spawnEnemy)
        {
            if (enemyCounter < 5)
            {
                Instantiate(basicEnemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
                enemyCounter++;
                SpawnEnemy();
            }
            else if (enemyCounter == 5)
            {
                Instantiate(bossEnemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
                enemyCounter = 0;
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        if (enemySpacer == null)
        {
            StartCoroutine(EnemySpacer());
        }
        else
        {
            StopCoroutine(enemySpacer);
            enemySpacer = null;
            enemySpacer = StartCoroutine(EnemySpacer());
        }
    }

    public void Fire(float power, float angle)
    {
        curProjectile.power = power;
        curProjectile.angle = angle;
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }

    IEnumerator EnemySpacer()
    {
        spawnEnemy = false;

        yield return new WaitForSeconds(Random.Range(3,8));

        spawnEnemy = true;
    }
}