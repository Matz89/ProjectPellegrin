using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pellegrin.Characters
{

    public class AIController : UnitController {


        NavMeshAgent navMeshAgent;
        [SerializeField] GameObject targetToChase;

	    // Use this for initialization
	    void Start () {
            navMeshAgent = GetComponent<NavMeshAgent>();
        
	    }
	
	    // Update is called once per frame
	    void Update () {

            //Find destination to move to
            navMeshAgent.destination = targetToChase.transform.position;
        }

    }

}
