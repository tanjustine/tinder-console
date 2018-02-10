using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderProject2
{
    class Process
    {
        Random number = new Random();
        private List<Profile> peopleList = new List<Profile>();
        private List<Profile> possibleMatches;
        public void AddPerson(string name)
        {
            if (FindinPeopleList(name) > -1)
            {
                Console.WriteLine("{0} HAS ALREADY BEEN REGISTERED.\n", name.ToUpper());
            }
            else
            {
                int age;
                Console.Write("Age: ");
                age = int.Parse(Console.ReadLine());
                if (age >= 18)
                {
                    char gender;
                    int location;
                    Console.Write("Gender: ");
                    gender = char.Parse(Console.ReadLine());
                    Console.Write("Location (in km): ");
                    location = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Enter your preferences");
                    Console.WriteLine("M for MALES, F for FEMALES, B for BOTH");
                    Console.Write("Show Me: ");
                    char showMeResponse = char.Parse(Console.ReadLine());
                    Console.Write("Set Age Start: ");
                    int ageResponseStart = int.Parse(Console.ReadLine());
                    if (ageResponseStart >= 18)
                    {
                        Console.Write("Set Age Limit: ");
                        int ageResponseLimit = int.Parse(Console.ReadLine());
                        if (ageResponseLimit >= ageResponseStart)
                        {
                            Console.Write("Set Distance Start (km): ");
                            int kmResponseStart = int.Parse(Console.ReadLine());
                            if (kmResponseStart >= 0)
                            {
                                Console.Write("Set Distance Limit (km): ");
                                int kmResponseLimit = int.Parse(Console.ReadLine());
                                peopleList.Add(new Profile(name, gender, age, location));
                                int index = FindinPeopleList(name);
                                peopleList[index].AddUserSetting(ageResponseStart, ageResponseLimit, showMeResponse, kmResponseStart, kmResponseLimit);
                                Console.WriteLine("{0} HAS BEEN SUCCESSFULLY REGISTERED.\n", name.ToUpper());
                            }
                            else
                            {
                                Console.WriteLine("DISTANCE START IS TOO LOW.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("AGE START IS GREATER THAN AGE LIMIT.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("AGE START IS TOO LOW.");
                    }
                }
                else
                {
                    Console.WriteLine("PERSON IS TOO YOUNG TO JOIN.\n");
                }
            }
        }

        public int FindinPeopleList(string name)
        {
            int index = -1;
            if (peopleList != null)
            {
                for (int i = 0; i < peopleList.Count(); i++)
                {
                    if (string.Equals(peopleList[i].GetPersonName(), name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        index = i;
                    }
                }
            }
            return index;
        }
        public Profile GetPerson(int index)
        {
            return peopleList[index];
        }
        public List<Profile> GetPeopleList()
        {
            return peopleList;
        }
        public void ShowUserSettings(Profile name)
        {
            Console.WriteLine("Show Me: {0}", name.GetUserSetting().GetShowMe());
            Console.WriteLine("Age Range: {0} - {1}", name.GetUserSetting().GetAgeStart(), name.GetUserSetting().GetAgeLimit());
            Console.WriteLine("Distance Range: {0}km - {1}km", name.GetUserSetting().GetKMStart(), name.GetUserSetting().GetKMLimit());
        }
        public void EditUserSettings(Profile name)
        {
            ShowUserSettings(name);
            Console.WriteLine();
            int response;
            Console.Write("1 Change Show Me \n2 Change Age Range \n3 Change KM Range \nEnter choice: ");
            response = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (response)
            {
                case 1:
                    Console.WriteLine("M for MALES, F for FEMALES, B for BOTH");
                    Console.Write("Show Me: ");
                    char showMeResponse = char.Parse(Console.ReadLine());
                    name.GetUserSetting().SetShowMe(showMeResponse);
                    Console.WriteLine("SHOW ME SETTINGS HAVE CHANGED.");
                    break;
                case 2:
                    Console.Write("Set Age Start: ");
                    int ageResponseStart = int.Parse(Console.ReadLine());
                    if (ageResponseStart >= 18)
                    {
                        Console.Write("Set Age Limit: ");
                        int ageResponseLimit = int.Parse(Console.ReadLine());
                        if (ageResponseLimit >= ageResponseStart)
                        {
                            name.GetUserSetting().SetAgeStart(ageResponseStart);
                            name.GetUserSetting().SetAgeLimit(ageResponseLimit);
                            Console.WriteLine("AGE RANGE HAS CHANGED.");
                        }
                        else
                        {
                            Console.WriteLine("AGE START IS GREATER THAN AGE LIMIT.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("AGE START IS TOO LOW.");
                    }
                    break;
                case 3:
                    Console.Write("Set Distance Start (km): ");
                    int kmResponseStart = int.Parse(Console.ReadLine());
                    if (kmResponseStart < 0)
                    {
                        Console.WriteLine("DISTANCE START IS TOO LOW.");
                    }
                    else
                    {
                        name.GetUserSetting().SetKMStart(kmResponseStart);
                        Console.Write("Set Distance Limit (km): ");
                        int kmResponseLimit = int.Parse(Console.ReadLine());
                        name.GetUserSetting().SetKMLimit(kmResponseLimit);
                        Console.WriteLine("DISTANCE LIMIT HAS CHANGED.");
                    }
                    break;
                default:
                    Console.WriteLine("INVALID INPUT.");
                    break;
            }
        }
        public void ShowPeopleList(Profile name)
        {
            if (peopleList.Count() <= 1)
            {
                Console.WriteLine("YOUR LIST OF PEOPLE IS EMPTY.\n");
            }
            else
            {
                Console.WriteLine("ID\tNAME\t\tGENDER\tAGE\tLOCATION");
                for (int i = 0; i < peopleList.Count(); i++)
                {
                    int index = 0;
                    if (name.GetPersonName() != peopleList[i].GetPersonName())
                    {
                        index += 1;
                        Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}", index, peopleList[i].GetPersonName(), peopleList[i].GetPersonGender(), peopleList[i].GetPersonAge(), peopleList[i].GetPersonLocation());
                    }
                }
                Console.WriteLine("TOTAL REGISTERED: {0}", peopleList.Count());
            }
        }
        public int FindInMatches(Profile match, Profile name)
        {
            int index = -1;
            if (name.GetMatches() != null)
            {
                for (int i = 0; i < name.GetNumMatches(); i++)
                {
                    if (string.Equals(name.GetMatches()[i].GetPersonName(), match.GetPersonName(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        index = i;
                    }
                }
            }
            return index;
        }
        public int FindInLikes(Profile match, Profile name)
        {
            int index = -1;
            if (name.GetLikes().Count() > 0)
            {
                for (int i = 0; i < name.GetLikes().Count(); i++)
                {
                    if (string.Equals(name.GetLikes()[i].GetPersonName(), match.GetPersonName(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        index = i;
                    }
                }
            }
            return index;
        }
        public bool CheckGender(Profile match, Profile name)
        {
            bool check = false;
            if (match.GetUserSetting().GetShowMe() == 'B' && name.GetUserSetting().GetShowMe() == 'B')
            {
                check = true;
            }
            else if ((match.GetUserSetting().GetShowMe() == 'B' && name.GetUserSetting().GetShowMe() == match.GetPersonGender()) || (name.GetUserSetting().GetShowMe() == 'B' && match.GetUserSetting().GetShowMe() == name.GetPersonGender()))
            {
                check = true;
            }
            else if (match.GetUserSetting().GetShowMe() == name.GetPersonGender() && name.GetUserSetting().GetShowMe() == match.GetPersonGender())
            {
                check = true;
            }
            return check;
        }
        public List<Profile> CheckMatch(Profile name)
        {
            possibleMatches = new List<Profile>();
            for (int i = 0; i < peopleList.Count(); i++ )
            {
                if ((CheckGender(peopleList[i], name)) && (name.GetPersonName().ToUpper() != peopleList[i].GetPersonName().ToUpper())) // Gender and same person
                {
                    if ((peopleList[i].GetPersonAge() <= name.GetUserSetting().GetAgeLimit() && peopleList[i].GetPersonAge() >= name.GetUserSetting().GetAgeStart()) && (name.GetPersonAge() <= peopleList[i].GetUserSetting().GetAgeLimit() && name.GetPersonAge() >= peopleList[i].GetUserSetting().GetAgeStart()))// age
                    {
                        if ((peopleList[i].GetPersonLocation() <= name.GetUserSetting().GetKMLimit() && peopleList[i].GetPersonLocation() >= name.GetUserSetting().GetKMStart()) && (name.GetPersonLocation() <= peopleList[i].GetUserSetting().GetKMLimit() && name.GetPersonLocation() >= peopleList[i].GetUserSetting().GetKMStart())) // distance 
                        {
                            if ((FindInMatches(peopleList[i], name) <= -1) && (FindInLikes(peopleList[i], name) <= -1)) // if already liked or if matched
                            {
                                possibleMatches.Add(peopleList[i]);
                            }
                        }
                    }
                }
            }
            return possibleMatches;
        }
        public void MatchPerson(Profile name)
        {
            if (name.GetNumMatches() >= name.GetMAX())
            {
                Console.WriteLine("YOUR MATCHES ARE FULL.");
            }
            else if (peopleList.Count() <= 1)
            {
                Console.WriteLine("NO MATCHES AVAILABLE.");
            }
            else
            {
                ShowUserSettings(name);
                if (CheckMatch(name) != null)
                {
                    for (int i = 0; i < possibleMatches.Count(); i++)
                    {
                        Console.WriteLine("\nName: {0} \nAge: {1} \nGender: {2} \nLocation: {3}", possibleMatches[i].GetPersonName(), possibleMatches[i].GetPersonAge(), possibleMatches[i].GetPersonGender(), possibleMatches[i].GetPersonLocation());
                        Console.WriteLine();
                        Console.WriteLine("1 Like \n2 No");
                        Console.Write("Enter choice: ");
                        int response = int.Parse(Console.ReadLine());
                        if (response == 1)
                        {
                            if (FindInLikes(name, possibleMatches[i]) > -1)
                            {
                                name.AddMatches(possibleMatches[i]);
                                name.AddNumOfMatches();
                                possibleMatches[i].AddMatches(name);
                                possibleMatches[i].AddNumOfMatches();
                                Console.WriteLine("{0} IS A MATCH!", possibleMatches[i].GetPersonName());
                                possibleMatches[i].GetLikes().Remove(name);
                                //Unlike
                            }
                            else
                            {
                                name.AddLikes(possibleMatches[i]);
                                Console.WriteLine("{0} HAS BEEN LIKED!", possibleMatches[i].GetPersonName());
                            }
                        }
                    }
                    if (possibleMatches.Count() <= 0)
                    {
                        Console.WriteLine("\nNO MATCHES AVAILABLE.");
                    }
                }
                else
                {
                    Console.WriteLine("\nNO MATCHES AVAILABLE.");
                }
            }
        }
        public void ShowMatches(Profile name)
        {
            if (name.GetNumMatches() == 0)
            {
                Console.WriteLine("YOU HAVE NO MATCHES.");
            }
            else
            {
                Console.WriteLine("ID\tNAME\t\t\tGENDER\tAGE\tLOCATION");
                for (int i = 0; i < name.GetNumMatches(); i++)
                {
                    int index = i + 1;
                    Console.WriteLine("{0}\t{1}\t\t\t{2}\t{3}\t{4}", index, name.GetMatches()[i].GetPersonName(), name.GetMatches()[i].GetPersonGender(), name.GetMatches()[i].GetPersonAge(), name.GetMatches()[i].GetPersonLocation());
                }
                Console.WriteLine("TOTAL MATCHES: {0}", name.GetNumMatches());
            }
        }
        public void Unmatch(Profile name)
        {
            ShowMatches(name);
            if (name.GetNumMatches() > 0)
            {
                Console.Write("Enter ID: ");
                int response = int.Parse(Console.ReadLine());
                if (response > name.GetNumMatches() || response <= 0)
                {
                    Console.WriteLine("INVALID ID.");
                }
                else
                {
                    DeleteMatch(FindInMatches(name, name.GetMatches()[response - 1]), name.GetMatches()[response - 1]);
                    DeleteMatch((response - 1), name); // Delete on one end
                    Console.WriteLine("THE MATCH HAS BEEN DELETED.");
                }
            }
        }
        public void DeleteMatch(int i, Profile name)
        {
            for (int index = i; index < name.GetNumMatches(); index++)
            {
                if (index + 1 < name.GetNumMatches())
                {
                    name.GetMatches()[index] = name.GetMatches()[index + 1];
                }
                if (index + 1 == name.GetNumMatches())
                {
                    name.GetMatches()[index] = null;
                    name.SubtractNumOfMatches();
                    break;
                }
            }
        }
        public void ShowLikes(Profile name)
        {
            if (name.GetLikes().Count() == 0)
            {
                Console.WriteLine("YOU HAVE NO LIKES.");
            }
            else
            {
                Console.WriteLine("ID\tNAME\t\t\tGENDER\tAGE\tLOCATION");
                for (int i = 0; i < name.GetLikes().Count(); i++)
                {
                    int index = i + 1;
                    Console.WriteLine("{0}\t{1}\t\t\t{2}\t{3}\t{4}", index, name.GetLikes()[i].GetPersonName(), name.GetLikes()[i].GetPersonGender(), name.GetLikes()[i].GetPersonAge(), name.GetLikes()[i].GetPersonLocation());
                }
                Console.WriteLine("TOTAL LIKES: {0}", name.GetLikes().Count());
            }
        }
    }
}
