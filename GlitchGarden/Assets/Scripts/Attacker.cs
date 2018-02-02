using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject cyrrentTarget;
    
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	
	}

    void OnTriggerEnter2D ()
    {

        string defender = name;
    }

    public void SetSpeed (float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at time of attack hit
    public void StrikeCurrentTarget (float damage)
    {
        Debug.Log(name + " caused damage: " + damage);
    }

    public void Attack (GameObject obj)
    {
        cyrrentTarget = obj;
    }
}
