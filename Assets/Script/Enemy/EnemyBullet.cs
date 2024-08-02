using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 4f;
    private int damage;
    void Update(){
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if(playerHealth != null){
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
    public void SetDamage(int damageAmount){
        damage = damageAmount;
    }
}
