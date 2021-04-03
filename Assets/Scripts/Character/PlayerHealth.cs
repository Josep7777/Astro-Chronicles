using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth;
    private float playerHealth;



    void Start()
    {
        playerHealth = playerMaxHealth;

    }

    private void Update()
    {
        Debug.Log(playerHealth);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            playerHealth--;
        }
    }
}
