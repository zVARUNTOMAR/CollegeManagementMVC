/*Code Name = College Managemet System
 Date - 24-01-2021
 Varun Tomar */

using Entities;
using System;
using System.Collections.Generic;
using Exceptions;
using CMSBussinessLayer;


namespace CMSPresentationLayer
{
    internal class CMSPresentationLayer
    {
        
        public static void Main(string[] args)
        {
            int choiceProgInt = 0;

            //Student Allocation Details
            Dictionary<string, Student> studentAllocationDetails = new Dictionary<string, Student>();

            do
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("\t\tCOLLEGE MANAGEMENT SYSTEM");
                Console.WriteLine("==============================================");
                Console.WriteLine("======================MENU===================");
                Console.WriteLine("Press 1 to login as Admin");
                Console.WriteLine("Press 2 to login as Student");
                Console.WriteLine("Press 3 to Exit");
                Console.WriteLine("==============================================");
                Console.WriteLine("Ente Your Choice :");
                string choiceMenu = Console.ReadLine();
                int choiceMenuInt = 0;

                try
                {
                    choiceMenuInt = Int32.Parse(choiceMenu);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                CMSBussinessLayerClass CMSBussinessLayerObj = new CMSBussinessLayerClass();
                //Switch For Menu

                switch (choiceMenuInt)
                {
                    case 1:
                        if (CMSBussinessLayerObj.LoginAdmin())
                        {
                            Console.WriteLine("======================ADMIN PANEL==============");
                            Console.WriteLine("Press 1 to add College");
                            Console.WriteLine("Press 2 to Display Students on College Id");
                            Console.WriteLine("Press 3 to Back To Login");
                            Console.WriteLine("================================================");
                            Console.WriteLine("Enter Your Choice:");
                            string choiceAdminStr = Console.ReadLine();

                            int choiceAdmin = 0;

                            try
                            {
                                choiceAdmin = Int32.Parse(choiceAdminStr);
                            }
                            catch (Exception e) {
                                Console.WriteLine(e.Message);
                            }

                            switch (choiceAdmin) {

                                case 1:

                                    CMSBussinessLayerObj.AddCollege();
                                    Console.WriteLine("College Added Successfully");
                                    break;

                                case 2:
                                    if (CMSBussinessLayerObj.DisplayStudentOnCollegeId())
                                    {
                                        Console.WriteLine("========STUDENT DISPLAY SUCCESSFULLY======");
                                    }
                                    else {
                                        Console.WriteLine("=======ERROR IN DISPLAYING======");
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("=========ADMIN PANEL EXITED=======");
                                    break;

                                default:
                                    Console.WriteLine("WRONG CHOICE........");
                                    break;
                            }
                        }
                        else {
                            Console.WriteLine("INVALID USERID AND PASSWORD");
                        }
                        break;

                    case 2:
                        if (CMSBussinessLayerObj.LoginStudent())
                        {
                            Console.WriteLine("===============STUDENT PANEL============");
                            CMSBussinessLayerObj.DisplayCollege();
                            CMSBussinessLayerObj.ApplyForCollege();
                        }
                        else {
                            Console.WriteLine("========INVALID USER ID AND PASSWORD=====");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Exiting.....");
                        return;

                    default:
                        Console.WriteLine("Wrong Choice....");
                        break;
                }

                Console.WriteLine("Press 1 to Continue...");
                string choiceProg = Console.ReadLine();

                try
                {
                    choiceProgInt = Int32.Parse(choiceProg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (choiceProgInt == 1);

            Console.WriteLine("Exiting....");
            return;
        }
    }
}