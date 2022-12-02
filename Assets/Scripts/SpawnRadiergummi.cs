using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRadiergummi : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }
   IEnumerator SpawnEnemy()
   {
    for(; ; )
    {
        yield return new WaitForSeconds(2);
        Instantiate(Enemy, new Vector3(Random.Range(-8f, 8f), 8, 0), Quaternion.identity);
    }
   }
}
