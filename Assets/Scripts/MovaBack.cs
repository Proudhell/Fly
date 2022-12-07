using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovaBack : MonoBehaviour
{

    public GameObject _back;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _height = 11;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, Time.deltaTime * -_speed, 0);
        if (transform.position.y < -_height)
        {
            Instantiate(_back, new Vector3(0, _height, 1), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
