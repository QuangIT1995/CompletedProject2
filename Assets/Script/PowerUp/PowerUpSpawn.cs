using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] powerUpPrefab;
    public float spawnInterval = 5f;
    public float spawnX = 8f;
    public void StartSpawn(){
        InvokeRepeating(nameof(Spawn),spawnInterval,spawnInterval);
    }
    public void StopSpawn(){
        CancelInvoke(nameof(Spawn));
    }
    void Spawn(){
        int randomIndex = Random.Range(0,powerUpPrefab.Length);
        float randomX = Random.Range(-spawnX,spawnX);
        Vector2 spawnPosition = new Vector2(randomX,transform.position.y);
        Instantiate(powerUpPrefab[randomIndex],spawnPosition,Quaternion.identity);
    }
}
