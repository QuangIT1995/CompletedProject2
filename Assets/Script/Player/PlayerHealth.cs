using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    //public TextMeshProUGUI healthNumberText;
    void Start(){
        currentHealth = maxHealth;
        UpdateUI();
    }
    public void TakeDamage(int amount){
        currentHealth -= amount;
        if(currentHealth < 0) currentHealth = 0;
        UpdateUI();
    }
    public void Heal(int amount){
        currentHealth += amount;
        if(currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateUI();
    }
    void UpdateUI(){
        //healthNumberText.text = $"{currentHealth}";
        healthSlider.value =(float)currentHealth / maxHealth * 100;
    }
}
