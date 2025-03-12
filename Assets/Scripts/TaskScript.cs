using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public Image colorCode;
    public TMP_Text title;
    public TMP_Text date;
    public Tasks tasks1;

    public void ClickedMe()
    {
        Task task = BootManager.Instance.data.groups[tasks1.house.houseID].tasks[this.transform.GetSiblingIndex()];
        tasks1.SetText(task.description, task.experience);

    }

    public void SetStrings(Task task)
    {
        title.text = task.name;
        date.text = task.timePublished;
    }
}
