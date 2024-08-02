using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] meteorPrefab; //array cac prefab thien thach
    public float spawnInterval = 3f;//thoi gian giua cac lan spawn
    public float spawnX = 8f; //vi tri spawn truc x
    // Start is called before the first frame update
    public void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn),spawnInterval,spawnInterval);//Lap lai ham hoi sinh voi thoi gian chi dinh
    }
    public void StopSpawning(){
        CancelInvoke(nameof(Spawn));
    }
    // Update is called once per frame
    void Spawn()
    {
        int randomIndex = Random.Range(0,meteorPrefab.Length);
        float randomX = Random.Range(-spawnX, spawnX); //bien de ke dich xuat hien ngau nhien tren truc x
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y); //vi tri spawn bang truc vector
        Instantiate(meteorPrefab[randomIndex], spawnPosition, Quaternion.identity); //San sinh ra enemy lien tuc
    }
}
