using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public TMP_Text description;
    public TMP_Text scoreText;
    public House house;
    public GameObject TaskPrefab;

    private void Start()
    {
        AddTask(new Task("BOB", "on voli banane", 6, 3, 2, new Group()));
        AddTask(new Task("BOB", "on voli banane", 6, 3, 2, new Group()));
        AddTask(new Task("BOB", "on voli banane", 6, 3, 2, new Group()));
    }

    public void SetText(string desc, int score)
    {
        description.text = desc;
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddTask(Task task)
    {
        TaskScript taskScript = Instantiate(TaskPrefab, transform).GetComponent<TaskScript>();
        taskScript.SetStrings(task);
    }

}
