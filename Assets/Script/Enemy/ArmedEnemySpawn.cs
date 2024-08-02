using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemySpawn : MonoBehaviour
{
    public GameObject[] armedEnemyPrefab;
    public float spawnInterval = 3f;
    public float spawnX = 8f;
    public int enemiesPerRow = 5; // Số lượng kẻ địch mỗi hàng
    public float columnSpacing = 3f; // Khoảng cách giữa các cột
    public void StartSpawning(){
        InvokeRepeating(nameof(SpawnRowOfEnemies),spawnInterval,spawnInterval);
    }
    public void StopSpawning(){
        CancelInvoke(nameof(SpawnRowOfEnemies));
    }
    void Spawn(){
        int randomIndex = Random.Range(0,armedEnemyPrefab.Length);
        float spawnRandomX = Random.Range(-spawnX,spawnX);
        Vector2 spawnPosition = new Vector2(spawnRandomX,transform.position.y);
        Instantiate(armedEnemyPrefab[randomIndex],spawnPosition,Quaternion.identity);
    }
    void SpawnRowOfEnemies(){
        float startX = -spawnX;
        for(int i = 0; i < enemiesPerRow; i++)
        {
            int randomIndex = Random.Range(0, armedEnemyPrefab.Length);
            float spawnXPosition = startX + i * columnSpacing;
            Vector2 spawnPosition = new Vector2(spawnXPosition, transform.position.y);
            Instantiate(armedEnemyPrefab[randomIndex], spawnPosition, Quaternion.identity);            
        }
    }
}
