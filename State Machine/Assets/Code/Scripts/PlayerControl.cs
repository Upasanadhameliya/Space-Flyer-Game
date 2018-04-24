﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float setupSpinSpeed = 50.0f;
    public float speed = 16.0f;
    public float rotationSpeed = 0.60f;
    public float hoverPower = 3.5f;

    public Color red = Color.red;
    public Color cyan = Color.cyan;
    public Color green = Color.green;
    public Color yellow = Color.yellow;
    public Color white = Color.white;
    private Renderer rend;
    private GameObject blob;

    private Rigidbody rb;

    private void FixedUpdate()
    {
        float foreAndAft = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * speed;
        rb.AddRelativeForce(0, 0, foreAndAft);
        rb.AddTorque(0, rotation, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        rb.AddForce(Vector3.up * hoverPower);
    }

    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	
	public void PlayerUpdate () {
		
	}

    public void PickedColor(Color playerColor)
    {
        blob = GameObject.Find("Blob");
        rend = GetComponent<Renderer>();
        rend.material.color = playerColor;
        rend = blob.GetComponent<Renderer>();
        if (playerColor == red || playerColor == cyan)
            rend.material.color = Color.yellow;
        else
            rend.material.color = Color.magenta;
    }
}