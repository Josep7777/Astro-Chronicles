using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth;
    private int playerHealth;
    private bool patata = false;

    public PlayerHealthbar healthBar;



    void Start()
    {
        playerHealth = playerMaxHealth;

    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        patata = false;
        if (collision.gameObject.tag.Equals("enemy") && patata == false)
        {
            playerHealth = playerHealth - 1;
            healthBar.SetHealth(playerHealth);
            Debug.Log("aaaaa");
            patata = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        patata = false;
        if (collision.gameObject.tag.Equals("enemybullet") && patata == false)
        {
            playerHealth = playerHealth - 1;
            healthBar.SetHealth(playerHealth);
            //Debug.Log(playerMaxHealth);
            Debug.Log(playerHealth);
            patata = true;
        }

    }

}
