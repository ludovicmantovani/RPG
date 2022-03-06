using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovementController : MonoBehaviour
{
    private Vector3 _targetPosition;
    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        // Recuperation du nav mesh agent
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _targetPosition = transform.position;
    }

    void Update()
    {
        SetDestination();
        Locomotion();
    }


    private void SetDestination()
    {
        // Detection du clik
        if (Input.GetMouseButton(0))
        {
            // Lancement rayon passant part souris et par ecran de camera
            Ray currentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(currentRay.origin, currentRay.direction * 100);
            RaycastHit hit;
            // Test si impact
            if (Physics.Raycast(currentRay, out hit))
            {
                // Definition de la position de la cible a atteindre
                _targetPosition = hit.point;
            }
        }
    }

    private void Locomotion()
    {
        if (_navMeshAgent)
        {
            // Definition de l'objet cible comme point de destination
            _navMeshAgent.destination = _targetPosition;
        }
    }
}
