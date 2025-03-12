using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Data
{
    [SerializeField]
    public List<Group> groups = new List<Group>();
    [SerializeField]
    public List<User> users = new List<User>();
    public Data()
    {
        //For chatGPT, add instances for groups and users,
        //I will use this for debug,
        //there should be 9 groups named:

        //Bezbednost, Donacije, Drustvene Mreze, Fakulteti i rektorat, House, Logistika, Mediji, Strategija

        ForDebug();

        DeleteInactive();
    }
    public void ForDebug()
    {
        User user1 = SignUp("user1", "pass123", "0001/2021", "Jana", "Micic");
        user1.experience = 29;
        SignUp("user2", "pass123", "0002/2022", "Milos", "Petrovic");
        SignUp("user3", "pass123", "0003/2023", "Ivan", "Rados");
        SignUp("user4", "pass123", "0004/2024", "Nikola", "Jankovic");

        string[] groupNames = {
            "Bezbednost", "Donacije", "Drustvene Mreze", "Fakulteti i rektorat",
            "Vesti", "Logistika", "Mediji", "Strategija", "Aktivnosti"
        };
        string[] groupDescriptions = {
"Radna grupa za bezbednost odgovorna je za osiguravanje sigurnosti svih studenata, regulisanje ljudi koji ulaze na fakultet, planiranje preventivnih mera i reagovanje u slucaju nesreca ili incidenata.",
"Radna grupa za donacije namenjena je radi efikasnijeg upravljanja donacijama, kao i evidentiranju trenutnih potreba na fakultetu.",
"Radna grupa za drustvene mreze kreira i upravlja sadrzajem na drustvenim mrezama, promovirajuci aktivnosti i poruke studenata kako bi se povecala vidljivost i angazman.",
"Radna grupa za komunikaciju s drugim fakultetima i rektoratom prenosi poruke i koordinira saradnju izmedju studenata razlicitih fakulteta u blokadi.",
"Vesti je namenjen za evidenciju svih novosti i obavestenja koji su dostupni svim ljudima u svakom trenutku",
"Radna grupa za logistiku odgovorna je za organizaciju i koordinaciju svih prakticnih aspekata dogadjanja, ukljucujuci opremu, prostor, transport i tehnicku podrsku.",
"Radna grupa za komunikaciju s medijima i javnoscu luzi da aktivno prenosi poruku studenata medijima i javnosti.",
"Radna grupa za strategiju razvija planove i ciljeve, usmeravajuci aktivnosti prema dugorocnim interesima studenata i osiguravajuci postizanje kljucnih rezultata.",
"Radna grupa za aktivnosti je namenjena za organizaciju dnevnih aktivnosti na fakultetu u cilju odrzavanja blokadnog duha i sto veceg broja ljudi na blokadi."
        };

        foreach (User user in users)
        {
        }

        List<(string, int)> user_role = new List<(string, int)>
            {
                ("0001/2021", 1),
                ("0002/2022", 0),
                ("0003/2023", 0),
                ("0004/2024", 0)
            }; //role is 0 or 1


        Task task1 = new Task("Priprema transparenata", "Dizajnirati i napraviti transparente sa porukama protesta", 5, 2, 1f, "2025-03-15");
        Task task2 = new Task("Koordinacija sa medijima", "Kontaktirati novinare i obavestiti ih o protestu", 2, 3, 2.5f, "2025-03-15");
        Task task3 = new Task("Obezbedjivanje hrane i vode", "Pronaci donatore i obezbediti hranu za ucesnike", 3, 2, 1f, "2025-03-15");
        Task task4 = new Task("Pravna podrska", "Povezati se sa advokatima i konsultovati se o pravnim aspektima blokade", 2, 4, 3.5f, "2025-03-15");
        Task task5 = new Task("Drustvene mreze", "Promovisati protest putem drustvenih mreza", 4, 2, 2.0f, "2025-03-15");
        Task task6 = new Task("Dezurstva na ulazima", "Organizovati timove koji ce dezurati na ulazima fakulteta", 6, 3, 6.0f, "2025-03-15");
        Task task7 = new Task("Pregovori sa upravom", "Formirati delegaciju koja ce pregovarati sa upravom fakulteta", 3, 4, 1f, "2025-03-15");
        Task task8 = new Task("Medicinska pomoc", "Obezbediti medicinsku podrsku za ucesnike protesta", 2, 3, 4.5f, "2025-03-15");

        List<Task> tasks = new List<Task> { task1, task2, task3, task4, task5, task6, task7, task8 };

        for (int i = 0; i < groupNames.Count(); i++)
        {
            Group group = new Group(groupNames[i], user_role, groupDescriptions[i], tasks);
            //group.Assign(groupNames[i], user_role, groupDescriptions[i]);
            groups.Add(group);
        }
    }
    public void DeleteInactive()
    {
        foreach (User user in users)
        {
            if (DateTime.Now - DateTime.Parse(user.lastActivity) > TimeSpan.FromDays(14))
            {
                users.Remove(user);
            }
        }
    }
    public string HouseNameToGroupKey(string houseName)
    {
        if (houseName.EndsWith(" Variant"))
        {
            return houseName.Substring(0, houseName.Length - " Variant".Length);
        }
        return houseName;
    }

    public Group GetGroupFromHouseName(string houseName)
    {
        string groupName = HouseNameToGroupKey(houseName);
        return FindGroupByName(groupName);
    }
    public User SignUp(string username, string password, string index, string name, string surename)
    {
        foreach (User user0 in users)
        {
            if (user0.username == username)
            {
                return null;
            }
        }
        string lastActivity = DateTime.Now.ToString();
        User user = new User(username, password, index, name, surename, 0, lastActivity, 0);
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
    public Group FindGroupByName(string name)
    {
        return groups.Find(g => g.name == name);
    }
    public User FindUserByIndex(string index)
    {
        return users.Find(u => u.index == index);
    }
}
[Serializable]
public class User
{
    public string username;
    public string password;
    public string index;//id
    public string name;
    public string surename;
    public int experience;
    public string lastActivity;
    public int rank;

    public User(string username, string password, string index, string name, string surename, int experience, string lastActivity, int rank)
    {
        this.username = username;
        this.password = password;
        this.index = index;
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
        if (experience < 35)
        {
            rank = 3;
        }
        else
            rank = 4;
        return;
    }
    public void AddExpirience(Task task)
    {
        experience += task.experience;
    }

}
[Serializable]
public enum Role
{
    Student = 0,
    Koordinator = 1,

}
[Serializable]
public enum Rank
{
    rank1 = 0,
    rank2 = 1,
    rank3 = 2,
    rank4 = 3,
}

[Serializable]
public class Group
{
    public string name;//id
    [SerializeField]
    public List<(string index, int role)> user_role;
    [SerializeField]
    public List<Task> tasks;
    [SerializeField]
    public List<Task> DoneTasks;
    [SerializeField]
    public string description;

    /*public void Assign(string name, List<(string index, int role)> group_role, string description)
    {
        DoneTasks = new List<Task>();

        this.name = name;
        this.user_role = group_role;
        this.description = description;
    }*/

    public Group(string name, List<(string index, int role)> group_role, string description, List<Task> tasks)
    {
        DoneTasks = new List<Task>();

        this.name = name;
        this.user_role = group_role;
        this.description = description;
        this.tasks = tasks;
    }

    public Group()
    {
    }

    public void SortByTime()
    {
        tasks.Sort((task1, task2) => DateTime.Parse(task1.timePublished).CompareTo(DateTime.Parse(task2.timePublished)));
    }

    public void DeleteTask(Task task)
    {
        DoneTasks.Add(task);
        tasks.Remove(task);
    }

    public void FinishTask(Task task, User user)//treba admin da approveuje
    {
        user.AddExpirience(task);
        tasks.Remove(task);
    }

    public bool IsAdmin(string index)
    {
        foreach ((string index, int role) user in user_role)
        {

            if (user.index == index && user.role == 1) { return true; }
        }

        return false;
    }
    public bool IsInGroup(string index)
    {
        foreach ((string index, int role) user in user_role)
        {

            if (user.index == index) { return true; }
        }

        return false;
    }

}
[Serializable]
public class Task
{
    //public int id;
    public string timePublished;
    public string name;
    public string description;
    public int maxUsers;
    [SerializeField]
    public List<User> users;
    public int experience;//isto kao task Difficulty
    [SerializeField]
    public float expectedDurationHours;
    public string dateOfExecution;//"2025-03-12"

    public Task(string name, string description, int maxUsers, int experience, float expectedDurationHours, string dateOfExecution)
    {
        this.name = name;
        this.description = description;
        this.maxUsers = maxUsers;
        this.experience = (int)Mathf.Clamp(experience, 1, 4);
        this.expectedDurationHours = expectedDurationHours;

        timePublished = DateTime.Now.ToString();
        users = new List<User>();

        //group.tasks.Add(this);
    }

    public void AcceptTask(User user)
    {
        if (users.Count < maxUsers)
        {
            users.Add(user);
        }
    }


}
[Serializable]
public enum TaskDifficulty
{
    Easy = 0,
    Normal = 1,
    Hard = 2,
    HardAndLong = 3,
}


