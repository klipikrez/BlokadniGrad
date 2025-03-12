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
    public int currentTask = -52;

    private void Start()
    {
        foreach (Task task in BootManager.Instance.data.groups[house.houseID].tasks)
        {
            AddTask(task);
        }
    }

    public void SetText(string desc, int score, int from)
    {
        currentTask = from;
        description.text = desc;
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddTask(Task task)
    {
        TaskScript taskScript = Instantiate(TaskPrefab, transform).GetComponent<TaskScript>();
        taskScript.SetStrings(task);
        taskScript.tasks1 = this;
    }

    public Group GetGroup()
    {
        return BootManager.Instance.data.GetGroupFromHouseName(house.gameObject.name);
    }

    public void RemoveTask()
    {
        if (currentTask < 0) return;
        currentTask = -52;
        BootManager.Instance.data.groups[house.houseID].DeleteTask(BootManager.Instance.data.groups[house.houseID].tasks[currentTask]);
        Destroy(transform.GetChild(currentTask).gameObject);
    }

}
