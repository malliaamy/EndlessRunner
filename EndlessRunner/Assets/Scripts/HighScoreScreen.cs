using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScoreScreen : MonoBehaviour
{
    float distanceHighscore;
    int coinHighscore;

    public TextMeshProUGUI distanceHighscoreText;
    public TextMeshProUGUI coinAmountText;
    // Start is called before the first frame update
    void Start()
    {
        distanceHighscore = PlayerPrefs.GetFloat("distanceScore");
        coinHighscore = PlayerPrefs.GetInt("coinScore");

        distanceHighscoreText.text = distanceHighscore.ToString() + "m";
        coinAmountText.text = coinHighscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
