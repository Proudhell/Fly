using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.01f;
    [SerializeField] private float _angle1 = 0.01f;
    private float _angle;
    float _x_pos = 0;
    float _y_pos = 0;
    public GameObject _child;

    private static Quaternion Change(float x, float y, float z)
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(x, y, z, 1);
        //Return the new Quaternion
        return newQuaternion;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            _x_pos = Math.Abs(transform.position.x - touchPos.x);
            _y_pos = Math.Abs(transform.position.y - touchPos.y);
            if (transform.position.x > touchPos.x)
                _x_pos *= -1;
            if (transform.position.y > touchPos.y)
                _y_pos *= -1;
            transform.Translate(1 * _speed * (_x_pos), 1 * _speed * (_y_pos), 0);
            _angle = _x_pos;
        };
        if (_angle > 0)
            _angle -= 0.05f;
        if (_angle < 0)
            _angle += 0.05f;


        _child.transform.rotation = Change(0f, -_angle1 * _angle, 0f);
        if (transform.position.x > 2.7)
        {
            transform.position = new Vector2(2.7f, transform.position.y);
        }
        else if (transform.position.x < -2.7)
        {
            transform.position = new Vector2(-2.7f, transform.position.y);
        }
        if (transform.position.y > 4)
        {
            transform.position = new Vector2(transform.position.x, 4);
        }
        else if (transform.position.y < -5)
        {
            transform.position = new Vector2(transform.position.x, -5);
        }
    }
}
