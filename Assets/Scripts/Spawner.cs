using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }
   IEnumerator SpawnEnemy()
   {
        for (; ; )
        {
                yield return new WaitForSeconds(2);
                float x = Random.Range(-2.1f, 2.1f);
            for (int i = 0; i < 3; i++)
            {                
                yield return new WaitForSeconds(0.4f);
                Instantiate(Enemy, new Vector3(x, 8, 0), Quaternion.identity);
            }         
        }
   }
}
