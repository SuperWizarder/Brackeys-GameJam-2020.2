using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;

    public int xPos, zPos;
    public int x1, x2, z1, z2;

    public int enemyCount;
    int randEnemy;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 3)
        {
            xPos = Random.Range(x1, x2);
            zPos = Random.Range(z1, z2);

            Vector3 position = new Vector3(xPos, 5, zPos);

            randEnemy = Random.Range(1, 3);

            Instantiate(enemies[randEnemy], position, Quaternion.identity);

            yield return new WaitForSeconds(2f);

            enemyCount += 1;
        }
    }
}
