using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Slider healthBar;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerMaxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
