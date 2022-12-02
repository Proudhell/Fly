using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiergummi : MonoBehaviour
{
    [SerializeField] private float _speed =5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);

        if(transform.position.y <-4)
        {
            transform.position = new Vector2(Random.Range(-8f,8f),6);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerControl>().Damage();
        }

    }
}
