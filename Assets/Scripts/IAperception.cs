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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckDistance()
    {

        _checkDirection = _Player.transform.position - _Pawn.transform.position;
        RaycastHit hit;


        if (Physics.Raycast(_Pawn.transform.position, _checkDirection, out hit, _distance))
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>())
            {
                _Pawn.GetComponentInChildren<IA_controller>().PlayerNear = true;

            }
            else
            {
                _Pawn.GetComponentInChildren<IA_controller>().PlayerNear = false;
            }
        }
        else
        {
            _Pawn.GetComponentInChildren<IA_controller>().PlayerNear = false;
        }

    }

}
