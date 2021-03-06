﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    public float secondsCanAppearAfter; // average number of seconds between attacker appearances

    private float currentSpeed; // the speed that attacker moves
    private GameObject currentTarget; // defender the attacker is attacking
    private Animator anim;
    
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

       if(!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
	
	}

    void OnTriggerEnter2D ()
    {

    }

    public void SetSpeed (float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at time of attack hit
    public void StrikeCurrentTarget (float damage)
    {
        if (currentTarget)
        {
           Health health = currentTarget.GetComponent<Health>();

            if(health)
            {
                health.setHealth(damage);
            }
        }
    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;

    }
}
