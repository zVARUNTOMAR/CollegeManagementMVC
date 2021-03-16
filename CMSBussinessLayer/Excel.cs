using Entities;
using Microsoft.Office.Interop.Excel;
using System;
using System.Runtime.InteropServices;
using _Excel = Microsoft.Office.Interop.Excel;

namespace CMSDataLayer
{
    public class Excel
    {
            public string path = "";

            public static int i = 2;

            //GlobalVarClass rowTracker = new GlobalVarClass(1);

            public _Application excel = new _Excel.Application();

            //WorkBook
            public Workbook wb;

            public Worksheet ws;

            public Excel(string path, int sheet)
            {
                this.path = path;

                wb = excel.Workbooks.Open(path);
                ws = excel.Worksheets[sheet];
            }
    }
}
