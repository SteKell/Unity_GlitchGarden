using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

    public enum Status {SUCCESS, FAILURE};

    private int startAmount = 100;
    private Text starsText;

    // Use this for initialization
    void Start()
    {
        starsText = GetComponent<Text>();
        UpdateDisplay();

    }

    public void AddStars(int amount)
    {
        startAmount += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if(startAmount >= amount)
        {
            startAmount -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        starsText.text = startAmount.ToString();
    }

}
