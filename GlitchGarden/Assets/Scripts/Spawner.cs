using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray; // All the attackers the spawner can spawn
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // attacker can spwan after 
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if(isTimeToSpawn (thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn (GameObject myGameObject)
    {
        GameObject thisAttacker = Instantiate(myGameObject) as GameObject;
        thisAttacker.transform.parent = transform; // parent attacker to spawner 
        thisAttacker.transform.position = transform.position; // position attacker at point of spawner
        
    }

    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float frequency = attacker.secondsCanAppearAfter;
        float spawnsPerSecond = 1 / frequency;

        if(Time.deltaTime > frequency)
        {
            Debug.LogWarning("Spwan rate capped by frame rate"); // if the framerate is too slow
        }

        // Random spawner time. Must be within the threshold of the Appearance Frequency
        float threshold = spawnsPerSecond * Time.deltaTime / 5; // devided by 5 because there are 5 spawn spots 

        if(Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}
