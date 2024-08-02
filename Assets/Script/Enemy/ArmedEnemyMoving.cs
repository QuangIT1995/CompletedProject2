using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmedEnemyMoving : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public Vector2 moveDirection = Vector2.down;
    public int damage = 10;
    //thoi gian dich ban
    public float fireRate = 1.5f;
    public float nextTimeFire = 0f;
    private GameManager gameManager;
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update(){
        Move();
        if(Time.time > nextTimeFire){
            nextTimeFire = Time.time + fireRate;
            Shoot();
        }
    }
    void Move(){
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    void Shoot(){
        Debug.Log("Enemy shooting");
        GameObject bullet = Instantiate(enemyBulletPrefab,firePoint.position,firePoint.rotation);
        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        enemyBullet.SetDamage(damage);
    }
    void OnDestroy(){
        Debug.Log("Destroyed");
        if(gameManager != null){
            gameManager.EnemyDefeated();
        }
    }
}
