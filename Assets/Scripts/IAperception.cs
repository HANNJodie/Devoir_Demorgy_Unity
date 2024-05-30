using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAperception : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    [SerializeField] private GameObject _Pawn;
    private Vector3 _checkDirection;
    [SerializeField] private float _distance;
    [SerializeField] private float _viewDistance;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {

        _checkDirection = _Player.transform.position - _Pawn.transform.position;
        RaycastHit hit;


        if (Physics.Raycast(_Pawn.transform.position, _checkDirection, out hit, _distance))
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>())
            {
                _Pawn.GetComponent<IA_controller>().PlayerNear = true;
                //print("PlayerNear");
  

            }
            else
            {
                _Pawn.GetComponent<IA_controller>().PlayerNear = false;
            }
        }
        else
        {
            _Pawn.GetComponent<IA_controller>().PlayerNear = false;
        }

        if (Physics.Raycast(_Pawn.transform.position, _checkDirection, out hit, _viewDistance))
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>())
            {
                _Pawn.GetComponent<IA_controller>().PlayerSeen = true;
                //print("PlayerSeen");


            }
            else
            {
                _Pawn.GetComponent<IA_controller>().PlayerSeen = false;
            }
        }
        else
        {
            _Pawn.GetComponent<IA_controller>().PlayerSeen = false;
        }


    }

}
