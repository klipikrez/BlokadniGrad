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
        public List<Group> groups = new List<Group>();
        public List<User> users = new List<User>();
        public AllData()
        {

        }
        public User SignUp(string username, string password, string index, string faculty, string name, string surename)
        {
            foreach (User user0 in users)
            {
                if (user0.username == username)
                {
                    return null;
                }
            }
            string lastActivity = DateTime.Now.ToString();
            User user = new User(username, password, index, faculty, name, surename, 0, lastActivity, 0);
            users.Add(user);
            return user;
        }
        public User LogIn(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.username == username && user.password == password)
                {
                    return user;
                }
            }
            return null;
        }
    }

    public class User
    {
        public string username;
        public string password;
        public string index;//id
        public string faculty;
        public string name;
        public string surename;
        public int experience;
        public string lastActivity;
        public int rank;

        public User(string username, string password, string index, string faculty, string name, string surename, int experience, string lastActivity, int rank)
        {
            this.username = username;
            this.password = password;
            this.index = index;
            this.faculty = faculty;
            this.name = name;
            this.surename = surename;
            this.experience = experience;
            this.lastActivity = lastActivity;
            this.rank = rank;

        }

        public void UpdateRank()
        {

            if (experience < 5)
            {
                rank = 1;
            }
            else
            if (experience < 15)
            {
                rank = 2;
            }
            else
            if (experience < 25)
            {
                rank = 3;
            }
            else
            if (experience < 45)
            {
                rank = 4;
            }
            return;
        }
        public void AddExpirience(Task task)
        {
            experience += task.experience;
        }

    }

    public enum Role
    {
        Student = 0,
        Koordinator = 1,

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
        public List<(string index, int role)> group_role;
        public List<Task> tasks;
        public List<Task> DoneTasks;

        public void SortByTime()
        {
            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    DateTime vreme1 = DateTime.Parse(tasks[i].timePublished); // Pretvaranje stringa u DateTime
                    DateTime vreme2 = DateTime.Parse(tasks[j].timePublished);

                    if (vreme1 > vreme2) // Ako je vreme1 posle vreme2, zameni mesta
                    {
                        Task temp = tasks[i];
                        tasks[i] = tasks[j];
                        tasks[j] = temp;
                    }
                }
            }
        }

        public void DeleteTask(Task task)
        {
            DoneTasks.Add(task);
            tasks.Remove(task);
        }

    }
    public class Task
    {
        //public int id;
        public string timePublished;
        public string name;
        public string description;
        public int maxUsers;
        public List<User> users;
        public int experience;//isto kao task Difficulty
        public Group group;
        public float expectedDurationHours;

        public Task(string name, string description, int maxUsers, int experience, float expectedDurationHours, Group group)
        {
            experience = (int)Mathf.Clamp(experience, 1, 4);

            this.name = name;
            this.description = description;
            this.maxUsers = maxUsers;
            this.experience = experience;
            this.expectedDurationHours = expectedDurationHours;
            this.group = group;

            timePublished = DateTime.Now.ToString();
            users = new List<User>();

            group.tasks.Add(this);
        }

        public void AcceptTask(User user)
        {
            if (users.Count < maxUsers)
            {
                users.Add(user);
            }
        }

        public void FinishTask(User user)//treba admin da approveuje
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

