using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private int HP = 3;
    [SerializeField] private int Score = 0;
    [SerializeField] private double BulletSpeed_1 = 10;
    [SerializeField] private double BulletSpeed_2 = 0.5;
    public Vector3 _offset;
    public Text HpText;
    public Text ScoreText;
    public GameObject Bullet;
    void FixedUpdate()
    {
        BulletSpeed_1 -= BulletSpeed_2;
        if (BulletSpeed_1 <= 0) {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
            BulletSpeed_1 = 10;
        }
        HpText.text = "HP:" + HP;
        ScoreText.text = "Score:" + Score;
    }
    public void AddScore(int x)
    {
        Score += x;
    }
    public void Damage(){
        HP -=1;
        if(HP<1){
            SceneManager.LoadScene(0);
        }
    }
}
