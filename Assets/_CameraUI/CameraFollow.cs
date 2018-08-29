using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] GameObject followTarget;
	
	void LateUpdate () {
        transform.position = followTarget.transform.position;
	}
}
