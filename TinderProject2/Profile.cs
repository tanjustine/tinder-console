using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderProject2
{
    class Profile
    {
        private string personName;
        private int personAge;
        private char personGender;
        private int personLocation;
        private List<Profile> likes = new List<Profile>();
        private Profile[] matches = new Profile[MAX];
        private int numOfMatches;
        private UserSetting setting;
        private const int MAX = 10;

        public Profile(string name, char gender, int age, int location)
        {
            personName = name;
            personGender = gender;
            personAge = age;
            personLocation = location;
            numOfMatches = 0;
        }
        public string GetPersonName()
        {
            return personName;
        }
        public char GetPersonGender()
        {
            return personGender;
        }
        public int GetPersonAge()
        {
            return personAge;
        }
        public int GetPersonLocation()
        {
            return personLocation;
        }
        public void AddLikes(Profile name)
        {
            likes.Add(name);
        }
        public void AddMatches(Profile name)
        {
            matches[numOfMatches] = name;
        }
        public List<Profile> GetLikes()
        {
            return likes;
        }
        public Profile[] GetMatches()
        {
            return matches;
        }
        public void AddNumOfMatches()
        {
            numOfMatches++;
        }
        public UserSetting GetUserSetting()
        {
            return setting;
        }
        public void AddUserSetting(int ageS, int ageL, char gender, int kmS, int kmL)
        {
            setting = new UserSetting(ageS, ageL, gender, kmS, kmL);
        }
        public int GetNumMatches()
        {
            return numOfMatches;
        }
        public int GetMAX()
        {
            return MAX;
        }
        public void SubtractNumOfMatches()
        {
            numOfMatches--;
        }
    }
}
