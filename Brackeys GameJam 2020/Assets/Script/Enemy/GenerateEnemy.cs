using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
	#region Variables
	public static bool preventCrossSceneReferences = false;

    public GameObject enemy;

    public int xPos;
    public int zPos;
    public int enemyCount;
    public int maxEnemy = 5;

    public float dropRate = 1;
	#endregion

	#region Unity Methods
	void Start()
    {
        StartCoroutine(EnemyDrop());

        enemyCount++;
    }
	#endregion

	#region Methods
	IEnumerator EnemyDrop()
    {
        while (enemyCount < maxEnemy)
        {

            xPos = UnityEngine.Random.Range(-75, 25);
            zPos = UnityEngine.Random.Range(-35, 45);

            Instantiate(enemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

            yield return new WaitForSeconds(dropRate);

            enemyCount++;
        }
    }
	#endregion
}
