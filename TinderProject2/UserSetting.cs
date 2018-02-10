using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderProject2
{
    public class UserSetting
    {
        private int ageStart;
        private int ageLimit;
        private char showMe;
        private int kmStart;
        private int kmLimit;

        public UserSetting(int ageS, int ageL, char gender, int kmS, int kmL)
        {
            ageStart = ageS;
            ageLimit = ageL;
            showMe = gender;
            kmStart = kmS;
            kmLimit = kmL;
        }
        public void SetShowMe(char interested)
        {
            showMe = interested;
        }
        public void SetAgeLimit(int age)
        {
             ageLimit = age;
        }
        public void SetAgeStart(int age)
        {
                ageStart = age;
        }
        public void SetKMLimit(int km)
        {
            if (km > kmStart)
            {
                kmLimit = km;
            }
        }
        public void SetKMStart(int km)
        {
            if (km < kmLimit && km >= 0)
            {
                kmStart = km;
            }
        }
        public char GetShowMe()
        {
            return showMe;
        }
        public int GetAgeLimit()
        {
            return ageLimit;
        }
        public int GetKMLimit()
        {
            return kmLimit;
        }
        public int GetAgeStart()
        {
            return ageStart;
        }
        public int GetKMStart()
        {
            return kmStart;
        }
    }
}
