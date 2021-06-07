using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : StateMachineBehaviour
{
    Transform jugador;
    Rigidbody2D jefe;
    float velocidad = 2f;
    float rangoAtaque = 2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        jefe = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direccion = new Vector2(jugador.position.x, jefe.transform.position.y);
        Vector2 mover = Vector2.MoveTowards(jefe.transform.position, direccion, velocidad * Time.fixedDeltaTime);
        jefe.MovePosition(mover);
        if (Vector2.Distance(jugador.position, jefe.transform.position) <= rangoAtaque)
        {
            animator.SetTrigger("Melee");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Melee");  //Para evitar problemas de atacar 3 veces
    }
}
