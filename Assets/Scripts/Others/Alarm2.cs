using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm2 : MonoBehaviour
{

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;
    private bool alarmTrap;

    public float speed;

    public Transform childTransform;
    public Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        alarmTrap = false;
        posB = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        if (alarmTrap == true)
        {
            Move();
        }

    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            alarmTrap = true;

        }
    }
}
