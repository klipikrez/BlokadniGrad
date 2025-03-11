using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class AllData
    {
        public List<Faculty> faculties = new List<Faculty>();
        public AllData ()
        {

        }
    }

    public class Faculty
    { 
        public List<Group> groups = new List<Group>();
    }


    public class User
    {
        public string index;//id
        public string faculty;
        public string name;
        public string surename;
        public int expirience;
        public DateTime lastActivity;
        public Rank rank;

        public void UpdateRank()
        {
            
            if (expirience < 5)
            {
                rank = Rank.rank1;
            } else
            if (expirience < 15)
            {
                rank = Rank.rank2;
            }
            else
            if (expirience < 25)
            {
                rank = Rank.rank3;
            }
            else
            if (expirience < 45)
            {
                rank = Rank.rank4;
            }
            return;


        }
        public void AddExpirience(Task task)
        {
            expirience += task.expirience;
        }

    }

    public enum Role
    {
        Student = 0,
        Admin = 1,

    }
    public enum Rank
    { 
        rank1 = 0,
        rank2 = 1,
        rank3 = 2,
        rank4 = 3,
    }


    public class Group
    {
        public string name;//id
        public string faculty;
        public List<(string index, Role role)> group_role;
        public List<Task> tasks;
        public List<Task> DoneTasks;

        public void SortByTime()
        {
            tasks.Sort((task1, task2) => task1.timePublished.CompareTo(task2.timePublished));
        }

        public void DeleteTask(Task task)
        {
            DoneTasks.Add(task);
            tasks.Remove(task);
        }

    }
    public class Task
    {
        public int id;
        public DateTime timePublished;
        public string name;
        public string description;
        public int maxUsers;
        public List<User> users;
        public int expirience;
        public Group group;
        public float expectedDurationHours;
        public TaskDifficulty taskDifficulty;

        public void AcceptTask(User user)
        {
            if (users.Count < maxUsers)
            {
                users.Add(user);
            }
        }

        public void FinishTask (User user)//treba admin da approveuje
        {
            user.AddExpirience(this);
            group.DeleteTask(this);
        }

    }

    public enum TaskDifficulty
    {
        Easy = 0,
        Normal = 1,
        Hard = 2,
    }

    public enum TaskUrgency
    {
        Easy = 0,
        Normal = 1,
        Hard = 2,
    }

}
