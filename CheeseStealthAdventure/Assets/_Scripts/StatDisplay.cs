using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public PlayerStats Stats;

    Text ScreenLife;
    // Start is called before the first frame update
    void Start()
    {
        ScreenLife = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenLife.text = "Lives: " + Stats.PlayerLives + "\n" + "Cheeses Rescued: " + Stats.PlayerCollectibles;
    }
}
