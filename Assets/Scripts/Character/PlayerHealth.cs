﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerHealth;
    public float tiempo_inmortal = 1f;
    public AudioSource damageSoundEffect;

    public PlayerHealthbar healthBar;



    void Start()
    {
        playerHealth = playerMaxHealth;

    }

    private void Update()
    {
        tiempo_inmortal -= Time.deltaTime;
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("DeathScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("enemy") && tiempo_inmortal <= 0)
        {
            damageSoundEffect.Play();
            playerHealth = playerHealth - 1;
            healthBar.SetHealth(playerHealth);
            tiempo_inmortal = 1f;


        }

        if (collision.gameObject.tag.Equals("Pincho") && tiempo_inmortal <= 0)
        {
            damageSoundEffect.Play();
            playerHealth = playerHealth - 3;
            healthBar.SetHealth(playerHealth);
            tiempo_inmortal = 1f;


        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("enemy") && tiempo_inmortal <= 0)
        {
            playerHealth = playerHealth - 1;
            healthBar.SetHealth(playerHealth);           
            tiempo_inmortal = 1f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("enemybullet") && tiempo_inmortal <= 0)
        {
            damageSoundEffect.Play();
            playerHealth = playerHealth - 1;
            healthBar.SetHealth(playerHealth);
            tiempo_inmortal = 1f;
        }

        if (collision.gameObject.tag.Equals("Onda") && tiempo_inmortal <= 0)
        {
            damageSoundEffect.Play();
            playerHealth = playerHealth - 2;
            healthBar.SetHealth(playerHealth);
            tiempo_inmortal = 1f;
        }

    }

}
