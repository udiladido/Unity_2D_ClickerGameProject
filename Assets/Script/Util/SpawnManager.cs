using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [Header("Enemy")]
    public GameObject[] enemyObj;
    public GameObject enemySpawn;


    private void EnemySpawn()
    {

        StartCoroutine(EnemySpawnTime());
       
    }


    IEnumerator EnemySpawnTime()
    {

        yield return new WaitForSeconds(1f);


        int ran = Random.Range(0, enemyObj.Length);
        Instantiate(enemyObj[ran], transform.position, Quaternion.identity);
    
    
    }


}
