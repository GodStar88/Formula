using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Formula
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        int[][] breakdown =
        {
            new int[] { 0 },
            new int[] { 1 },
            new int[] { 2 },
            new int[] { 3 },
            new int[] { 4 },
            new int[] { 5 },
            new int[] { 6 },
            new int[] { 7 },
            new int[] { 8 },
            new int[] { 9 },
            new int[] { 10, 1 },
            new int[] { 11, 0,2,3,5 },
            new int[] { 12, 1, 3 },
            new int[] { 13, 2, 4 },
            new int[] { 14, 3, 5 },
            new int[] { 15, 4, 6 },
            new int[] { 16, 5, 7 },
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 23, 1, 5},
            new int[] { 24, 2, 6},
            new int[] { 25, 3, 7},
            new int[] { 26, 4, 8},
            new int[] { 27, 5, 9},
            new int[] { 28, 6, 10, 1, 17, 6, 8, 18, 7, 9, 35, 2, 8},
            new int[] { 29, 7, 11, 0, 2, 20, 2, 21, 1, 3, 41, 3, 5},
            new int[] { 30, 3},
            new int[] { 31, 2, 4},
            new int[] { 32, 1, 5},
            new int[] { 33, 0, 6, 7, 13, 2, 4},
            new int[] { 34, 1, 7},
            new int[] { 35, 2, 8},
            new int[] { 36, 3, 9},
            new int[] { 37, 4, 10, 1, 15, 4, 6, 16, 5, 7, 31, 2, 4},
            new int[] { 38, 5, 11, 0, 2, 18, 7, 9, 19, 8, 10, 1, 20, 2 , 37, 4, 10, 1, 15, 4, 6, 16, 5, 7, 31, 2, 4}, 
            new int[] { 39, 6, 12, 1, 3, 22, 0, 4, 5, 9},
            new int[] { 40, 4},
            new int[] { 41, 3, 5},
            new int[] { 42, 2, 6},
            new int[] { 43, 1, 7},
            new int[] { 44, 0, 8, 9, 17},
            new int[] { 45, 1, 9},
            new int[] { 46, 2, 10, 1, 13, 2, 4, 14, 3, 5, 27, 5, 9 },                                   
            new int[] { 47, 3, 11, 0, 2, 16, 5, 7, 17, 6, 8, 33, 0, 6, 7, 13, 2, 4},                    
            new int[] { 48, 4, 12, 1, 3, 20, 2},
            new int[] { 49, 5, 13, 2, 4, 24, 2, 6 },
            new int[] { 50, 5},
            new int[] { 51, 4, 6},
            new int[] { 52, 3, 7},
            new int[] { 53, 2, 8},
            new int[] { 54, 1, 9},
            new int[] { 55, 0, 10, 1, 11, 0, 2, 3, 5, 13, 2, 4, 24, 2, 6},
            new int[] { 56, 1, 11, 0, 2, 14, 3, 5, 15, 4, 6, 29, 7, 11, 0, 2, 20, 2, 21, 1, 3, 41, 3, 5},
            new int[] { 57, 2, 12, 1, 3, 18, 7, 9},
            new int[] { 58, 3, 13, 2, 4, 22, 0, 4, 5, 9},
            new int[] { 59, 4, 14, 3, 5, 26, 4, 8},
            new int[] { 60, 6},
            new int[] { 61, 5, 7},
            new int[] { 62, 4, 8},
            new int[] { 63, 3, 9},
            new int[] { 64, 2, 10, 1, 13, 2, 4, 14, 3, 5, 27, 5, 9},
            new int[] { 65, 1, 11, 0, 2, 14, 3, 5, 15, 4, 6, 29, 7, 11, 0, 2, 20, 2, 21, 1, 3, 41, 3, 5},
            new int[] { 66, 0, 12, 1, 3, 16, 5, 7, 17, 6, 8, 33, 0, 6, 7, 13, 2, 4},
            new int[] { 67, 1, 13, 2, 4, 20, 2},
            new int[] { 68, 2, 14, 3, 5, 24, 24, 2, 6 },
            new int[] { 69, 3, 15, 4, 6, 28, 6, 10, 1, 17, 6, 8, 18, 7, 9, 35, 2, 8},
            new int[] { 70, 7},
            new int[] { 71, 6, 8},
            new int[] { 72, 5, 9},
            new int[] { 73, 4, 10, 1, 15, 4, 6, 16, 5, 7, 31, 2, 4 },
            new int[] { 74, 3, 11, 0, 2, 16, 5, 7, 17, 6, 8, 33, 0, 6, 7, 13, 2, 4 },
            new int[] { 75, 2, 12, 1, 3, 18, 7, 9 },
            new int[] { 76, 1, 13, 2, 4, 20, 2 },
            new int[] { 77, 0, 14, 3, 5, 22, 0, 4, 5, 9, 23, 1, 5, 45, 1, 9 },
            new int[] { 78, 1, 15, 4, 6, 26, 26, 4, 8 },
            new int[] { 79, 2, 16, 5, 7, 30, 3},
            new int[] { 80, 8},
            new int[] { 81, 7, 9},
            new int[] { 82, 6, 10, 1, 17, 6, 8, 18, 7, 9, 35, 2, 8 },
            new int[] { 83, 5, 11, 0, 2, 18, 7, 9, 19, 8, 10, 1, 20, 2, 37, 4, 10, 1, 15, 4, 6, 16, 5, 7, 31, 2, 4 },
            new int[] { 84, 4, 12, 1, 3, 20, 2 },
            new int[] { 85, 3, 13, 2, 4, 22, 0, 4, 5, 9 },
            new int[] { 86, 2, 14, 3, 5, 24, 2, 6 },
            new int[] { 87, 1, 15, 4, 6, 26, 4, 8 },
            new int[] { 88, 0, 16, 5, 7, 28, 6, 10, 1, 17, 6, 8, 18, 7, 9, 35, 2, 8, 29, 7, 11, 0, 2, 20, 2, 21, 1, 3, 41, 3, 5, 57, 2, 12, 1, 3, 18, 7, 9 },
            new int[] { 89, 1, 17, 6, 8, 32, 1, 5},
            new int[] { 90, 9},
            new int[] { 91, 8, 10, 1, 20, 2 },
            new int[] { 92, 7, 11, 0, 2, 20, 2, 21, 1, 3, 41, 3, 5 },
            new int[] { 93, 6, 12, 1, 3, 22, 0, 4, 5, 9 },
            new int[] { 94, 5, 13, 2, 4, 24, 2, 6 },
            new int[] { 95, 4, 14, 3, 5, 26, 4, 8 },
            new int[] { 96, 69, 3, 15, 4, 6, 28, 6, 10, 1, 17, 6, 8, 18, 7, 9, 35, 2, 8 },
            new int[] { 97, 2, 16, 5, 7, 30, 3 },
            new int[] { 98, 1, 17, 6, 8, 32, 1, 5 },
            new int[] { 99, 0, 18, 7, 9, 34, 1, 7, 35, 2, 8, 69, 3, 15, 4, 6, 28, 6, 10, 1, 17, 6, 8, 18, 7, 9, 35, 2, 8},
            new int[] { 10, 1 },                //100
            new int[] { 11, 0,2,3,5 },
            new int[] { 12, 1, 3 },
            new int[] { 13, 2, 4 },
            new int[] { 14, 3, 5 },
            new int[] { 15, 4, 6 },
            new int[] { 16, 5, 7 },
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 11, 0,2,3,5 },          //110
            new int[] { 12, 1, 3 },
            new int[] { 13, 2, 4 },
            new int[] { 14, 3, 5 },
            new int[] { 15, 4, 6 },
            new int[] { 16, 5, 7 },
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 12, 1, 3 },             //120
            new int[] { 13, 2, 4 },
            new int[] { 14, 3, 5 },
            new int[] { 15, 4, 6 },
            new int[] { 16, 5, 7 },
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 13, 2, 4 },             //130
            new int[] { 14, 3, 5 },
            new int[] { 15, 4, 6 },
            new int[] { 16, 5, 7 },
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 14, 3, 5 },             //140
            new int[] { 15, 4, 6 },
            new int[] { 16, 5, 7 },
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 23, 1, 5},

            new int[] { 15, 4, 6 },              //150
            new int[] { 16, 5, 7 },
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 23, 1, 5},
            new int[] { 24, 2, 6},

            new int[] { 16, 5, 7 },              //160
            new int[] { 17, 6, 8 },
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 23, 1, 5},
            new int[] { 24, 2, 6},
            new int[] { 25, 3, 7},

            new int[] { 17, 6, 8 },              //170
            new int[] { 18, 7, 9 },
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 23, 1, 5},
            new int[] { 24, 2, 6},
            new int[] { 25, 3, 7},
            new int[] { 26, 4, 8},

            new int[] { 18, 7, 9 },              //180
            new int[] { 19, 8, 10, 1, 20, 2 },
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 23, 1, 5},
            new int[] { 24, 2, 6},
            new int[] { 25, 3, 7},
            new int[] { 26, 4, 8},
            new int[] { 27, 5, 9},

            new int[] { 19, 8, 10, 1, 20, 2 },   //190
            new int[] { 20, 2},
            new int[] { 21, 1, 3},
            new int[] { 22, 0, 4, 5, 9},
            new int[] { 23, 1, 5},
            new int[] { 24, 2, 6},
            new int[] { 25, 3, 7},
            new int[] { 26, 4, 8},
            new int[] { 27, 5, 9},
            new int[] { 28, 6, 10, 1, 17, 6, 8, 18, 7, 9, 35, 2, 8},



      };

        String message = "=====Step1=====";
        List<int> DateList = new List<int>();
        List<int> TimeList = new List<int>();        
        List<int> SameList_Step1 = new List<int>();
        List<int> SameList_Step2 = new List<int>();
        List<int> List_Step4 = new List<int>();
        List<int> SameList_Step4 = new List<int>();
        List<int> SameList_Step5 = new List<int>();
        List<int> SameList_Step6 = new List<int>();
        List<int> SameList_Step7 = new List<int>();
        List<int> List_Step8 = new List<int>();
        List<int> SameList_Step8 = new List<int>();
        List<int> SameList_Step9 = new List<int>();
        List<int> SameList_Step10 = new List<int>();
        String path = "";
        Excel.Workbook MyBook = null;
        Excel.Application MyApp = null;
        Excel.Worksheet MySheet = null;
        int lastRow = 0;
        int sameCount = 0;
        int TIME;
        String result1;
        String result2;
        String result3;
        String result4;
        public void dateAdd1(String date)
        {
            
            char[] myArray = date.ToCharArray();

            List<int> dateArray = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                int x = Int32.Parse(myArray[i].ToString() + myArray[i + 1].ToString());
                if (x > 10)
                {
                    dateArray.Add(x);
                }
            }
            if (myArray[1].ToString() == "0" && myArray[2].ToString() != "0")
                dateArray.Add(Int32.Parse(myArray[0].ToString() + myArray[2].ToString()));
            if (myArray[1].ToString() == "0" && myArray[2].ToString() == "0")
                dateArray.Add(Int32.Parse(myArray[0].ToString() + myArray[3].ToString()));
            dateArray.Add(Int32.Parse(myArray[3].ToString() + myArray[4].ToString()));
            dateArray.Add(Int32.Parse(myArray[4].ToString() + myArray[5].ToString()));
            if(myArray[4].ToString()=="0")
                dateArray.Add(Int32.Parse(myArray[3].ToString() + myArray[5].ToString()));
            dateArray.Add(Int32.Parse(myArray[5].ToString() + myArray[6].ToString()));
            dateArray.Add(Int32.Parse(myArray[6].ToString() + myArray[7].ToString()));
            if (myArray[6].ToString() == "0")
                dateArray.Add(Int32.Parse(myArray[5].ToString() + myArray[7].ToString()));

            message = message+ System.Environment.NewLine + "Date Add :";
            for (int i = 0; i < dateArray.Count; i++)
            {
                DateList.Add(dateArray[i]);
                message = message + dateArray[i].ToString() + ", ";
            }
        }
        public void dateAdd2(String date)
        {
            int x = 0, y = 0;
            
            char[] myArray = date.ToCharArray();
            List<int> dateArray = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                x = x + Int32.Parse(myArray[i].ToString());
                if (Int32.Parse(myArray[i].ToString()) == 0 )
                {
                    y++;
                }
                else
                {
                    y = y + Int32.Parse(myArray[i].ToString());
                }
            }
            dateArray.Add(x);
            dateArray.Add(y);
            dateArray.Add(x+y);
            if ( (x+y)%10==0 && sameCount != 0)
            {
                dateArray.Add(x + y + 1);
                dateArray.Add(2*(x + y) + 1);
            }
            
            message = message +  System.Environment.NewLine + "Date Add :";
            for (int i = 0; i < dateArray.Count; i++)
            {
                DateList.Add(dateArray[i]);
                message = message + dateArray[i].ToString() + ", ";
            }
            
        }
        public void timeAdd(String time)
        {
            List<int> timeArray = new List<int>();
            int x = Int32.Parse(time);
            TIME = x;
            timeArray.Add( x );
            timeArray.Add( x + 1 );
            timeArray.Add( 2 * x + 1 );

            message = message + System.Environment.NewLine + "Time Add :";
            for (int i = 0; i < timeArray.Count; i++)
            {
                TimeList.Add(timeArray[i]);
                message = message + timeArray[i].ToString() + ", ";
            }            
        }

        public void step1()
        {
            for (int i = 0; i < TimeList.Count; i++)
            {
                for (int j = 0; j < DateList.Count; j++)
                {
                    sameCount = sameCount + fuc_same(TimeList[i], DateList[j]);
                }
            }
            SameList_Step1.Add(sameCount);
            if (sameCount % 10 == 0 && sameCount != 0)
            {
                SameList_Step1.Add(sameCount + 1);
                SameList_Step1.Add(2 * sameCount + 1);
            }
            String str = "";
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                str = str + SameList_Step1[i].ToString() + ", ";
            }
            message = message + System.Environment.NewLine + "We have " + str + " same";
        }

        public int fuc_same(int d, int t)
        {
            List<int> d1 = new List<int>();
            List<int> t1 = new List<int>();
            if (d > 99)
            {
                int x = d / 10 + d % 10;
                d1.Add(x);
                if (d / 10 % 10 == 0)
                {
                    d1.Add(x + 1);
                    d1.Add(2 * x + 1);
                }
            }
            else d1.Add(d);
            if (t > 99)
            {
                int x = t / 10 + t % 10;
                t1.Add(x);
                if (t / 10 % 10 == 0)
                {
                    t1.Add(x + 1);
                    t1.Add(2 * x + 1);
                }
            }
            else t1.Add(t);
            int count = 0;
            for (int i = 0; i < d1.Count; i++)
            {
                for (int j = 0; j < t1.Count; j++)
                {
                    count = count + fuc_sameCount(d1[i], t1[j]);
                }
            }
            
            return count;
        }

        public int fuc_sameCount(int d, int t)
        {
            //11,22,33,44 is 5 same
            if (d == t)
            {
                if (d == 11 || d == 22 || d == 33 || d == 44)
                {
                    return 5;
                }
            }


            //55,66,77,88,99 is 3 same


            if (d == t)
            {
                if (d == 55 || d == 66 || d == 77 || d == 88 || d == 99)
                {
                    return 3;
                }
            }

            int count = 0;

            //12,21,24,42,36,63,19,91
            if (t > 9 && d > 9)
            {
                if (d == 24 || d == 42)
                {
                    int index = Array.IndexOf(breakdown[t], 2);
                    if (index != -1)
                    {
                        return 2;
                    }
                }
                if (d == 12 || d == 21 || d == 19 || d == 91)
                {
                    int index = Array.IndexOf(breakdown[t], 1);
                    if (index != -1)
                    {
                        return 2;
                    }
                }
                if (d == 36 || d == 63)
                {
                    int index = Array.IndexOf(breakdown[t], 3);
                    if (index != -1)
                    {
                        return 2;
                    }
                }

                if (t == 24 || t == 42)
                {
                    int index = Array.IndexOf(breakdown[d], 2);
                    if (index != -1)
                    {
                        return 2;
                    }
                }
                if (t == 12 || t == 21 || t == 19 || t == 91)
                {
                    int index = Array.IndexOf(breakdown[d], 1);
                    if (index != -1)
                    {
                        return 2;
                    }
                }
                if (t == 36 || t == 63)
                {
                    int index = Array.IndexOf(breakdown[d], 3);
                    if (index != -1)
                    {
                        return 2;
                    }
                }
            }

            // 13 = 13 is 3 same
            if (t == d && t > 9)
            {
                return 3;
            }
            // 13 = 31 is 3 same
            int x = Int32.Parse(Reverse(d.ToString()));
            if (t == x && t > 9)
            {
                return 1;
            }
            count = 0;

            if (t > 99) t = t / 10 + t % 10;
            if (d > 99) d = d / 10 + d % 10; 
            for (int i = 0; i < breakdown[t].Length; i++)
            {
                for (int j = 0; j < breakdown[d].Length; j++)
                {
                    if (breakdown[t][i] == breakdown[d][j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public  string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public void step2()
        {
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                if (i == 2)
                {
                    SameList_Step2.Add(SameList_Step1[i] + 26);
                }
                else
                {
                    SameList_Step2.Add(SameList_Step1[i] + 13);
                }               

            }

            if (SameList_Step2[SameList_Step2.Count-1] % 10 == 0 && sameCount != 0)
            {
                SameList_Step2.Add(SameList_Step2[SameList_Step2.Count - 1] + 1);
                SameList_Step2.Add(2 * SameList_Step2[SameList_Step2.Count - 2] + 1);
            }

            message = message + System.Environment.NewLine + "=====Step2=====";
            String str = "";
            for (int i = 0; i < SameList_Step2.Count; i++)
            {
                str = str + SameList_Step2[i].ToString() + ", ";
            }
            message = message + System.Environment.NewLine + "We have " + str + " same";
        }

        public void step3()
        {
            message = message + System.Environment.NewLine + "=====Step3=====";
            message = message + System.Environment.NewLine + "Date " + textBox1.Text;
            message = message + System.Environment.NewLine + "Time ";
            for (int i = 0; i < TimeList.Count; i++)
            {
                message = message + TimeList[i].ToString() + ", ";
            }
            List_Step4.Add(13);
            message = message + System.Environment.NewLine + "1) 13  2) ";
            String str = "";
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                List_Step4.Add(SameList_Step1[i]);
                str = str + SameList_Step1[i].ToString() + ", ";
            }
            message = message + str;

            str = "";
            for (int i = 0; i < SameList_Step2.Count; i++)
            {
                List_Step4.Add(SameList_Step2[i]);
                str = str + SameList_Step2[i].ToString() + ", ";
            }
            message = message + "  3)" + str;
        }

        public void step4()
        {
            sameCount = 0;
            message = message + System.Environment.NewLine + "=====Step4=====";
            for (int i = 0; i < TimeList.Count; i++)
            {
                for (int j = 0; j < List_Step4.Count; j++)
                {
                    sameCount = sameCount + fuc_same(TimeList[i], List_Step4[j]);
                }
            }
            if (sameCount == 0)
            {
                sameCount = 1;
            }
            SameList_Step4.Add(sameCount);
//             if (sameCount % 10 == 0)
//             {
//                 SameList_Step4.Add(sameCount + 1);
//                 SameList_Step4.Add(2 * sameCount + 1);
//             }
            String str = "";
            for (int i = 0; i < SameList_Step4.Count; i++)
            {
                str = str + SameList_Step4[i].ToString() + ", ";
            }
            message = message + System.Environment.NewLine + "We have " + str + " same";

        }

        public void step5()
        {
            sameCount = 0;
            message = message + System.Environment.NewLine + "=====Step5=====";

            for (int i = 0; i < DateList.Count; i++)
            {
                for (int j = 0; j < SameList_Step2.Count; j++)
                {
                    sameCount = sameCount + fuc_same(DateList[i], SameList_Step2[j]);
                }
            }
            for (int i = 0; i < TimeList.Count; i++)
            {
                for (int j = 0; j < SameList_Step2.Count; j++)
                {
                    sameCount = sameCount + fuc_same(TimeList[i], SameList_Step2[j]);
                }
            }
            SameList_Step5.Add(sameCount);
            message = message + System.Environment.NewLine + "We have " + sameCount.ToString() + " same";

        }

        public void step6()
        {
            sameCount = 0;
            message = message + System.Environment.NewLine + "=====Step6=====";
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                for (int j = 0; j < SameList_Step2.Count; j++)
                {
                    sameCount = sameCount + fuc_same(SameList_Step1[i], SameList_Step2[j]);
                }
            }
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                for (int j = 0; j < SameList_Step4.Count; j++)
                {
                    sameCount = sameCount + fuc_same(SameList_Step1[i], SameList_Step4[j]);
                }
            }

            for (int i = 0; i < SameList_Step2.Count; i++)
            {
                for (int j = 0; j < SameList_Step4.Count; j++)
                {
                    sameCount = sameCount + fuc_same(SameList_Step2[i], SameList_Step4[j]);
                }
            }

            SameList_Step6.Add(sameCount);
            message = message + System.Environment.NewLine + "We have " + sameCount.ToString() + " same";
        }

        public void step7()
        {
            sameCount = 0;
            message = message + System.Environment.NewLine + "=====Step7=====";

            for (int i = 0; i < DateList.Count; i++)
            {
                for (int j = 0; j < SameList_Step1.Count; j++)
                {
                    if (DateList[i] == SameList_Step1[j] && DateList[i] > 9)
                    {
                        sameCount++;
                    }
                    int x = Int32.Parse(Reverse(SameList_Step1[j].ToString()));
                    if (DateList[i] == x && DateList[i] > 9)
                    {
                        sameCount++;
                    }
                    if (DateList[i] == SameList_Step1[j])
                    {
                        sameCount++;
                    }
                }
                for (int j = 0; j < SameList_Step4.Count; j++)
                {
                    if (DateList[i] == SameList_Step4[j] && DateList[i] > 9)
                    {
                        sameCount++;
                    }
                    int x = Int32.Parse(Reverse(SameList_Step4[j].ToString()));
                    if (DateList[i] == x && DateList[i] > 9)
                    {
                        sameCount++;
                    }
                    if (DateList[i] == SameList_Step4[j])
                    {
                        sameCount++;
                    }
                }
            }

            for (int i = 0; i < TimeList.Count; i++)
            {
                for (int j = 0; j < SameList_Step1.Count; j++)
                {
                    if (TimeList[i] == SameList_Step1[j] && TimeList[i] > 9)
                    {
                        sameCount++;
                    }
                    int x = Int32.Parse(Reverse(SameList_Step1[j].ToString()));
                    if (TimeList[i] == x && TimeList[i] > 9)
                    {
                        sameCount++;
                    }
                    if (TimeList[i] == SameList_Step1[j])
                    {
                        sameCount++;
                    }
                }
                for (int j = 0; j < SameList_Step4.Count; j++)
                {
                    if (TimeList[i] == SameList_Step4[j] && TimeList[i] > 9)
                    {
                        sameCount++;
                    }
                    int x = Int32.Parse(Reverse(SameList_Step4[j].ToString()));
                    if (TimeList[i] == x && TimeList[i] > 9)
                    {
                        sameCount++;
                    }
                    if (TimeList[i] == SameList_Step4[j])
                    {
                        sameCount++;
                    }
                }
            }

            SameList_Step7.Add(sameCount);
            message = message + System.Environment.NewLine + "We have " + sameCount.ToString() + " same";
        }


        //Another version

        public void step8()
        {
            sameCount = 0;
            message = message + System.Environment.NewLine + "=====Step8=====";
            

            if (SameList_Step5[0] != 0 && SameList_Step6[0] != 0 && SameList_Step6[0] != 0)
            {
                List_Step8.Add(SameList_Step5[0]);
                List_Step8.Add(SameList_Step6[0]);
                List_Step8.Add(SameList_Step7[0]);
                List_Step8.Add(SameList_Step5[0] + SameList_Step6[0] + SameList_Step7[0]);
            }
            else
            {
                int zero = 0;
                if (SameList_Step5[0] != 0)
                {
                    List_Step8.Add(SameList_Step5[0]);
                }
                else zero++;
                if (SameList_Step6[0] != 0)
                {
                    List_Step8.Add(SameList_Step6[0]);
                }
                else zero++;
                if (SameList_Step7[0] != 0)
                {
                    List_Step8.Add(SameList_Step7[0]);
                }
                else zero++;
                int sum = 0;
                for (int i = 0; i < List_Step8.Count; i++)
                {
                    sum = sum + List_Step8[i];
                }
                List_Step8.Add(sum + zero);
                List_Step8.Add(2 * sum + zero);
            }


            int[] check = { 1, 6, 7, 13 };
            for (int i = 0; i < List_Step8.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sameCount = sameCount + fuc_same(List_Step8[i],check[j]);
                }
            }
            SameList_Step8.Add(sameCount);
            message = message + System.Environment.NewLine + "We have " + sameCount.ToString() + " same (3 same with 1,6,7,13,2,4)";
        }

        public void step9()
        {
            sameCount = 0;
            message = message + System.Environment.NewLine + "=====Step9=====";
            int[] check = { 1, 6, 7, 13 };
            for (int i = 0; i < TimeList.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sameCount = sameCount + fuc_same(TimeList[i], check[j]);
                }
            }
            SameList_Step9.Add(sameCount);
            message = message + System.Environment.NewLine + "We have " + sameCount.ToString() + " same (time add with 1,6,7,13,2,4)";

        }
        public void step10()
        {
            sameCount = 0;
            message = message + System.Environment.NewLine + "=====Step10=====";
            for (int i = 0; i < TimeList.Count; i++)
            {
                for (int j = 0; j < List_Step8.Count; j++)
                {
                    sameCount = sameCount + fuc_same(TimeList[i], List_Step8[j]);
                }
            }
            SameList_Step10.Add(sameCount);
            message = message + System.Environment.NewLine + "We have " + sameCount.ToString() + " same (3 same with time add)";
        }

        public string step11()
        {
            message = message + System.Environment.NewLine + "=====Step11=====";
            int same = SameList_Step8[0] + SameList_Step9[0] + SameList_Step10[0] + 1;
            string str = "";
            if (same % 2 == 0)
            {
                str = "Up";
            }
            else str = "Down";
            message = message + System.Environment.NewLine + "" + str;
            return str;
        }

        //Rules for new additions

        int step3_add_same = 0;
        int step4_add_same = 0;
        public void step1_add()
        {
            message = message + System.Environment.NewLine + "***Rules for new additions***";
            message = message + System.Environment.NewLine + "=====Step1=====";
            String str = "";
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                str = str + SameList_Step1[i].ToString() + ", ";
            }
            message = message + System.Environment.NewLine + "We have " + str + " same";
        }
        public void step2_add()
        {
            message = message + System.Environment.NewLine + "=====Step2=====";
            message = message + System.Environment.NewLine + "Add step1 to time1 and time2 is ";
            message = message + (SameList_Step1[0] + TIME).ToString() + "," + (SameList_Step1[0] + TIME + 1).ToString();
        }
        public int step3_add()
        {
            message = message + System.Environment.NewLine + "=====Step3=====";
            sameCount = 0;
            for (int j = 0; j < DateList.Count; j++)
            {
                sameCount = sameCount + fuc_same(SameList_Step1[0] + TIME, DateList[j]);
            }

            if (sameCount == 0 )
            {
                for (int j = 0; j < DateList.Count; j++)
                {
                    sameCount = sameCount + fuc_same(TIME, DateList[j]);
                }
                int x = TIME + sameCount;
                sameCount = 0;
                for (int j = 0; j < DateList.Count; j++)
                {
                    sameCount = sameCount + fuc_same(x, DateList[j]);
                }
            }
            step3_add_same = sameCount;
            message = message + System.Environment.NewLine + "Check step2 time1 with date again is " + sameCount.ToString();
            return sameCount;
        }

        public void step4_add()
        {
            message = message + System.Environment.NewLine + "=====Step4=====";
            sameCount = 0;
            for (int j = 0; j < DateList.Count; j++)
            {
                sameCount = sameCount + fuc_same(SameList_Step1[0] + TIME + 1, DateList[j]);
            }
            step4_add_same = sameCount;
            message = message + System.Environment.NewLine + "Check step2 time2 with date again is " + sameCount.ToString();
        }


        // Take Note For Final Additions
        int final2, final3, final4, final5, final6, final7, final8;
        int[] final_time;
        public void step1_final(string str)
        {
            message = message + System.Environment.NewLine + "***Take Note For Final Additions***";
            message = message + System.Environment.NewLine + "=====Step1=====";
            message = message + System.Environment.NewLine + "step11 is " + str;
            final_time = new int[] {  TIME, TIME+1, 2* TIME + 1 };
        }

        public void step2_final()
        {
            message = message + System.Environment.NewLine + "=====Step2=====";
            sameCount = 0;
            for (int i = 0; i < final_time.Length; i++)
            {
                for (int j = 0; j < SameList_Step1.Count; j++)
                {
                    sameCount = sameCount + fuc_same(final_time[i], SameList_Step1[j]);
                }
            }
            final2 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + final2.ToString();
        }
        public void step3_final()
        {
            message = message + System.Environment.NewLine + "=====Step3=====";
            sameCount = 0;

            for (int j = 0; j < SameList_Step1.Count; j++)
            {
                sameCount = sameCount + fuc_same(step3_add_same, SameList_Step1[j]);
                sameCount = sameCount + fuc_same(step4_add_same, SameList_Step1[j]);
            }

            final3 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + final3.ToString();
        }

        public void step4_final()
        {
            message = message + System.Environment.NewLine + "=====Step4=====";
            sameCount = 0;

            for (int j = 0; j < final_time.Length; j++)
            {
                sameCount = sameCount + fuc_same(step3_add_same, final_time[j]);
                sameCount = sameCount + fuc_same(step4_add_same, final_time[j]);
            }

            final4 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + final4.ToString();
        }

        public void step5_final()
        {
            message = message + System.Environment.NewLine + "=====Step5=====";
            sameCount = 0;

            for (int i = 0; i < final_time.Length; i++)
            {
                for (int j = 0; j < DateList.Count; j++)
                {
                    if (final_time[i] == DateList[j])
                    {
                        sameCount++;
                    }
                }
            }
            final5 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + final5.ToString();
        }

        public void step6_final()
        {
            message = message + System.Environment.NewLine + "=====Step6=====";
            sameCount = 0;

            if (step3_add_same == step4_add_same)
            {
                sameCount++;
            }
            if (step3_add_same == step3_add_same + step4_add_same)
            {
                sameCount++;
            }
            if (step3_add_same + step4_add_same == step4_add_same)
            {
                sameCount++;
            }

            final6 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + final6.ToString();
        }

        public void step7_final()
        {
            message = message + System.Environment.NewLine + "=====Step7=====";
            sameCount = 0;

            for (int i = 0; i < final_time.Length; i++)
            {
                for (int k = 0; k < SameList_Step1.Count; k++)
                {
                    bool f = false;
                    if (SameList_Step1[k] > 99) SameList_Step1[k] = SameList_Step1[k] / 10 + SameList_Step1[k] % 10;
                    for (int j = 0; j < breakdown[SameList_Step1[k]].Length; j++)
                    {
                        if (breakdown[SameList_Step1[k]][j] == 9)
                        {
                            f = true;
                        }
                    }

                    if (f == true)
                    {
                        for (int j = 0; j < breakdown[final_time[i]].Length; j++)
                        {
                            if (breakdown[final_time[i]][j] == 9)
                            {
                                sameCount++;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < final_time.Length; i++)
            {
                bool f = false;
                for (int j = 0; j < breakdown[step3_add_same].Length; j++)
                {
                    if (breakdown[step3_add_same][j] == 9)
                    {
                        f = true;
                    }
                }

                if ( f == true)
                {
                    for (int j = 0; j < breakdown[final_time[i]].Length; j++)
                    {
                        if (breakdown[final_time[i]][j] == 9)
                        {
                            sameCount++;
                        }
                    }
                }
            }
            for (int i = 0; i < final_time.Length; i++)
            {
                bool f = false;
                for (int j = 0; j < breakdown[step4_add_same].Length; j++)
                {
                    if (breakdown[step4_add_same][j] == 9)
                    {
                        f = true;
                    }
                }

                if (f == true)
                {
                    for (int j = 0; j < breakdown[final_time[i]].Length; j++)
                    {
                        if (breakdown[final_time[i]][j] == 9)
                        {
                            sameCount++;
                        }
                    }
                }
            }

            final7 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + final7.ToString();
        }

        public int step8_final()
        {
            message = message + System.Environment.NewLine + "=====Step8=====";
            sameCount = final2 + final3 + final4 + final5 + final6 + final7;
            final8 = sameCount;
            message = message + System.Environment.NewLine + "Total same is " + sameCount.ToString();
            return sameCount;
        }

        //final tuning
        int tuning1, tuning2, tuning3, tuning4, tuning5, tuning6, tuning7, tuning8;
        public void step1_tuning()
        {
            message = message + System.Environment.NewLine + "***Final tuning***";
            message = message + System.Environment.NewLine + "=====Step1=====";
            sameCount = fuc_same(final8, 11);
            tuning1 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();

            if (final_time[0]<=3)
            {
                for (int i = 0; i < final_time.Length; i++)
                {
                    final_time[i] = final_time[i] + 3;
                }
            }
        }

        public void step2_tuning()
        {
            message = message + System.Environment.NewLine + "=====Step2=====";
            sameCount = 0;

            for (int i = 0; i < DateList.Count; i++)
            {
                sameCount = sameCount + fuc_same(DateList[i], final8 + 11);
            }

            for (int i = 0; i < final_time.Length; i++)
            {
                sameCount = sameCount + fuc_same(final_time[i], final8 + 11);
            }
            tuning2 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step3_tuning()
        {
            message = message + System.Environment.NewLine + "=====Step3=====";
            sameCount = 0;
            for (int i = 0; i < final_time.Length; i++)
            {
                sameCount = sameCount + fuc_same(final_time[i], 9);
            }
            tuning3 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step4_tuning()
        {
            message = message + System.Environment.NewLine + "=====Step4=====";
            sameCount = 0;
            for (int i = 0; i < final_time.Length; i++)
            {
                if (final_time[i] == final8)
                {
                    sameCount++;
                }
                if (final_time[i] == 11)
                {
                    sameCount++;
                }
                if (final_time[i] == final8 + 11)
                {
                    sameCount++;
                }
            }
            for (int i = 0; i < DateList.Count; i++)
            {
                if (DateList[i] == final8)
                {
                    sameCount++;
                }
                if (DateList[i] == 11)
                {
                    sameCount++;
                }
                if (DateList[i] == final8 + 11)
                {
                    sameCount++;
                }
            }
            tuning4 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step5_tuning()
        {
            message = message + System.Environment.NewLine + "=====Step5=====";
            sameCount = 0;
            for (int i = 0; i < final_time.Length; i++)
            {
                for (int j= 0;  j < DateList.Count; j++)
                {
                    if (final_time[i] == DateList[j])
                    {
                        sameCount++;
                    }
                }
            }
            tuning5 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }


        public void step6_tuning()
        {
            message = message + System.Environment.NewLine + "=====Step6=====";
            sameCount = 0;
            int x = tuning1 + tuning2 + tuning3 + tuning4 + tuning5;
            for (int i = 0; i < final_time.Length; i++)
            {
                sameCount = sameCount + fuc_same(final_time[i], final8 + 11 + x);
            }

            //12 + 4 = 16 and 13 + 4 = 17 and 24 + 4 = 28 need to check 16,17,28 for 2 digits same
            int temp0 = final_time[0] + x;
            int temp1 = final_time[1] + x;
            int temp2 = final_time[2] + x;
            if (temp2 > 99) temp2 = temp2 / 10 + temp2 % 10;
            if (temp1 > 99) temp1 = temp1 / 10 + temp1 % 10;
            if (temp0 > 99) temp0 = temp0 / 10 + temp0 % 10;
            for (int i = 0; i < breakdown[temp0].Length; i++)
            {
                for (int j = 0; j < breakdown[temp1].Length; j++)
                {
                    if (breakdown[temp0][i]  == breakdown[temp1][j] && breakdown[temp0][i] > 9)
                    {
                        sameCount++;
                    }
                }
            }

            for (int i = 0; i < breakdown[temp0].Length; i++)
            {
                
                
                for (int j = 0; j < breakdown[temp2].Length; j++)
                {
                    if (breakdown[temp0][i] == breakdown[temp2][j] && breakdown[temp0][i] > 9)
                    {
                        sameCount++;
                    }
                }
            }
            for (int i = 0; i < breakdown[temp2].Length; i++)
            {
                for (int j = 0; j < breakdown[temp1].Length; j++)
                {
                    if (breakdown[temp2][i] == breakdown[temp1][j] && breakdown[temp2][i] > 9)
                    {
                        sameCount++;
                    }
                }
            }
            tuning6 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step7_tuning()
        {
            message = message + System.Environment.NewLine + "=====Step7=====";
            sameCount = tuning1 + tuning2 + tuning3 + tuning4 + tuning5 + tuning6;

            if (result1 == "Up" && result2 == "Down")
            {
                result4 = "Down";
            }
            if (result2 == "Up" && result1 == "Down")
            {
                result4 = "Down";
            }
            if (result2 == "Up" && result1 == "Up")
            {
                result4 = "Down";
            }

            if (result2 == "Down" && result1 == "Down")
            {
                result4 = "Up";
            }

            if (sameCount % 2 == 1)
            {
                if (result4 == "Up")
                {
                    result4 = "Down";
                }
                else
                {
                    result4 = "Up";
                }
            }
            message = message + System.Environment.NewLine + "Result is " + result4;
        }

        //FINAL STEPS

        int[] final_step = new int[12];
        int s1;
        int s2;
        int s3;
        string s4;
        List<int> s5 = new List<int>();
        List<int> s6 = new List<int>();
        List<int> s7 = new List<int>();

        public void step1_FINAL(string date,string time)
        {
            message = message + System.Environment.NewLine + "***FINAL STEPS***";
            message = message + System.Environment.NewLine + "=====Step1=====";
            s5.Clear();
            s6.Clear();
            s7.Clear();
            s1 = 11;
            s2 = final8;
            s3 = tuning6;
            s4 = result4;
            DateList.Clear();
            dateAdd1(date);
            for (int i = 0; i < DateList.Count; i++)
            {
                s5.Add( DateList[i]);
            }

            DateList.Clear();
            dateAdd2(date);
            for (int i = 0; i < DateList.Count; i++)
            {
                s6.Add(DateList[i]);
            }
            int x = Int32.Parse(time);

            s7.Add(x);
            s7.Add(x + 1);
            s7.Add(2 * x + 1);

            sameCount = fuc_same(s3, s1);
            final_step[0] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();

        }

        public void step2_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step2=====";
            sameCount = fuc_same(s3, s2);
            final_step[1] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step3_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step3=====";
            sameCount = fuc_same(s3, s1 + s2);
            final_step[2] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step4_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step4=====";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                if (s3 == s7[i])
                {
                    sameCount++;
                }
            }
            final_step[3] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step5_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step5=====";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                if (s1 == s7[i])
                {
                    sameCount++;
                }
            }
            final_step[4] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step6_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step6=====";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                if (s2 == s7[i])
                {
                    sameCount++;
                }
            }
            final_step[5] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step7_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step7=====";
            sameCount = 0;

            for (int i = 0; i < s5.Count; i++)
            {
                if ( s1 + s2 == s5[i] && s1 + s2 > 9)
                {
                    sameCount++;
                }
            }
            for (int i = 0; i < s6.Count; i++)
            {
                if (s1 + s2 == s6[i] && s1 + s2 > 9)
                {
                    sameCount++;
                }
            }
            for (int i = 0; i < s6.Count; i++)
            {
                if (s1 + s2 == s6[i] && s1 + s2 > 9)
                {
                    sameCount++;
                }
            }
            final_step[6] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }
        int xxx;
        public void step8_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step8=====";
            sameCount = 0;
            if (s4 == "Down")
            {
                xxx = 1;
            }
            else xxx = 2;

            sameCount = fuc_same(s1, s3 + xxx);
            final_step[7] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step9_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step9=====";

            sameCount = fuc_same(s2, s3 + xxx);
            final_step[8] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step10_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step10=====";

            sameCount = fuc_same(s1 + s2, s3 + xxx);
            final_step[9] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }



        public void step11_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step11=====";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                sameCount = sameCount + fuc_same(s7[i], s3 + xxx);
            }
            
            final_step[10] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step12_FINAL()
        {
            message = message + System.Environment.NewLine + "=====Step12=====";
            sameCount = 0;
            for (int i = 0; i < 11; i++)
            {
                sameCount = sameCount + final_step[i];
            }

            final_step[11] = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        //Final Last part
        int part1;
        int part2;
        int part3;
        public void step1_part()
        {
            message = message + System.Environment.NewLine + "***Final Last part***";
            message = message + System.Environment.NewLine + "=====Step1=====";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                sameCount = sameCount + fuc_same(final_step[11], s7[i]);
            }

            part1 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();

        }

        public void step2_part()
        {
            message = message + System.Environment.NewLine + "=====Step2=====";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                for (int j = 0; j < s5.Count; j++)
                {
                    if (s7[i] == s5[j] && s7[i] > 9)
                    {
                        sameCount++;
                    }
                }
                for (int j = 0; j < s6.Count; j++)
                {
                    if (s7[i] == s6[j] && s7[i] > 9)
                    {
                        sameCount++;
                    }
                }
            }
            part2 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();

        }
        public void step3_part()
        {
            message = message + System.Environment.NewLine + "=====Step3=====";
            part3 = part1 + part2;
            message = message + System.Environment.NewLine + "Same is " + part3.ToString();
        }



        //Last Few Additions
        int few1, few2, few3;
        public void step1_few()
        {
            message = message + System.Environment.NewLine + "***Last Few Additions***";
            message = message + System.Environment.NewLine + "=====Step1=====";
            sameCount = 0;


            sameCount = sameCount + fuc_same(s7[0], 9);
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                sameCount = sameCount + fuc_same(SameList_Step1[i], 9);
                sameCount = sameCount + fuc_same(SameList_Step1[i] + s7[0], 9);
            }
            for (int i = 0; i < SameList_Step1.Count; i++)
            {
                for (int j = 0; j < s7.Count; j++)
                {
                    if (SameList_Step1[i] == s7[j])
                    {
                        sameCount++;
                    }
                }
            }
            few1 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step2_few()
        {
            message = message + System.Environment.NewLine + "=====Step2=====";
            sameCount = 0;
            
            sameCount = sameCount = sameCount + fuc_same(SameList_Step1[0] + s7[0], part3);
            int x;
            if (part3 % 2 == 0)
            {
                x = 2;
            }
            else x = 1;
            sameCount  = sameCount + fuc_same(SameList_Step1[0] + s7[0], x);
            few2 = sameCount;
            message = message + System.Environment.NewLine + "Same is " + sameCount.ToString();
        }

        public void step3_few()
        {
            this.message = this.message + Environment.NewLine + "=====Step3=====";
            this.sameCount = 0;
            int num = this.SameList_Step1[0] + this.s7[0];
            this.sameCount += this.fuc_same(this.s7[0], 9);
            this.sameCount += this.fuc_same(num + 1, this.s7[0]);
            this.sameCount += this.fuc_same(num + 1 + this.s7[0], 9);

            int x = num + 1 + this.s7[0];
            if (x > 99) x = x / 10 + x % 10;
            for (int i = 0; i < this.breakdown[x].Length; i++)
            {
                for (int j = 0; j < this.breakdown[this.s7[0]].Length; j++)
                {
                    bool flag = this.breakdown[x][i] == this.breakdown[this.s7[0]][j] && this.breakdown[this.s7[0]][j] > 9;
                    if (flag)
                    {
                        this.sameCount++;
                    }
                }
            }
            for (int k = 0; k < this.breakdown[x].Length; k++)
            {
                for (int l = 0; l < this.breakdown[this.s7[2]].Length; l++)
                {
                    bool flag2 = this.breakdown[x][k] == this.breakdown[this.s7[2]][l] && this.breakdown[this.s7[2]][l] > 9;
                    if (flag2)
                    {
                        this.sameCount++;
                    }
                }
            }
            x = num + 1 + 2 * this.s7[0];
            if (x > 99)
            {
                x = x / 10 + x % 10;
            }
            for (int m = 0; m < this.breakdown[x].Length; m++)
            {
                for (int n = 0; n < this.breakdown[this.s7[2]].Length; n++)
                {
                    bool flag3 = this.breakdown[x][m] == this.breakdown[this.s7[2]][n] && this.breakdown[this.s7[2]][n] > 9;
                    if (flag3)
                    {
                        this.sameCount++;
                    }
                }
            }
            this.message = this.message + Environment.NewLine + "Same is " + this.sameCount.ToString();
            this.few3 = this.few1 + this.few2 + this.sameCount;
            int num2 = this.few3;
            this.message = this.message + Environment.NewLine + "total same is " + this.few3.ToString();
            this.sameCount = 0;
            for (int num3 = 0; num3 < this.breakdown[this.s7[0]].Length; num3++)
            {
                for (int num4 = 0; num4 < this.breakdown[this.s7[0] + num2].Length; num4++)
                {
                    bool flag4 = this.breakdown[this.s7[0]][num3] == this.breakdown[this.s7[0] + num2][num4] && this.breakdown[this.s7[0]][num3] > 9;
                    if (flag4)
                    {
                        this.sameCount++;
                    }
                }
            }
            this.message = this.message + Environment.NewLine + "ex: Then add 5 to 18 is 23 is no same";
            this.message = this.message + Environment.NewLine + "Same is " + this.sameCount.ToString();
            this.few3 += this.sameCount;
            this.sameCount = 0;
            for (int num5 = 0; num5 < this.s7.Count; num5++)
            {
                bool flag5 = this.SameList_Step1[0] + num2 == this.s7[num5];
                if (flag5)
                {
                    this.sameCount++;
                }
                else
                {
                    for (int num6 = 0; num6 < this.breakdown[this.s7[num5]].Length; num6++)
                    {
                        for (int num7 = 0; num7 < this.breakdown[this.SameList_Step1[0] + num2].Length; num7++)
                        {
                            bool flag6 = this.breakdown[this.s7[num5]][num6] == this.breakdown[this.SameList_Step1[0] + num2][num7] && this.breakdown[this.s7[num5]][num6] > 9;
                            if (flag6)
                            {
                                this.sameCount++;
                            }
                        }
                    }
                }
            }
            this.message = this.message + Environment.NewLine + "ex: Then add 32+5=37 is 2 same with time add";
            this.message = this.message + Environment.NewLine + "Same is " + this.sameCount.ToString();
            this.few3 += this.sameCount;
            this.sameCount = 0;
            x = num + 1 + 2 * this.s7[0] + num2;
            if (x > 99)
            {
                x = x / 10 + x % 10;
            }
            for (int num8 = 0; num8 < this.breakdown[this.s7[1]].Length; num8++)
            {
                for (int num9 = 0; num9 < this.breakdown[x].Length; num9++)
                {
                    bool flag7 = this.breakdown[this.s7[1]][num8] == this.breakdown[x][num9] && this.breakdown[this.s7[1]][num8] > 9;
                    if (flag7)
                    {
                        this.sameCount++;
                    }
                }
            }
            this.message = this.message + Environment.NewLine + "ex: 87+5=92 one same time2=19’s 20";
            this.message = this.message + Environment.NewLine + "Same is " + this.sameCount.ToString();
            this.few3 += this.sameCount;
            this.sameCount = 0;
            for (int num10 = 0; num10 < this.s7.Count; num10++)
            {
                bool flag8 = this.SameList_Step1[0] + num2 == this.s7[num10];
                if (flag8)
                {
                    this.sameCount++;
                }
                else
                {
                    for (int num11 = 0; num11 < this.breakdown[this.s7[num10]].Length; num11++)
                    {
                        x = num + 1 + this.s7[0] + num2;
                        if (x > 99)
                        {
                            x = x / 10 + x % 10;
                        }
                        for (int num12 = 0; num12 < this.breakdown[x].Length; num12++)
                        {
                            bool flag9 = this.breakdown[this.s7[num10]][num11] == this.breakdown[x][num12] && this.breakdown[this.s7[num10]][num11] > 9;
                            if (flag9)
                            {
                                this.sameCount++;
                            }
                        }
                    }
                }
            }
            this.message = this.message + Environment.NewLine + "ex: Check 69+5=74 is no same";
            this.message = this.message + Environment.NewLine + "Same is " + this.sameCount.ToString();
            this.few3 += this.sameCount;
            this.message = this.message + Environment.NewLine + "Total Same is " + this.few3.ToString();
        }


        //STEPS FOR ADDITION
        string msg = "";
        int additioon = 0;
        public void addition1()
        {
            this.msg = this.msg + Environment.NewLine + "***STEPS FOR ADDITION***";
            sameCount = 0;
            sameCount = sameCount + fuc_same(s7[0], 9);
            sameCount = sameCount + fuc_same(SameList_Step1[0], 9);
            if (SameList_Step1[0] == s7[0])
            {
                sameCount++;
            }
            additioon = additioon + sameCount;
            this.msg = this.msg + Environment.NewLine + "1) Check time1 and step1 for 9 and exact same => " + sameCount.ToString();
        }

        public void addition2()
        {
            sameCount = 0;
            sameCount = sameCount + fuc_same(s7[0] + few3, 9);
            if (s7[0] == few3)
            {
                sameCount++;
            }
            additioon = additioon + sameCount;
            this.msg = this.msg + Environment.NewLine + "2) Time1 + total for 9 and exact => " + sameCount.ToString();
           
        }

        public void addition3()
        {
            sameCount = 0;
            sameCount = sameCount + fuc_same(few3, 9);
            sameCount = sameCount + fuc_same(SameList_Step1[0], 9);
            if (SameList_Step1[0] == few3)
            {
                sameCount++;
            }
            additioon = additioon + sameCount;
            this.msg = this.msg + Environment.NewLine + "3) step1 and total for 9 and exact => " + sameCount.ToString();
            
        }

        public void addition4()
        {
            sameCount = 0;

            sameCount = sameCount + fuc_same(SameList_Step1[0] + s7[0], 9);
            if (SameList_Step1[0] == s7[0])
            {
                sameCount++;
            }
            additioon = additioon + sameCount;
            this.msg = this.msg + Environment.NewLine + "4) time1 + step1 for 9 and exact => " + sameCount.ToString();
            
        }

        public void addition5()
        {
            sameCount = 0;

            sameCount = sameCount + fuc_same(SameList_Step1[0] + s7[0] + few3, 9);
            if (SameList_Step1[0] == s7[0])
            {
                sameCount++;
            }
            if (SameList_Step1[0] == few3)
            {
                sameCount++;
            }
            if (s7[0] == few3)
            {
                sameCount++;
            }
            additioon = additioon + sameCount;
            this.msg = this.msg + Environment.NewLine + "5) time1+step1+total for 9 and exact => " + sameCount.ToString();
            
        }

        //STEP FOR SUBTRACTION
        int subtraction = 0;
        public void subtraction1()
        {
            this.msg = this.msg + Environment.NewLine + "***STEPS FOR SUBTRACTION***";
            sameCount = 0;
            sameCount = fuc_same(Math.Abs(s7[0] - few3), 9);
            if (s7[0] == few3)
            {
                sameCount++;
            }
            subtraction = subtraction + sameCount;
            this.msg = this.msg + Environment.NewLine + "1) time1-total check 9 and exact => " + sameCount.ToString();
        }

        public void subtraction2()
        {
            sameCount = 0;
            sameCount = fuc_same(Math.Abs(SameList_Step1[0] - few3), 9);
            if (SameList_Step1[0] == few3)
            {
                sameCount++;
            }
            subtraction = subtraction + sameCount;
            this.msg = this.msg + Environment.NewLine + "2) step1-total check 9 and exact => " + sameCount.ToString();
        }

        public void subtraction3()
        {
            sameCount = 0;


            sameCount = fuc_same(Math.Abs(s7[0] + SameList_Step1[0] - few3), 9);
            if (SameList_Step1[0] == few3)
            {
                sameCount++;
            }
            if (SameList_Step1[0] == s7[0])
            {
                sameCount++;
            }
            if (few3 == s7[0])
            {
                sameCount++;
            }
            subtraction = subtraction + sameCount;
            this.msg = this.msg + Environment.NewLine + "3) time1+step1-total check 9 exact => " + sameCount.ToString();
        }

        //SOME MORE STEPS
        int more = 0;
        public void more1()
        {
            this.msg = this.msg + Environment.NewLine + "***SOME MORE STEPS***";
            sameCount = 0;

            sameCount = sameCount + fuc_same(Math.Abs(s7[0] - SameList_Step1[0]), 9);          

            more = more + sameCount;
            this.msg = this.msg + Environment.NewLine + "1) time1-step1 and check for 9 only => " + sameCount.ToString();
        }

        public void more2()
        {
            sameCount = 0;

            sameCount = sameCount + fuc_same(Math.Abs(s7[0] - SameList_Step1[0] + few3), 9);           

            more = more + sameCount;
            this.msg = this.msg + Environment.NewLine + "2) And (time1-step1) + total and check for 9 only => " + sameCount.ToString();
        }

        public void more3()
        {
            sameCount = 0;
            sameCount = sameCount + fuc_same(Math.Abs(s7[0] - SameList_Step1[0] - few3), 9);            

            more = more + sameCount;
            this.msg = this.msg + Environment.NewLine + "3) And (time1-step1) – total and check for 9 only => " + sameCount.ToString();
        }

        //Additions
        int additions = 0;
        int total;
        List<int> additions_List = new List<int>();

        
        public void additions1()
        {
            msg = "";
            additions = 0;
            additions_List.Clear();
            msg = "***Additions***";
            total = additioon + subtraction + more;
            msg = msg + Environment.NewLine + "Use time1 = " + s7[0].ToString() + " and step1 = " + SameList_Step1[0].ToString() + " and final count is " + total.ToString();
            msg = msg + Environment.NewLine + "STEP1) Check ";
            sameCount = 0;
            List<int> templist = new List<int>();

            list_add1(s7[0], templist);

            for (int i = 0; i < templist.Count; i++)
            {
                msg = msg + templist[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(templist[i], total);
            }
            msg = msg + " with " + total.ToString() + " is " + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }
        public void additions2()
        {
            msg = msg + Environment.NewLine + "STEP2) Check ";
            sameCount = 0;

            List<int> templist = new List<int>();
            list_add1(SameList_Step1[0], templist);
            for (int i = 0; i < templist.Count; i++)
            {
                msg = msg + templist[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(templist[i], total);
            }
            msg = msg + " with " + total.ToString() + " is " + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }

        public void additions3()
        {
            
            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP3) Check ";
            List<int> templist = new List<int>();
            list_add2(SameList_Step1[0], s7[0], templist);
            for (int i = 0; i < templist.Count; i++)
            {
                msg = msg + templist[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(templist[i], total);
            }
            msg = msg + " with " + total.ToString() + " is " + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }

        public void additions4()
        {
            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP4) Check ";
            List<int> templist = new List<int>();
            list_add2(s7[0], total, templist);
            for (int i = 0; i < templist.Count; i++)
            {
                msg = msg + templist[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(templist[i], total);
            }
            msg = msg + " with " + total.ToString() + " is " + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }

        public void additions5()
        {

            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP5) Check ";
            List<int> templist = new List<int>();
            list_add2(SameList_Step1[0], total, templist);
            for (int i = 0; i < templist.Count; i++)
            {
                msg = msg + templist[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(templist[i], total);
            }
            msg = msg + " with " + total.ToString() + " is " + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }

        public void additions6()
        {
            //msg = msg + Environment.NewLine + "STEP6) Then 21+29=50,51,11,12,23 with 3 is two same => ";
            sameCount = 0;
            List<int> add6 = new List<int>();
            //int x = SameList_Step1[0] + s7[0] + total + total;

            list_add2(SameList_Step1[0] + total, s7[0] + total, add6);
            msg = msg + Environment.NewLine + "STEP6) Check ";
            for (int i = 0; i < add6.Count; i++)
            {
                msg = msg + add6[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(add6[i], total);
            }

            msg = msg + "with " + total.ToString() + " is " +   sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }


        public void additions7()
        {
            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP7) Check ";
            List<int> templist = new List<int>();
            list_add3(s7[0], total, templist);
            for (int i = 0; i < templist.Count; i++)
            {
                msg = msg + templist[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(templist[i], total);
            }
            msg = msg + " with " + total.ToString() + " is " + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }

        public void additions8()
        {
            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP8) Check ";
            List<int> templist = new List<int>();
            list_add3(SameList_Step1[0], total, templist);
            for (int i = 0; i < templist.Count; i++)
            {
                msg = msg + templist[i].ToString() + ", ";
                sameCount = sameCount + exactSame2(templist[i], total);
            }
            msg = msg + " with " + total.ToString() + " is " + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }

        public void additions9()
        {

            sameCount = 0;

            int x = 0; 
            if (SameList_Step1[0] - total >= 0)
            {
                x = SameList_Step1[0] - total; 
            }
            if (s7[0] - total >= 0)
            {
                x = x + s7[0] - total;
            }

            if (x > 0)
            {
                sameCount = exactSame2(x, total);
                msg = msg + Environment.NewLine + "STEP9) Check " + x.ToString() + " with " + total.ToString() + " is ";
            }
            else
            {
                msg = msg + Environment.NewLine + "STEP9) ";
            }

            msg = msg + sameCount.ToString() + " same";
            additions = additions + sameCount;
            additions_List.Add(sameCount);
        }
        int add10_same = 0;
        int add11_same = 0;
        int add12_same = 0;
        int add13_same = 0;
        int add14_same = 0;
        public void additions10()
        {
            msg = msg + Environment.NewLine + "STEP10) Do until this part to show total same ";

            msg = msg + additions.ToString() + " same";
            additions_List.Add(additions);
            add10_same = additions;
        }

        int additions_last = 0;
        public void additions11()
        {
            additions_last = 0;
            msg = msg + Environment.NewLine + "STEP11) Add last same and final total is ";
            sameCount = additions + total;
            add11_same = sameCount;
            msg = msg + sameCount.ToString() + " same";
        }


        public void additions12()
        {
            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP12) ";
            int x = additions + total;// s7[0];

            List<int> temp = new List<int>();
            list_add2(x, s7[0], temp);

            for (int i = 0; i < temp.Count; i++)
            {
                msg = msg + temp[i].ToString() + ", ";
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < breakdown[additions_List[j]].Length; k++)
                    {
                        sameCount = sameCount + exactSame(temp[i], breakdown[additions_List[j]][k]);
                    }
                }
            }
            add12_same = sameCount;
            msg = msg + " with all number is " + sameCount.ToString() + " same";
        }

        public void additions13()
        {
            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP13) ";
            int x = additions + total;;

            List<int> temp = new List<int>();
            list_add2(x, SameList_Step1[0], temp);

            for (int i = 0; i < temp.Count; i++)
            {
                msg = msg + temp[i].ToString() + ", ";
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < breakdown[additions_List[j]].Length; k++)
                    {
                        sameCount = sameCount + exactSame(temp[i], breakdown[additions_List[j]][k]);
                    }
                }
            }
            add12_same = sameCount;
            msg = msg + " with all number is " + sameCount.ToString() + " same";
        }
        List<int> add14 = new List<int>();
        public void additions14()
        {
            sameCount = 0;

            msg = msg + Environment.NewLine + "STEP14) So is ";
            additions_last = additions_last + additions + total;
            msg = msg + additions_last.ToString() + " same";

        }


        

        int add15_same = 0;
        int add16_same = 0;
        int add17_same_1 = 0;
        int add17_same_2 = 0;
        int add17_same_3 = 0;
        List<int> add15_10_99 = new List<int>();
        List<int> add15 = new List<int>();
        List<int> add16 = new List<int>();
        List<int> add17 = new List<int>();
        public void additions15()
        {
            add15_10_99.Clear();
            sameCount = 0;
            msg = msg + Environment.NewLine + "STEP15) ";
            add15.Clear();
            list_add1(s7[0], add15);
            list_add1(SameList_Step1[0], add15);
            list_add2(s7[0],SameList_Step1[0], add15);

            list_add2(s7[0], total, add15);
            list_add2(SameList_Step1[0], total, add15);
            list_add2_1(SameList_Step1[0]+total, s7[0]+total, add15);

            list_add3(s7[0], total, add15);
            list_add3(SameList_Step1[0], total, add15);

            if(s7[0]-total>=0 && SameList_Step1[0]>=0) list_add2_1(s7[0]-total, SameList_Step1[0]-total, add15);
            if(s7[0] - total >= 0 && SameList_Step1[0] < 0) list_add3(s7[0], total, add15);
            if(s7[0] - total < 0 && SameList_Step1[0] >= 0) list_add3(SameList_Step1[0], total, add15);


            for (int i = 0; i < add15.Count; i++)
            {
                msg = msg + add15[i].ToString() + ", ";
            }
            string logtext = "";
            for (int i = 10; i < 100; i++)
            {
                int count = 0;
                for (int j = 0; j < add15.Count; j++)
                {
                    count = count + fuc_same(i, add15[j]);
                }
                add15_10_99.Add(count);
                logtext = logtext + Environment.NewLine + i.ToString() + " - " + count.ToString() + " same";
                sameCount = sameCount + count;
            }
            msg = msg  +  " is " + sameCount.ToString() + " same";
            while (sameCount  > 99)
            {
                sameCount = sameCount / 10 + sameCount % 10;
            }
            add15_same = sameCount;
            try
            {
                File.WriteAllText("step15.txt", logtext);
            }
            catch (Exception)
            {
            }
        }

        public void list_add1(int a, List<int> b)
        {
            b.Add(a);
            if (a % 10 == 0)
            {
                b.Add(a + 1);
                int x = 2 * a + 1;
                if (x < 100)
                {
                    b.Add(2 * a + 1);
                }
                else
                {
                    int y = x / 10 + x % 10;
                    b.Add(y);
                    b.Add(y + 1);
                    int z = 2 * y + 1;
                    x = z;
                    b.Add(z);
                    if (y % 10 == 0) x++;
                    if ((y + 1) % 10 == 0) x++;
                    if (y % 10 == 0 || (y + 1) % 10 == 0)
                    {
                        b.Add(x);
                        b.Add(z + x);
                    }


                }
                
            }
        }
        public void list_add2(int a, int b, List<int> c)
        {
            int x = a + b;
            if (x < 100)
            {
                list_add1(x, c);
                int y = x;
                if (a % 10 == 0) y++;
                if (b % 10 == 0) y++;
                if (a % 10 == 0 || b % 10 == 0)
                {
                    list_add1(y, c);
                    y = x + y;
                    int temp = y;
                    if (y > 99)
                        y = y / 10 + y % 10;
                    list_add1(y, c);
                    x = y;
                    if (temp / 10 % 10 == 0 || temp % 10 == 0)
                    {
                        if (temp / 10 %10 == 0) y++;
                        if (temp % 10 == 0) y++;
                        //list_add1(y, c);
                        //list_add1(x + y, c);
                        c.Add(y);
                        c.Add(x + y);
                    }
                }
            }
            else
            {
                int y = x / 10 + x % 10;
                int z = y;
                c.Add(y);

                if (x / 10 % 10 == 0 || x % 10 == 0)
                {
                    if (x / 10 % 10 == 0) z++;
                    if (x % 10 == 0) z++;
                    c.Add(z);
                    x = y + z;

                    if (x > 99)
                    {
                        x = x / 10 + x % 10;
                    }
                    c.Add(x);
                    if (y % 10 == 0 || z % 10 == 0)
                    {

                        if (y % 10 == 0) x++;
                        if (z % 10 == 0) x++;
                        //list_add1(x, c);
                        //list_add1(x + y + z, c);
                        c.Add(x);
                        c.Add(x + y + z);
                    }
                }

            }

        }
        public void list_add2_1(int a, int b, List<int> c)
        {
            int x = a + b;
            c.Add(x);
            int y = x;
            if (a % 10 == 0) y++;
            if (b % 10 == 0) y++;
            if (a % 10 == 0 || b % 10 == 0)
            {
                c.Add(y);
                c.Add(x + y);
            }
        }

        public void list_add3(int a, int b, List<int> c)
        {
            if (a-b>0) list_add1(a - b, c);
        }

        public int exactSame(int a, int b)
        {
            if (a > 9 && b > 9)
            {
                if (a == b) return 1;
                else if (a / 10 + a % 10 * 10 == b) return 1;
                else return 0;
            }
            else return 0;
        }
        public int exactSame1(int a, int b)
        {
            if (a > 9 && b > 9)
            {
                if (a == b) return 1;
                else return 0;
            }
            else return 0;
        }

        public int exactSame2(int a, int b)
        {
            //12,21,24,42,36,63,19,91
            if ((a == 12 || a == 21) && b == 1) return 2;
            if ((a == 24 || a == 42) && b == 2) return 2;
            if ((a == 36 || a == 63) && b == 3) return 2;
            if ((a == 19 || a == 91) && b == 1) return 2;
            if (a == b) return 1;
            if (a / 10 + a % 10 * 10 == b && a > 9 && b > 9) return 1;
            return 0;
        }
        public void additions16()
        {
            msg = msg + Environment.NewLine + "STEP16) So is ";
            add16.Clear();
            for (int i = 0; i < 4; i++)
            {
                add16.Add(add15_10_99[i] + (i + 10) * 10);
            }
            int addNumber = 0;
            for (int i = 0; i < add16.Count; i++)
            {
                msg += add16[i].ToString() + ", ";
                addNumber += add16[i];
            }
            msg += " is " + addNumber.ToString() + " = "; 
            while (addNumber > 99)
            {
                addNumber = addNumber / 10 + addNumber % 10;
            }
            msg += addNumber.ToString();

            List<int> result = new List<int>();
            for (int i = 0; i < add16.Count; i++)
            {
                add16_list(add16[i], result);
            }
            msg = msg + Environment.NewLine + " So ";
            sameCount = 0;
            for (int i = 0; i < result.Count; i++)
            {
                msg += result[i].ToString() + ", ";
                sameCount += fuc_same(result[i], addNumber);

            }
            msg += " with " + addNumber.ToString() + " is " + sameCount.ToString();

            add17_same_1 = addNumber;
            add17_same_2 = sameCount;

            int oldAddNumber1 = addNumber;
            int oldAddNumber2 = sameCount;
            addNumber += sameCount;
            msg += Environment.NewLine + " So " + addNumber.ToString() + " for 9 is ";

            sameCount = fuc_same(addNumber, 9);
            add16.Clear();
            add16.Add(sameCount);
            msg += sameCount.ToString();

            //Here need to do 49 check same with time 17,18,35 for same and breakdown

            
            msg += Environment.NewLine + "Check " + oldAddNumber1.ToString() + " with time for same and breakdown is ";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                sameCount = sameCount + fuc_same(oldAddNumber1, s7[i]);
                for (int j = 0; j < breakdown[s7[i]].Length; j++)
                {
                    sameCount += exactSame(oldAddNumber1, breakdown[s7[i]][j]);
                }
            }
            add16.Add(sameCount);
            msg += sameCount.ToString();

            //Need to check 8 with time 17,18,35 for same and breakdown
            msg += Environment.NewLine + "Check " + oldAddNumber2.ToString() + " with time for same and breakdown is ";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                sameCount = sameCount + fuc_same(oldAddNumber2, s7[i]);
                for (int j = 0; j < breakdown[s7[i]].Length; j++)
                {
                    sameCount += exactSame(oldAddNumber2, breakdown[s7[i]][j]);
                }
            }
            add16.Add(sameCount);
            msg += sameCount.ToString();

            //Then check 57 and time 17,18,37 for same and breakdown

            msg += Environment.NewLine + "Check " + addNumber.ToString() + " with time for same and breakdown is ";
            sameCount = 0;
            for (int i = 0; i < s7.Count; i++)
            {
                sameCount = sameCount + fuc_same(addNumber, s7[i]);
                for (int j = 0; j < breakdown[s7[i]].Length; j++)
                {
                    sameCount += exactSame(addNumber, breakdown[s7[i]][j]);
                }
            }
            add16.Add(sameCount);
            msg += sameCount.ToString();

            //Then here also 49 and 8 check for 9 same
            sameCount = 0;
            msg += Environment.NewLine + "Check " + oldAddNumber1.ToString() + " and " + oldAddNumber2.ToString() + " for 9 same is ";
            sameCount += fuc_same(oldAddNumber1, 9);
            sameCount += fuc_same(oldAddNumber2, 9);
            msg += sameCount.ToString();

            //Need to also check 49 and 8 for exact same and breakdown
            msg += Environment.NewLine + "Check " + oldAddNumber1.ToString() + " and " + oldAddNumber2.ToString() + " for exact same and breakdown is ";
            sameCount = 0;
            sameCount += fuc_same(oldAddNumber1, oldAddNumber2);
            sameCount += exactSame(oldAddNumber1, oldAddNumber2);
            add16.Add(sameCount);
            msg += sameCount.ToString();

            sameCount = 0;
            for (int i = 0; i < add16.Count; i++)
            {
                sameCount += add16[i];
            }

            msg += Environment.NewLine + "Total is " + sameCount.ToString();
            add16_same = sameCount;
            add17_same_3 = add16_same;

        }
        public void add16_list(int a, List<int> b)
        {
            if (a < 100) b.Add(a);
            else
            {
                b.Add(a / 10);
                b.Add(a % 10);
                b.Add(a / 10 + a % 10);
            }
        }
        int add17_same = 0;
        public void additions17()
        {
            sameCount = 0;
            msg = msg + Environment.NewLine + "-----------------------------------------";
            msg = msg + Environment.NewLine + add17_same_1.ToString() + ", " + add17_same_2.ToString() + ", " + add17_same_3.ToString();
            msg += Environment.NewLine + "Step1) " + add17_same_3.ToString() + " for 9 is ";
            sameCount = fuc_same(add17_same_3, 9);
            msg += sameCount.ToString() + " same";
            add17_same = sameCount;
        }
        int add18_same = 0;
        public void additions18()
        {
            List<int> add18 = new List<int>();
            list_add2(add17_same_2, add17_same_3, add18);
            msg += Environment.NewLine + "Step2) ";
            sameCount = 0;
            for (int i = 0; i < add18.Count; i++)
            {
                msg += add18[i].ToString() + ", ";
                sameCount += fuc_same(add18[i], 9);
            }
            add18.Add(add17_same_1);
            add18.Add(add17_same_2);
            add18.Add(add17_same_3);

            for (int i = 0; i < add18.Count -1; i++)
            {
                for (int j = i + 1; j < add18.Count; j++)
                {
                    sameCount += breakdownExactSame(add18[i], add18[j]);
                }
            }
            msg += "is "  + sameCount.ToString() + " same";
            add18_same = sameCount;
        }

        public int  breakdownExactSame(int a, int b)
        {
            int count = 0;
            if (a > 99) a = a / 10 + a % 10;
            if (b > 99) b = b / 10 + b % 10;
            for (int i = 0; i < breakdown[a].Length; i++)
            {
                for (int j = 0; j < breakdown[b].Length; j++)
                {
                    count += exactSame(breakdown[a][i], breakdown[b][j]);
                }
            }
            return count;
        }
        int add19_same = 0;
        public void additions19()
        {
            List<int> add19 = new List<int>();
            list_add2(add17_same_2 + add17_same_3, add17_same_1, add19);
            msg += Environment.NewLine + "Step3) ";
            sameCount = 0;
            for (int i = 0; i < add19.Count; i++)
            {
                msg += add19[i].ToString() + ", ";
                sameCount += fuc_same(add19[i], 9);
            }

            add19.Add(add17_same_1);
            add19.Add(add17_same_2);
            add19.Add(add17_same_3);
            add19.Add(add17_same_2 + add17_same_3);
            for (int i = 0; i < add19.Count - 1; i++)
            {
                for (int j = i + 1; j < add19.Count; j++)
                {
                    sameCount += breakdownExactSame(add19[i], add19[j]);
                }
            }
            msg += "is " + sameCount.ToString() + " same";
            add19_same = sameCount;            
        }
        int add20_same = 0;
        public void additions20()
        {
            msg += Environment.NewLine + "Step4) ";
            sameCount = 0;
            int total = add17_same + add18_same + add19_same;
            if (total == add17_same_2 + add17_same_3) sameCount = 1;
            List<int> add20 = new List<int>();

            list_add2(add17_same_2 + add17_same_3, total, add20);
            list_add3(add17_same_2 + add17_same_3, total, add20);
            list_add2(add17_same_2, total, add20);
            list_add2(add17_same_2 + add17_same_3 + total, add17_same_2 + add17_same_3 - total, add20);
            List<int> compare = new List<int>();
            int x = add17_same_1 + total;
            if (add17_same_1 % 10 == 0) x++;
            if (total % 10 == 0) x++;
            compare.Add(x);
            if (add17_same_1 - total > 0) compare.Add(add17_same_1 - total);

            for (int i = 0; i < add20.Count; i++)
            {
                msg += add20[i].ToString() + ", ";
                sameCount += fuc_same(add20[i], 9);
                for (int j = 0; j < compare.Count; j++)
                {
                    sameCount += breakdownExactSame(add20[i], compare[j]);
                }
            }
            msg += " same is " + sameCount.ToString();
            add20_same = sameCount;
        }

        int add21_same = 0;
        public void additions21()
        {
            msg += Environment.NewLine + "Step5) ";
            sameCount = 0;
            int total = add17_same + add18_same + add19_same + add20_same;
            int x = add17_same_1 + add17_same_2 + add17_same_3 + total;

            List<int> add21 = new List<int>();
            if (x < 100)
            {
                add21.Add(x);
            }
            else
            {
                int y = x / 10 + x % 10;
                add21.Add(y);
                add21.Add(y + 1);
                int z = 2 * y + 1;
                x = z;
                add21.Add(z);
                if (y % 10 == 0 || (y + 1) % 10 == 0)
                {
                    if (y % 10 == 0) z++;
                    if ((y + 1) % 10 == 0) z++;
                    add21.Add(z);
                    add21.Add(x + z);
                }
            }
            for (int i = 0; i < add21.Count; i++)
            {
                msg += add21[i].ToString() + ", ";
                sameCount += fuc_same(add21[i], 9);
            }
            msg +=  " for 9 same is " + sameCount.ToString();
            add21_same = sameCount;
        }


        public string  additions22()
        {
            string str1, str2;
            if ((add17_same_1 + add17_same_2 + add17_same_3) % 2 == 0)
            {
                str1 = "Up";
            }
            else { str1 = "Down"; }
            int total = add17_same + add18_same + add19_same + add20_same + add21_same;
            if (total % 2 == 0)
            {
                str2 = "Up";
            }
            else { str2 = "Down"; }

            string result;
            if (str1 == str2) result = "Up";
            else result = "Down";
            msg += Environment.NewLine + "Step6) " + str1 +" and " + str2 + " is " + result;
            return result;

        }

        int add23_same = 0;
        public void additions23()
        {
            msg = "";
            sameCount = 0;
            msg = msg + Environment.NewLine + "-----------------------------------------";
            msg = msg + Environment.NewLine + add17_same_1.ToString() + ", " + add17_same_2.ToString() + ", " + add17_same_3.ToString();
            
            int total = add17_same + add18_same + add19_same + add20_same + add21_same;
            sameCount = fuc_same(total, add17_same_1);
            sameCount += fuc_same(total, add17_same_2);
            sameCount += fuc_same(total, add17_same_3);
            msg += Environment.NewLine + "Step1) Check " + total.ToString() + " with " + add17_same_1.ToString() + ", " + add17_same_2.ToString() + ", " + add17_same_3.ToString() + " is " + sameCount.ToString();
            add23_same = sameCount;
        }
        int add24_same = 0;
        public void additions24()
        {
            sameCount = 0;
            int total = add17_same + add18_same + add19_same + add20_same + add21_same;
            msg += Environment.NewLine + "Step2) Check ";

            List<int> temp = new List<int>();
            list_add2(add17_same_2, add17_same_3, temp);
            for (int i = 0; i < temp.Count; i++)
            {
                msg += temp[i].ToString() + ", ";
                sameCount += fuc_same(total, temp[i]);
                sameCount += breakdownExactSame(temp[i], add17_same_1);
                sameCount += breakdownExactSame(temp[i], add17_same_2);
                sameCount += breakdownExactSame(temp[i], add17_same_3);
            }
            msg += " same is " + sameCount.ToString();
            add24_same = sameCount;
        }

        int add25_same = 0;
        public void additions25()
        {
            sameCount = 0;
            msg += Environment.NewLine + "Step3) Check ";
            List<int> temp1 = new List<int>();
            list_add2(add17_same_2, add17_same_3, temp1);
            List<int> temp = new List<int>();
            list_add2(add17_same_1, temp1[temp1.Count-1], temp);
            for (int i = 0; i < temp.Count; i++)
            {
                msg += temp[i].ToString() + ", ";
                sameCount += fuc_same(9, temp[i]);
            }
            temp.Add(add17_same_1);
            temp.Add(add17_same_2);
            list_add2(add17_same_2, add17_same_3, temp);

            for (int i = 0; i < temp.Count-1; i++)
            {
                for (int j = i + 1; j < temp.Count; j++)
                {
                    sameCount += breakdownExactSame(temp[i], temp[j]);
                }
            }
            msg += " same is " + sameCount.ToString();
            add25_same = sameCount;
        }
        int add26_same = 0;
        public void additions26()
        {
            sameCount = 0;
            add26_same = 0;
            int total = add17_same + add18_same + add19_same + add20_same + add21_same + add23_same + add24_same + add25_same;
            msg += Environment.NewLine + "Step4) 1) Check " + total.ToString() + " with " + add17_same_1.ToString() + ", " + add17_same_2.ToString() + ", " + add17_same_3.ToString();
            sameCount += fuc_same(total, add17_same_1);
            sameCount += fuc_same(total, add17_same_2);
            sameCount += fuc_same(total, add17_same_3);
            add26_same += sameCount;
            msg += " is " + sameCount.ToString();
            sameCount = 0;
            msg += Environment.NewLine + "Step4) 2) Check ";
            List<int> temp = new List<int>();
            list_add2(add17_same_1, add17_same_2 + add17_same_3, temp);
            for (int i = 0; i < temp.Count; i++)
            {
                msg += temp[i].ToString() + ", ";
                sameCount += fuc_same(temp[i], 9);
                sameCount += fuc_same(temp[i], total);
            }
            msg += " for 9 and " + total.ToString() + " same is " + sameCount.ToString();
            add26_same += sameCount;

            sameCount = 0;
            temp.Clear();
            list_add2(add17_same_1 + add17_same_2 + add17_same_3, total + add26_same, temp);
            msg += Environment.NewLine + "Step4) 3) Check ";
            for (int i = 0; i < temp.Count; i++)
            {
                msg += temp[i].ToString() + ", ";
                sameCount += fuc_same(temp[i], 9);
                sameCount += fuc_same(temp[i], total);
            }
            msg += " for 9 and " + total.ToString() + " same is " + sameCount.ToString();
            add26_same += sameCount;
            sameCount = fuc_same(add26_same, total);
            msg += Environment.NewLine + "Step4) 4) Check Total " + add26_same.ToString() + " for " + total.ToString() + " same is " + sameCount.ToString();
            add26_same += sameCount;
            msg += Environment.NewLine + "So Total is " + add26_same.ToString();



            ///last part
            msg += Environment.NewLine + "-------Last Part------";
            temp.Clear();
            list_add1(add26_same, temp);
            list_add1(total, temp);
            list_add2(add26_same, total, temp);
            sameCount = 0;
            int lastpart1 = 0;
            int lastpart2 = 0;
            int lastpart3 = 0;
            msg += Environment.NewLine + "Check ";
            for (int i = 0; i < temp.Count; i++)
            {
                msg += temp[i].ToString() + ", ";
                for (int j = 0; j < s7.Count; j++)
                {
                    sameCount += fuc_same(temp[i], s7[j]);
                }
                for (int j = 0; j < DateList.Count; j++)
                {
                    sameCount += fuc_same(temp[i], DateList[j]);
                }
                sameCount += fuc_same(temp[i], 9);
            }
            msg += " with time add and date add and 9 is " + sameCount.ToString() + " same";
            lastpart1 = sameCount;
            sameCount = 0;
            temp.Clear();
            list_add2(add26_same, lastpart1, temp);
            list_add2(total, lastpart1, temp);
            msg += Environment.NewLine + "Check ";
            for (int i = 0; i < temp.Count; i++)
            {
                msg += temp[i].ToString() + ", ";
                for (int j = 0; j < s7.Count; j++)
                {
                    sameCount += fuc_same(temp[i], s7[j]);
                }
                for (int j = 0; j < DateList.Count; j++)
                {
                    sameCount += fuc_same(temp[i], DateList[j]);
                }
                sameCount += fuc_same(temp[i], 9);
            }
            msg += " with time add and date add and 9 is " + sameCount.ToString() + " same";
            lastpart2 = sameCount;
            sameCount = 0;
            msg += Environment.NewLine + "Check ";
            sameCount = 0;
            temp.Clear();
            list_add1(lastpart1, temp);
            list_add1(lastpart2, temp);
            list_add2(lastpart1, lastpart2, temp);
            for (int i = 0; i < temp.Count; i++)
            {
                msg += temp[i].ToString() + ", ";
                for (int j = 0; j < s7.Count; j++)
                {
                    sameCount += fuc_same(temp[i], s7[j]);
                }
            }
            lastpart3 = sameCount;
            msg += " with time add " + lastpart3.ToString() + " same";


            add26_same = lastpart1 + lastpart2 + lastpart3;
            msg += Environment.NewLine + "So total is " + add26_same.ToString();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            String date = textBox1.Text;
            String time = textBox2.Text;
            formula(date, time);
           
            textBox3.Text = message;
            try
            {
                File.WriteAllText("logfile.txt", message);
            }
            catch (Exception)
            {
            }
            MessageBox.Show(msg);


        }

        public string formula( String date, String time)
        {
            formulaClear();
            dateAdd1(date);
            dateAdd2(date);
            timeAdd(time);
            step1();
            step2();
            step3();
            step4();
            step5();
            step6();
            step7();
            step8();
            step9();
            step10();
            result1 = step11();
            step1_add();
            step2_add();
            int same = step3_add();
            if (same % 2 == 1)
            {
                if (result1 == "Up")
                {
                    result2 = "Down";
                }
                else
                {
                    result2 = "Up";
                }
            }
            else
            {
                result2 = result1;
            }
            message = message + System.Environment.NewLine + "***Result***";
            message = message + System.Environment.NewLine + "" + result2;
            step4_add();

            step1_final(result2);
            step2_final();
            step3_final();
            step4_final();
            step5_final();
            step6_final();
            step7_final();
            same = step8_final();
            if (same % 2 == 1)
            {
                if (result2 == "Up")
                {
                    result3 = "Down";
                }
                else
                {
                    result3 = "Up";
                }
            }
            else
            {
                result3 = result2;
            }
            message = message + System.Environment.NewLine + "***Result***";
            message = message + System.Environment.NewLine + "" + result3;
            step1_tuning();
            step2_tuning();
            step3_tuning();
            step4_tuning();
            step5_tuning();
            step6_tuning();
            step7_tuning();

            step1_FINAL(date, time);
            step2_FINAL();
            step3_FINAL();
            step4_FINAL();
            step5_FINAL();
            step6_FINAL();
            step7_FINAL();
            step8_FINAL();
            step9_FINAL();
            step10_FINAL();
            step11_FINAL();
            step12_FINAL();

            string str = "";
            if (final_step[11] % 2 == 0)
            {
                str = "Up";
            }
            else str = "Down";
            message = message + System.Environment.NewLine + "***Result***";
            message = message + System.Environment.NewLine + "" + str;

            step1_part();
            step2_part();
            step3_part();
            if (part3 % 2 == 0)
            {
                str = "Up";
            }
            else str = "Down";
            message = message + System.Environment.NewLine + "***Result***";
            message = message + System.Environment.NewLine + "" + str;

            step1_few();
            step2_few();
            step3_few();

            if (few3 % 2 == 0)
            {
                str = "Up";
            }
            else str = "Down";
            message = message + System.Environment.NewLine + "***Result***";
            message = message + System.Environment.NewLine + "" + str;

            addition1();
            addition2();
            addition3();
            addition4();
            addition5();

            subtraction1();
            subtraction2();
            subtraction3();

            more1();
            more2();
            more3();

            int x = additioon + subtraction + more;
            msg = msg + System.Environment.NewLine + "Final Total is " + x.ToString();
            if (x % 2 == 0)
            {
                str = "Up";
            }
            else str = "Down";
            msg = msg + System.Environment.NewLine + "***Result***";
            msg = msg + System.Environment.NewLine + "" + str;
            message = message + msg;

            additions1();
            additions2();
            additions3();
            additions4();
            additions5();
            additions6();
            additions7();
            additions8();
            additions9();
            additions10();
            additions11();
            additions12();
            additions13();
            additions14();
            additions15();
            additions16();
            additions17();
            additions18();
            additions19();
            additions20();
            additions21();
            str = additions22();
            message = message + msg;
            additions23();
            additions24();
            additions25();
            additions26();
            if (add26_same % 2 == 0)
            {
                str = "Up";
            }
            else str = "Down";           

            msg = msg + System.Environment.NewLine + "***Result***";
            msg = msg + System.Environment.NewLine + "" + str;
            message = message + msg;
            return str;


            //MessageBox.Show(message);
        }

        public void formulaClear()
        {
            TimeList.Clear();
            DateList.Clear();
            SameList_Step1.Clear();
            SameList_Step2.Clear();
            List_Step4.Clear();
            SameList_Step4.Clear();
            SameList_Step5.Clear();
            SameList_Step6.Clear();
            SameList_Step7.Clear();
            List_Step8.Clear();
            SameList_Step8.Clear();
            SameList_Step9.Clear();
            SameList_Step10.Clear();
            sameCount = 0;
            lastRow = 0;
            message = "=====Step1=====";
            msg = "";
            additioon = 0;
            subtraction = 0;
            more = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(path);
            MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explict cast is not required here
            lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            int index = 2;
            try
            {
                for (index = 2; index <= lastRow; index++)
                {
                    try
                    {
                        System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "I" + index.ToString()).Cells.Value;

                        String date = MyValues.GetValue(1, 2).ToString();
                        double d = double.Parse(MyValues.GetValue(1, 3).ToString()) * 24;
                        String time = Math.Round(d).ToString();
                        string str = formula(date, time);
                        lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                        MySheet.Cells[index, 9] = str;
                    }
                    catch (Exception)
                    {
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(index.ToString());
                MessageBox.Show(ex.ToString());
            }
            MyBook.Close(true);
            MyApp.Quit();
            MessageBox.Show("Done");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ExcelDialog = new OpenFileDialog();

            ExcelDialog.InitialDirectory = "c:\\";
            ExcelDialog.Title = "Select your team excel";
            ExcelDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            ExcelDialog.FilterIndex = 2;
            ExcelDialog.RestoreDirectory = true;

            if (ExcelDialog.ShowDialog() == DialogResult.OK)
            {
                path = ExcelDialog.FileName;
                button2.Enabled = true;
            }
        }

//         private void button4_Click(object sender, EventArgs e)
//         {
//             sameCount = fuc_same(Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text));
//             MessageBox.Show(sameCount.ToString());
//         }
    }
}
