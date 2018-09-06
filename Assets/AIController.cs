using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {


    NavMeshAgent navMeshAgent;
    [SerializeField] GameObject targetToChase;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
	}
	
	// Update is called once per frame
	void Update () {
        navMeshAgent.destination = targetToChase.transform.position;
    }
}
