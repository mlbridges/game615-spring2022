using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplay : MonoBehaviour
{
    public PointCounter score;
    Text screenScore;

    // Start is called before the first frame update
    void Start()
    {
        screenScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        screenScore.text = "Score: " + score.scoreValue;
    }
}
