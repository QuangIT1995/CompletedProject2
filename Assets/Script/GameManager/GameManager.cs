using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //khoi tao doan text thong bao stage
    public TextMeshProUGUI stageText;
    //khai bao ba array gameobject prefab ke dich
    // public TextMeshProUGUI enemiesDefeatedText;
    public int[] enemiesToDefeatForNextStage = {5,5,5}; //So luong ke dich can tieu diet de qua man
    private int currentStage = 0; //Man choi hien tai gan la 0
    private int enemiesDefeated = 0; //so luong ke dich da bi tieu diet la 0, co nghia la chua tieu diet ke dich nao
    private bool gameEnded = false; //bien kiem tra tro choi ket thuc
    private int score = 0;
    private EnemySpawn meleeEnemiesSpawner;
    private ArmedEnemySpawn armedEnemiesSpawner;
    private PowerUpSpawn powerUpSpawn;
    void Start(){
        meleeEnemiesSpawner = FindObjectOfType<EnemySpawn>();
        armedEnemiesSpawner = FindObjectOfType<ArmedEnemySpawn>();
        powerUpSpawn = FindObjectOfType<PowerUpSpawn>();
        UpdateGUI();
        StartCoroutine(StartStage(0));
    }
    void Update(){
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if(playerHealth.currentHealth <= 0 && !gameEnded){
            gameEnded = true;
            StartCoroutine(RestartGame());
        }
    }
    public void UpdateGUI(){
        scoreText.text = $"Score: {score}";
        // enemiesDefeatedText.text = $"Enemies Defeated: {enemiesDefeated}/{enemiesToDefeatForNextStage[currentStage]}";
    }
    public void AddScore(int amount){
        score += amount;
        UpdateGUI();
    }
    //ham xu ly ke dich bi tieu diet
    public void EnemyDefeated(){
        enemiesDefeated++; //so luong ke dich bi tieu diet dan tang len
        UpdateGUI();
        //khi so luong ke dich bi tieu diet lon hon so ke dich can phai tieu diet de sang man choi tiep theo
        if(enemiesDefeated >= enemiesToDefeatForNextStage[currentStage]){
            //reset ve 0
            enemiesDefeated = 0; 
            if(currentStage < enemiesToDefeatForNextStage.Length - 1){
                StartCoroutine(StartStage(currentStage + 1));
            }
            else{
                EndGame();
            }
        }
    }
    //May dem thoi gian text hien thi so man(xu ly tac vu qua nhieu khung khi su dung chung voi corountine)
    IEnumerator StartStage(int stageIndex){
        currentStage = stageIndex;
        stageText.text = $"Stage {currentStage + 1}";
        stageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4); //dem trong vong 4 giay
        stageText.gameObject.SetActive(false);
        if(stageIndex > 0) 
        {
            DisableEnemies(stageIndex - 1);
        }
        EnableEnemies(stageIndex);
        UpdateGUI();
    }
    void EnableEnemies(int stageIndex){
        switch (stageIndex)
        {
            case 0:
            meleeEnemiesSpawner.StartSpawning();
            powerUpSpawn.StartSpawn();
            break;
            case 1:
            armedEnemiesSpawner.StartSpawning();
            powerUpSpawn.StartSpawn();
            break;
        }
    }
    void DisableEnemies(int stageIndex){
        switch (stageIndex)
        {
            case 1:
            meleeEnemiesSpawner.StopSpawning();
            powerUpSpawn.StopSpawn();
            break;
            case 2:
            armedEnemiesSpawner.StopSpawning();
            powerUpSpawn.StopSpawn();
            break;
        }
    }
    IEnumerator RestartGame(){
        stageText.text = "You died! Restarting....";
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void EndGame(){
        if(stageText != null){
            stageText.text = "You win!";
            stageText.gameObject.SetActive(true);
            SceneManager.LoadScene("MainMenu");
            AudioManager.Instance.StopBackgroundMusic();
        }
    }
}
