using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallsController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Onda")
        {
            Debug.Log("AA");
            other.gameObject.SetActive(false);
        }

    }
}
