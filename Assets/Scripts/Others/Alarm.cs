using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public AudioSource alarmSound;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;


    public float speed;

    public Transform childTransform;

    public Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        posB = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //alarmSound.Play();
        }
    }
}
