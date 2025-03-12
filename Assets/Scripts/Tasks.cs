using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public TMP_Text description;
    public TMP_Text scoreText;
    public House house;

    public void SetText(string desc, int score)
    {
        description.text = desc;
        scoreText.text = "Score: " + score.ToString();
    }

}
