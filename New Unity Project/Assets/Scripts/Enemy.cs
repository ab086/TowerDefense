﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 12f;

    private Transform target;
    private int waypointIndex = 0;


	// Use this for initialization
	void Start () {
        target = Waypoints.waypoints[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); // Normalized fixes the speed

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
	}

    void GetNextWaypoint()
    {

        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
