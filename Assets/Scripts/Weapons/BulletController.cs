using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float daño;
    public GameObject ps;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(ps, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
