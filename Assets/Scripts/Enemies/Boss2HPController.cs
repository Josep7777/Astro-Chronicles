using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2HPController : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemyMaxHealth;
    private float EnemyHealth;
    public Slider barra_vida;
    public GameObject gc;

    void Start()
    {
        EnemyHealth = EnemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            gc.GetComponent<EndController>().flag = true;
            Destroy(gameObject);
        }
    }
}
