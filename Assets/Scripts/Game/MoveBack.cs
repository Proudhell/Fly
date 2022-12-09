using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public SpriteRenderer _backSprite;

    [SerializeField] private float _speed = 3f;
    void FixedUpdate()
    {
        if (transform.position.y == 0)
        {
            Instantiate(_backSprite, new Vector3(0, _backSprite.sprite.rect.height / 100, 10), Quaternion.identity);
            _backSprite.flipY = true;
        }
        transform.Translate(0,-_speed, 0);
        if (transform.position.y < -10)
        {
            Instantiate(_backSprite, new Vector3(0, _backSprite.sprite.rect.height / 100, 10), Quaternion.identity);
            Destroy(gameObject);
           
        }


    }
}
