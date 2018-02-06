using UnityEngine;
using System.Collections;

public class Gravestone : MonoBehaviour {

    private Animator anim;
    private Defender defender;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        defender = GetComponent<Defender>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            anim.SetBool("isAttached", true);
        }
        else
        {
            anim.SetBool("isAttached", false);
        }
    }

}
