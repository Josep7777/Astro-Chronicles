﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gladis : MonoBehaviour
{
    public GameObject Panel; 
    public GameObject TextBox;
    public GameObject Accept;
    public int choiseMade;
    public int firstAsk;
    public PlayerHealth ph;
    public GameObject jugador;
    public AudioSource gladisHeal;
    public AudioSource gladisSad;
    public AudioSource gladisQuestion;
    void Start()
    {
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Panel.gameObject.SetActive(false);
        choiseMade = 0;
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    public void AcceptButton()
    {
        //Debug.Log("ola");
        if (choiseMade == 0)
        {
            TextBox.GetComponent<Text>().text = "Entendido señor, procesando a restaurar sus puntos de salud.";
            gladisHeal.Play();
            ph.playerHealth = ph.playerMaxHealth;
            ph.healthBar.SetHealth(ph.playerHealth);
            choiseMade = 1;
            firstAsk = 0;
        }
        else
        {
            TextBox.GetComponent<Text>().text = "Lo siento mi señor, no tengo la suficiente bateria para poder ayudarle.";
            gladisSad.Play();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Panel.gameObject.SetActive(true);
            if(firstAsk == 0)
            {
                gladisQuestion.Play();
                firstAsk = 1;
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Panel.gameObject.SetActive(false);
            if (choiseMade == 1)
            {
                TextBox.GetComponent<Text>().text = "Lo siento mi señor, no tengo la suficiente bateria para poder ayudarle.";
            }
        }
    }


}
