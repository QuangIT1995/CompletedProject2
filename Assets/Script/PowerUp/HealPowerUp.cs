using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    private int healAmount = 12; 
    public float fallingSpeed = 10f;
    void Update(){
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Healing");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
