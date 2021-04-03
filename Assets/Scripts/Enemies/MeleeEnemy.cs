using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLenght;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    private RaycastHit2D hit;
    private GameObject target;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;


    // Start is called before the first frame update
    void Awake()
    {
        intTimer = timer;

    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLenght, raycastMask);
            RaycastDebugger();
        }
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            //StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance > attackDistance)
        {
            Move();
            //StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            //Attack();
        }
        if (cooling)
        {

        }
    }
    private void Move()
    {
        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.red);
        }else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.green);
        }
    }
}
