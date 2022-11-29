using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);
        if(transform.position.y>5)
        {
            Destroy(gameObject);
        }
    }
}
