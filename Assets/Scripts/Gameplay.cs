using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    Projectile curProjectile;
    CanvasManager cm;

    public Rigidbody2D projectilePrefab;
    public Transform projectileSpawnPoint;

    public Transform enemySpawnPoint;
    public int enemyCounter = 0;
    public Enemy basicEnemy;
    public Enemy bossEnemy;
    public bool spawnEnemy = true;

    Coroutine enemySpacer;

    void Start()
    {
        curProjectile = GetComponent<Projectile>();
        cm = GetComponent<CanvasManager>();
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

    public void Fire()
    {
        projectileSpawnPoint.transform.eulerAngles = Vector3.forward * cm.angleInputValue;

        Rigidbody2D temp = Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
        curProjectile.power = cm.powerInputValue;

        temp.AddRelativeForce(new Vector3(0, cm.powerInputValue, 0));
    }

    IEnumerator EnemySpacer()
    {
        spawnEnemy = false;

        yield return new WaitForSeconds(Random.Range(3,8));

        spawnEnemy = true;
    }
}
