using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private Animator _animator;

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
                //
                //
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





    private void CheckTransition()
    {
        switch (_state)
        {
            case IAstate.None:

                break;


            case IAstate.Idle:
                // je veux verifier i le player est proche --> playerNear
                if (PlayerNear)
                {
                    _state = IAstate.PlayerNear;
                    _animator.SetBool("IsPlayerNear?", true);
                }
                break;


            case IAstate.Patrol:

                if (PlayerNear)
                {
                    _state = IAstate.PlayerNear;
                    _animator.SetBool("IsPlayerNear?", true);
                }
                break;


            case IAstate.PlayerSeen:

                if (PlayerNear)
                {
                    _state =IAstate.PlayerNear;
                    _animator.SetBool("IsPlayerNear?", true);
                }
                break;

            case IAstate.PlayerNear:

               if (!PlayerNear)
                {
                    _state = IAstate.Patrol;
                    _animator.SetBool("IsPlayerNear?", false);
                }

                break;



        }
    }

}
