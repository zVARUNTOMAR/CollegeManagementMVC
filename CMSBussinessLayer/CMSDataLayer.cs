using Entities;
using System;
using System.Runtime.InteropServices;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
//using GlobalVar;

namespace CMSDataLayer
{
    public class CMSDataLayerClass
    {
        static int collegeCount = 2;
        static int studentId = 100;

        public bool AddCollege(College newCollege)
        {

            Excel ex = new Excel(@"C:\Users\R3CK3R\Desktop\ex\CollegeDetails.xlsx", 1);

            ex.ws.Cells[collegeCount, 1].Value2 = newCollege.collegeId;
            ex.ws.Cells[collegeCount, 2].Value2 = newCollege.collegeName;
            ex.ws.Cells[collegeCount, 3].Value2 = newCollege.collegeLocation;
            ex.ws.Cells[collegeCount, 4].Value2 = newCollege.cutOffPercentage;
            ex.ws.Cells[collegeCount, 5].Value2 = newCollege.numberOfSeatsAvailable;

            collegeCount++;

            ex.wb.Save();

            //rowTracker.rowId = rowTracker.rowId + 1;

            ex.wb.Close(true, null, null);
  

            Marshal.ReleaseComObject(ex.ws);
            Marshal.ReleaseComObject(ex.wb);
            Marshal.ReleaseComObject(ex.excel);

            return true;
        }

        public void DisplayStudentOnCollegeId(string id, Dictionary<string, Student> studentAllocations)
        {

            Console.WriteLine("====================================");
            Console.WriteLine("\t STUDENT DETAILS");
            Console.WriteLine("====================================");
            foreach (KeyValuePair<string, Student> entry in studentAllocations) {
                if (entry.Value.college.collegeId.Equals(id))
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4}", entry.Key, entry.Value.studentName, entry.Value.college.collegeName, entry.Value.college.collegeId, entry.Value.college.collegeLocation);
                }
            }

            Console.WriteLine("Success.....");
        }

        public bool DisplayCollege()
        {
            Excel ex = new Excel(@"C:\Users\R3CK3R\Desktop\ex\CollegeDetails.xlsx", 1);

            _Excel.Range range;

            range = ex.ws.UsedRange;
            int row = range.Rows.Count;

            for (int i = 1; i <= row; i++)
            {
                Console.WriteLine("{0} || {1} || {2} || {3} || {4}", ex.ws.Cells[i, 1].Value2, ex.ws.Cells[i, 2].Value2
                    , ex.ws.Cells[i, 3].Value2, ex.ws.Cells[i, 4].Value2, ex.ws.Cells[i, 5].Value2);
            }

            ex.wb.Save();

            //rowTracker.rowId = rowTracker.rowId + 1;

            ex.wb.Close(true, null, null);
            ex.excel.Quit();

            Marshal.ReleaseComObject(ex.ws);
            Marshal.ReleaseComObject(ex.wb);
            Marshal.ReleaseComObject(ex.excel);

            return true;
        }

        public Student ApplyForCollege(string collegeId, string name, int percentage) {

            Excel ex = new Excel(@"C:\Users\R3CK3R\Desktop\ex\CollegeDetails.xlsx", 1);

            _Excel.Range range;

            range = ex.ws.UsedRange;
            int row = range.Rows.Count;

            Boolean flag = false;
            int i;
            for (i = 2; i <= row; i++)
            {
                if (ex.ws.Cells[i,1].Value2.Equals(collegeId) && ex.ws.Cells[i,4].Value2 <= percentage && ex.ws.Cells[i,5].Value2 > 1) {
                    ex.ws.Cells[i, 5].Value2 -= 1;
                    Console.WriteLine("College Found Applying...");
                    flag = true;
                    break;
                }
            }

            if (flag == true)
            {
                Student newStudent = new Student();

                newStudent.studentId = "ST" + studentId;
                studentId++;

                newStudent.studentName = name;
                newStudent.percentage = percentage;


                //College Object

                College college = new College();

                
                college.collegeId = ex.ws.Cells[i, 1].Value2;
                college.collegeName = ex.ws.Cells[i, 2].Value2;
                college.collegeLocation = ex.ws.Cells[i, 3].Value2;
                college.cutOffPercentage =  (int)ex.ws.Cells[i, 4].Value2;
                college.numberOfSeatsAvailable = (int)ex.ws.Cells[i, 5].Value2;
                

                newStudent.college = college;

                ex.wb.Save();

                //rowTracker.rowId = rowTracker.rowId + 1;

                ex.wb.Close(true, null, null);
                ex.excel.Quit();

                Marshal.ReleaseComObject(ex.ws);
                Marshal.ReleaseComObject(ex.wb);
                Marshal.ReleaseComObject(ex.excel); 

                return newStudent;
            }
            else {
                ex.wb.Save();

                //rowTracker.rowId = rowTracker.rowId + 1;

                ex.wb.Close(true, null, null);
                ex.excel.Quit();

                Marshal.ReleaseComObject(ex.ws);
                Marshal.ReleaseComObject(ex.wb);
                Marshal.ReleaseComObject(ex.excel);
                return null;
            }
        }
    }
}