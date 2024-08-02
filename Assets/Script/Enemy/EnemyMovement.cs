using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; //toc do di chuyen cua ke dich
    public int damageMade = 10; //damage ke dich gay ra cho player(doi voi object tiep can player)
    public Vector2 moveDirection = Vector2.down; //ke dich di tu tren xuong
    private GameManager gameManager;
     //ke dich di chuyen lien tuc trong moi frame
    //public GameObject explosivePrefab;
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    void OnDestroy(){
        Debug.Log("Destroyed!");
        if(gameManager != null){
            gameManager.EnemyDefeated();
        }
    }
    //va cham
    void OnTriggerEnter2D(Collider2D other)
    {
        //neu nhu vat the nay va cham voi nguoi choi
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = FindObjectOfType<PlayerHealth>(); //tao mot player bang cach tra ve doi tuong(class) la PlayerHealth
            player.TakeDamage(damageMade);
            // Destroy(other.gameObject); 
            Destroy(gameObject);
        }
    }
    
}
