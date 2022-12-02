using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed =4f;
    private int HP = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);

        if(transform.position.y <-4)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet")
        {
            HP--;
            if (HP < 0)
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
