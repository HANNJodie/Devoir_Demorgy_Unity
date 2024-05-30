using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum IAstate
{
    None,
    Idle,
    Patrol,
    PlayerSeen,
    PlayerNear
}



public class IA_controller : MonoBehaviour
{

    private IAstate _state = IAstate.None;
    public bool PlayerNear = false;
    public bool PlayerSeen = false;

    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    //[SerializeField] private GameObject _waypoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTransition();
        Behaviour();
    }


    private void Behaviour()
    {
        switch (_state)
        {
            case IAstate.None:
                //
                //
                break;

            case IAstate.Idle:
                //
                //
                break;

            case IAstate.Patrol:
                //find next destination
                _agent.SetDestination(patrolPoint);
                break;

            case IAstate.PlayerSeen:
                //
                //
                break;

            case IAstate.PlayerNear:
                //
                //
                break;
        }


    }

    private float timeInState = 0;
    private Vector3 patrolPoint;



    private void CheckTransition()
    {

        timeInState += Time.deltaTime;
        //print(timeInState);
        _animator.SetFloat("Speed", _agent.velocity.magnitude);

        switch (_state)
        {
            case IAstate.None:
                _state = IAstate.Idle;
                break;


            case IAstate.Idle:
                // je veux verifier si le player est proche --> playerNear

                if (timeInState >= 15)
                { 
                    _state = IAstate.Patrol;
                    timeInState = 0;
                    patrolPoint = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)).normalized * 5 + transform.position;
                    print(patrolPoint);
                }


                if (PlayerSeen)
                {
                    _state = IAstate.PlayerSeen;
                    _animator.SetBool("IsPlayerSeen?", true);
                    timeInState = 0;
                }

                break;


            case IAstate.Patrol:



                if (timeInState >= 15)
                {
                    _state = IAstate.Idle;
                    timeInState = 0;
                }


                if (PlayerSeen)
                {
                    _state = IAstate.PlayerSeen;
                    _animator.SetBool("IsPlayerSeen?", true);
                    timeInState = 0;
                }

                break;


            case IAstate.PlayerSeen:

                if (PlayerNear)
                {
                    _state =IAstate.PlayerNear;
                    _animator.SetBool("IsPlayerNear?", true);
                    timeInState = 0;
                }

                if (!PlayerSeen)
                {
                    _state = IAstate.Idle;
                    _animator.SetBool("IsPlayerSeen?", false);
                    timeInState = 0;
                }


                break;

            case IAstate.PlayerNear:

               if (!PlayerNear)
                {
                    _state = IAstate.PlayerSeen;
                    _animator.SetBool("IsPlayerNear?", false);
                    timeInState = 0;
                }

                break;



        }
    }

}
