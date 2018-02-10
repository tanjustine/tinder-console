using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            int profileResponse;
            Process abby = new Process();
            do
            {
                Console.WriteLine("=====WELCOME TO TINDER!=====");
                Console.Write("1 for Register\n2 for Login\n0 to QUIT \nEnter choice: ");
                profileResponse = int.Parse(Console.ReadLine());

                switch(profileResponse)
                {
                    case 1:
                        Console.Write("\n=====REGISTER=====\nName: ");
                        abby.AddPerson(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("\n=====LOGIN=====");
                        if (abby.GetPeopleList().Count() == 0)
                        {
                            Console.WriteLine("YOU HAVE NOT REGISTERED ANYONE YET.\n");
                        }
                        else
                        {
                            Console.Write("Name: ");
                            string loginName = Console.ReadLine();
                            int index = abby.FindinPeopleList(loginName);
                            if (index > -1)
                            {
                                Console.WriteLine("Welcome, {0}!", loginName);
                                    int response;
                                    do
                                    {
                                        Console.WriteLine("\n=====TINDER MENU=====");
                                        Console.Write("1 Match \n2 View Matches \n3 View People List\n4 Unmatch \n5 Edit User Settings \n6 View Likes \n0 to LOGOUT \nEnter choice: ");
                                        response = int.Parse(Console.ReadLine());
                                        Console.WriteLine();
                                        switch (response)
                                        {
                                            case 1: //Match
                                                Console.WriteLine("=====MATCH=====");
                                                abby.MatchPerson(abby.GetPeopleList()[index]);
                                                break;
                                            case 2: //View Matches
                                                Console.WriteLine("=====VIEW MATCHES=====");
                                                abby.ShowMatches(abby.GetPeopleList()[index]);
                                                break;
                                            case 3: //View People List
                                                Console.WriteLine("=====VIEW PEOPLE LIST=====");
                                                abby.ShowPeopleList(abby.GetPeopleList()[index]); //Should you be included or no
                                                break;
                                            case 4: //Unmatch
                                                Console.WriteLine("=====UNMATCH=====");
                                                abby.Unmatch(abby.GetPeopleList()[index]);
                                                break;
                                            case 5: //Edit User Settings
                                                Console.WriteLine("=====EDIT USER SETTINGS=====");
                                                abby.EditUserSettings(abby.GetPeopleList()[index]);
                                                break;
                                            /*case 6: //View Likes
                                                Console.WriteLine("=====VIEW LIKES=====");
                                                abby.ShowLikes(abby.GetPeopleList()[index]);
                                                break;*/
                                            case 0:
                                                Console.WriteLine("LOGGING OUT...\n");
                                                break;
                                            default:
                                                Console.WriteLine("ERROR. PLEASE TRY AGAIN.\n");
                                                break;
                                        }

                                    } while (response != 0);
                            }
                            else
                            {
                                Console.WriteLine("PERSON HAS NOT BEEN REGISTERED.\n");
                            }
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nCLOSING THE PROGRAM...");
                        break;
                    default:
                        Console.WriteLine("\nERROR. PLEASE TRY AGAIN.");
                        break;
                }

            } while (profileResponse != 0);
        }
    }
}
