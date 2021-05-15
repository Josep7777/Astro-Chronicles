using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnvController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "suelo" || other.gameObject.tag == "Player" || other.gameObject.tag == "Boss")
        {
            Destroy(this.transform.parent.gameObject);

        }
    }
}
