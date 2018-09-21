using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pellegrin.Characters
{

    public class AIController : UnitController {


        NavMeshAgent navMeshAgent;
        [SerializeField] GameObject targetToChase; //TODO remove to find own destination

        [Header("Debug")]
        [SerializeField] bool DEBUG_DRAWPATH;   //TODO is this needed?

	    void Start () {

            navMeshAgent = GetComponent<NavMeshAgent>();
        
	    }
	
	    void Update () {


            //Set AI Nav Destination
            MoveTo(targetToChase.transform.position);

            //Moving Animation Logic
            IsMoving = navMeshAgent.velocity.magnitude >= 0.1f;
            

        }

        void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
        }

        private void OnDrawGizmos()
        {
            if (DEBUG_DRAWPATH && navMeshAgent != null)
            {
                //Draw Path
                var path = navMeshAgent.path;
                Vector3 prevPosition = transform.position;
                foreach (var corner in path.corners)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawCube(corner, Vector3.one * .5f);
                    Gizmos.color = Color.black;
                    Gizmos.DrawLine(prevPosition, corner);
                    prevPosition = corner;
                }
            }

        }

    }

}
