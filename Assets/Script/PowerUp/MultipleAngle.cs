using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAngle : MonoBehaviour
{
    public float fallingSpeed = 10f;
    void Update(){
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Dissapear");
            PlayerShooting playerShoot = other.GetComponent<PlayerShooting>();
            playerShoot.ActiveMultiShoot();
            Destroy(gameObject);
        }
    }
}
