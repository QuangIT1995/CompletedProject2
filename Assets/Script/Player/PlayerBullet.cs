using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int scoreGained = 2;
    public GameObject explosivePrefab;
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(gameManager != null){
                gameManager.AddScore(scoreGained);
            }
            AudioManager.Instance.PlayExplosionSound();
            Explode();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Enemy1")){
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(gameManager != null){
                gameManager.AddScore(scoreGained + 2);
            }
            AudioManager.Instance.PlayExplosionSound();
            Explode();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.CompareTag("EnemySpaceship")){
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(gameManager != null){
                gameManager.AddScore(scoreGained + 3);
            }
            AudioManager.Instance.PlayExplosionSound();
            Explode();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    void Explode(){
        Debug.Log("Boom!");
        GameObject go = Instantiate(explosivePrefab,transform.position,Quaternion.identity);
        Animator anim = go.GetComponent<Animator>();
        anim.SetTrigger("Explosive");
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
