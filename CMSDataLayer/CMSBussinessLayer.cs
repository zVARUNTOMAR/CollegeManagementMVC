using CMSDataLayer;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMSBussinessLayer
{
    public class CMSBussinessLayerClass
    {
        private static Dictionary<string, Student> studentAllocations = new Dictionary<string, Student>();
        private static int collegeId = 100;
        private static int studentId = 100;

        //TO Validate Name
        public void InvalidNameValidation(string name)
        {
            //Check for Name containing any unwanted character
            bool conatinsInt = name.Any(char.IsDigit);

            if (conatinsInt == true)
            {
                throw new InvalidNameException("======NAME IS INVALID======");
            }
        }

        //To Validate Percentage
        public void InvalidPercentageValidation(int percentage)
        {
            if (!(percentage > 0 && percentage <= 100))
            {
                throw new InvalidPercentageException("Invalid Exception");
            }
        }

        //To Validate Student ID

        //Login Admin
        public bool LoginAdmin()
        {
            string username = "";                     //UserName
            string password = "";                     //Password

            Console.WriteLine("Enter User Name");
            username = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            password = Console.ReadLine();

            if (username == "admin" && password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Student Panel
        public bool LoginStudent()
        {
            string username = "";
            string password = "";

            Console.WriteLine("Username : ");
            username = Console.ReadLine();

            Console.WriteLine("Password :");
            password = Console.ReadLine();

            if (username == "student" && password == "student")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Add New College
        public void AddCollege()
        {
            CMSDataLayerClass CMSDataLayerClassObj = new CMSDataLayerClass();

            char choiceAddCollege;

            do
            {
                College NewCollege = new College();  //New College Object

                NewCollege.collegeId = ("CT" + collegeId);
                collegeId++;

                Console.WriteLine("Enter College Name:");
                NewCollege.collegeName = Console.ReadLine();

                Console.WriteLine("Enter College Location");
                NewCollege.collegeLocation = Console.ReadLine();

                Console.WriteLine("Enter College CutOff Percentage :");
                NewCollege.cutOffPercentage = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Seat Available in College :");
                NewCollege.numberOfSeatsAvailable = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Password to add College : ");
                int passAddCollege = Convert.ToInt32(Console.ReadLine());

                if (passAddCollege == 1)
                {
                    CMSDataLayerClassObj.AddCollege(NewCollege);
                    Console.WriteLine("Do you Want to add More Colleg(y/n)");
                    choiceAddCollege = Console.ReadLine()[0];
                }
                else
                {
                    return;
                }


            } while (choiceAddCollege == 'y');
        }

        public bool DisplayStudentOnCollegeId()
        {
            CMSDataLayerClass CMSDataLayerClassObj = new CMSDataLayerClass();

            Console.WriteLine("Enter College Id:");
            string collegeId = Console.ReadLine();

            CMSDataLayerClassObj.DisplayStudentOnCollegeId(collegeId, studentAllocations);

            return true;
        }

        public bool DisplayCollege()
        {
            CMSDataLayerClass CMSDataLayerClassObj = new CMSDataLayerClass();

            if (CMSDataLayerClassObj.DisplayCollege())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ApplyForCollege()
        {
            CMSDataLayerClass CMSDataLayerClassObj = new CMSDataLayerClass();

            Console.WriteLine("Enter Your Name");
            string name = Console.ReadLine();

            try
            {
                InvalidNameValidation(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Enter College ID:");
            string collegeId = Console.ReadLine();

            Console.WriteLine("Enter Percentage : ");
            int percentage = Convert.ToInt32(Console.ReadLine());

            Student newStudent = CMSDataLayerClassObj.ApplyForCollege(collegeId, name, percentage);

            try
            {
                studentAllocations.Add(newStudent.studentId, newStudent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}