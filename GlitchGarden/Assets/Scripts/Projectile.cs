using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed, damage;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        Attacker attacker = collision.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.setHealth(damage);
            Destroy(gameObject);
        }
    }
}
