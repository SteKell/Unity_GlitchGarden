using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject parent;
    
    // Use this for initialization
	void Start ()
    {
        parent = GameObject.Find("Defenders");

        if(!parent)
        {
            parent = new GameObject("Defenders");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate (defender, roundedPos, zeroRot) as GameObject;

        newDef.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
