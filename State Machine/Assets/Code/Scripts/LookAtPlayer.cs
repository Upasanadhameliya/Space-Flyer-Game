using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    private Transform playerPosition;

    void Start () {
        playerPosition = GameObject.Find("Player").transform;	
	}
	
	
	void LateUpdate () {
        transform.LookAt(playerPosition);	
	}
}
