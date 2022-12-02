using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{    
    [SerializeField] private float _speed =5f;
    [SerializeField] private int HP = 3;

    [SerializeField] private int Score = 0;
    [SerializeField] private double BulletSpeed_1 = 10;
    [SerializeField] private double BulletSpeed_2 = 0.5;

    public Text HpText;
    public Text ScoreText;
    public GameObject Bullet;
    void Update()
    {
       BulletSpeed_1-=BulletSpeed_2;
        if (BulletSpeed_1 <=0) {
            Instantiate(Bullet, new Vector3(transform.position.x,transform.position.y+1,0), Quaternion.identity);
           // Debug.Log(BulletSpeed_1);
            BulletSpeed_1 = 10;
        }
        HpText.text = "HP:"+ HP;
        Movement();
        
        if(transform.position.x > 10)
        {
            transform.position = new Vector2(10, transform.position.y);
        }
        else if (transform.position.x < -10)
        {
            transform.position = new Vector2(-10, transform.position.y); 
        }
        if(transform.position.y > 4)
        {
            transform.position = new Vector2(transform.position.x , 4);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector2(transform.position.x , -4); 
        }
    }
    void Movement(){
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(Horizontal,Vertical)*Time.deltaTime*_speed);

    }
    public void Damage(){
        HP -=1;
        if(HP<1){
            SceneManager.LoadScene(0);
        }
    }
}
