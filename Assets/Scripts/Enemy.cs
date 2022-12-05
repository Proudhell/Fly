using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed =4f;
    private int HP = 2;
    double sin_1 = 1;
    int q = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Convert.ToSingle(Math.Sin(sin_1));
        transform.Translate(0, Time.deltaTime*-_speed, 0);
        transform.Rotate(0, 0, Convert.ToSingle(angle));
        Debug.Log(angle);        
            sin_1 -= 0.03;
        
        

        if (transform.position.y <-4)
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
