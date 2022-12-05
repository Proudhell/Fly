using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed =3f;
    private int HP = 2;
    double sin_1 = 0.5;
    int q = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Convert.ToSingle(Math.Cos(sin_1));
        transform.Translate(0, Time.deltaTime*-_speed, 0);
        transform.Rotate(0, -Convert.ToSingle(sin_1)/2, Convert.ToSingle(sin_1));
        Debug.Log(sin_1);
        if (q == 0)
            sin_1 -= 0.007;
        else
            sin_1 += 0.007;
        if (sin_1 < -0.5)
            q = 1;
        else if (sin_1 > 0.5)
            q = 0;
            
        
        

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
