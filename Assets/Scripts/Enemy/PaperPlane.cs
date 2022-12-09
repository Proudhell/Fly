using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    [SerializeField] private float _speed =3f;
    [SerializeField] private int score = 50;
    [SerializeField] private int HP = 2;
    public GameObject player;    
    double sin_1 = 1;
    int q = 0;
    void FixedUpdate()
    {
        float angle = Convert.ToSingle(Math.Cos(sin_1));
        transform.Translate(0, Time.deltaTime*-_speed, 0);
        transform.Rotate(0, -Convert.ToSingle(sin_1)/2, Convert.ToSingle(sin_1));
        if (q == 0)
            sin_1 -= 0.05;
        else
            sin_1 += 0.05;
        if (sin_1 < -1)
            q = 1;
        else if (sin_1 > 1)
            q = 0;
        if (transform.position.y <-6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet")
        {
            HP--;
            if (HP < 0)
            {
                Destroy(gameObject);
                player = GameObject.FindGameObjectWithTag("Player");
                player.gameObject.GetComponent<PlayerControl>().AddScore(score);
            }
            Destroy(other.gameObject);
        }
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerControl>().Damage();
        }

    }
}
