using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
//Name: Keerthi Kiran Chennabathni
//Date: 15/05/2020
//Assignment: Vote Processing Machine
//Purpose: to expand on understanding of objects, sorting, searching and FileIO
namespace Assignment3_ChennabathniK
{
    public partial class VoteProcessingMachine : Form
    {
        public VoteProcessingMachine()
        {
            InitializeComponent();
        }
        long Lines = 0;//number of lines in the student database file
        long Lines1 = 0;//number of lines in the student votes file

        bool checkSDB = false;//check if the student database file has been loaded
        bool checkSV = false;//check is the student votes file has been loaded
        public void btn_LoadStudentData_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFiled = new OpenFileDialog();//opens file dialog 
            if (OFiled.ShowDialog() == DialogResult.OK)//if a file is selected
            {
                checkSDB = true;//student database is loaded

                txt_StudentData.Text = displayStudents(OFiled.FileName);//method to display the txt in the SDB File

                Lines = readStudentDataBase(OFiled.FileName);//method to count the number of lines with txt in the SDB File

                StudentDataBase StudentDataBase = new StudentDataBase();//object of the class Student DataBase created
                StudentDataBase.firstname = new string[Lines - 1];//initializing the arrays
                StudentDataBase.lastname = new string[Lines - 1];
                StudentDataBase.studentId = new string[Lines - 1];
                StudentDataBase.gender = new string[Lines - 1];
                StudentDataBase.grade = new string[Lines - 1];
                StudentDataBase.dob = new string[Lines - 1];

                saveStudentDataBase(OFiled.FileName, Lines);//method to save all the student data in the arrays above
            }
        }
        public static string displayStudents(string FileName)
        {
            StreamReader StrR = new StreamReader(FileName);//object of streamreader created
            string Display = StrR.ReadToEnd();//file is read to end and stored in one string
            return Display;//returns the string and displays on lbl
        }
        public static long readStudentDataBase(string FileName)
        {
            StreamReader StrR = new StreamReader(FileName);//object streamreader created
            long count = 0;//count of lines of text starts at 0
            while (StrR.ReadLine() != null)//until there are no more lines with text
            {
                count++;//no of lines increases by 1
            }
            return count;
        }
        public static void saveStudentDataBase(string FileName, long Lines)
        {
            StreamReader StrR = new StreamReader(FileName);
            StrR.ReadLine();//since the first line is not data 
            string[] temp = new string[6];//temp stores each piece of info in one line 
            for (int i = 0; i < (Lines - 1); i++)
            {
                string line = StrR.ReadLine().Replace(@"""", string.Empty);//removes "" in the text
                temp = line.Split(',');//splits one line by ,
                StudentDataBase.firstname[i] = temp[1];//stores the respective info in the arrays 
                StudentDataBase.lastname[i] = temp[0];
                StudentDataBase.studentId[i] = temp[2].Replace("-", string.Empty);
                StudentDataBase.gender[i] = temp[3];
                StudentDataBase.grade[i] = temp[4];
                StudentDataBase.dob[i] = temp[5];

            }
        }

        int voters = 0;//number of voters in total 
        private void btn_LoadStudentVotes_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFiled = new OpenFileDialog();
            if (OFiled.ShowDialog() == DialogResult.OK)
            {
                checkSV = true;//Student Votes has been uploaded
                if(checkSDB == true)//checks if student database file is uploaded since its required for clean up 
                {
                    Lines1 = readStudentDataBase(OFiled.FileName);//counts the number of txt in student vote file

                    StudentDataBase.firstnamev = new string[Lines1 - 1];//initializing arrays for student votes
                    StudentDataBase.lastnamev = new string[Lines1 - 1];
                    StudentDataBase.studentIdv = new string[Lines1 - 1];
                    StudentDataBase.Post1V = new string[Lines1 - 1];
                    StudentDataBase.Post2V = new string[Lines1 - 1];
                    StudentDataBase.Post3V = new string[Lines1 - 1];
                    StudentDataBase.Post4V = new string[Lines1 - 1];

                    voters = Int16.Parse(studentVotes(Lines1, OFiled.FileName, Lines));//counts the number of voters after clean up

                    //displays summary 
                    lbl_NumVoters1.Text = studentVotes(Lines1, OFiled.FileName, Lines);//counts the number of voters after clean up
                    lbl_NumFemales1.Text = getFemaleNum(Lines1, OFiled.FileName, Lines);//counts the number of female voters
                    lbl_NumMales1.Text = getMaleNum(Lines1, OFiled.FileName, Lines);//counts the number of male voters
                }
                else//if student database file is not uploaded it will ask user to upload it 
                {
                    MessageBox.Show("Load Student Database File");
                }
            }
        }
        public static string studentVotes(long count, string File, long counts)
        {
            long voters = 0;

            string[] temp1 = new string[8];//same process as the sdb file but we only need to save the firstname, lastname and studentid to clean up student votes
            StreamReader Str = new StreamReader(File);
            for (int i = 0; i < count - 1; i++)
            {
                string line = Str.ReadLine();
                temp1 = line.Split(',');
                StudentDataBase.firstnamev[i] = temp1[0];
                StudentDataBase.lastnamev[i] = temp1[1];
                StudentDataBase.studentIdv[i] = temp1[2];

                for (int t = 0; t < counts - 1; t++)//length of sdb file
                {
                    int n = 0;//used as index ref for post arrays
                    if (StudentDataBase.firstnamev[i] == StudentDataBase.firstname[t].Trim() && StudentDataBase.lastnamev[i] == StudentDataBase.lastname[t].Trim() && StudentDataBase.studentIdv[i] == StudentDataBase.studentId[t].Trim())// checks if firstname, lastname, studentid match
                    {
                        int add = 0;//to check if the data is not repeated 
                        for (int k = 0; k < count - 1; k++)
                        {
                            if (StudentDataBase.firstnamev[k] != StudentDataBase.firstnamev[i])//if its not repeated
                            {
                                add++;//add to this var
                            }
                            if (add == count - 2)//if var is count -2 it means that there are no duplicates
                            {
                                voters++;//no of voters increases by 1

                                StudentDataBase.Post1V[n] = temp1[3];//stores all the votes for the respective positions
                                StudentDataBase.Post2V[n] = temp1[4];
                                StudentDataBase.Post3V[n] = temp1[5];
                                StudentDataBase.Post4V[n] = temp1[6];

                                n++;//increases post[] index
                            }
                        }
                    }
                }
            }
            return voters.ToString();//returns the num of voters in total
        }
        public static string getFemaleNum(long count, string File, long counts)
        {
            int femalenum = 0;
            for(int i =0;i<count-1;i++)
            {
                for (int t = 0; t < counts - 1; t++)//length of sdb file
                {
                    if (StudentDataBase.firstnamev[i] == StudentDataBase.firstname[t].Trim() && StudentDataBase.lastnamev[i] == StudentDataBase.lastname[t].Trim() && StudentDataBase.studentIdv[i] == StudentDataBase.studentId[t].Trim())
                    {//again checks if first,last, id are same
                        if(StudentDataBase.gender[t].Trim() == "F")//at the index where ^ is true it will check if gender is F
                        {
                            femalenum++;//increases by 1
                        }
                    }
                }
            }
            return femalenum.ToString();//return num females to display on lbl
        }
        public static string getMaleNum(long count, string File, long counts)
        {
            int malenum = 0;
            for (int i = 0; i < count - 1; i++)
            {
                for (int t = 0; t < counts - 1; t++)//length of sdb file
                {
                    if (StudentDataBase.firstnamev[i] == StudentDataBase.firstname[t].Trim() && StudentDataBase.lastnamev[i] == StudentDataBase.lastname[t].Trim() && StudentDataBase.studentIdv[i] == StudentDataBase.studentId[t].Trim())
                    {//again checks if first,last, id are same
                        if (StudentDataBase.gender[t].Trim() == "M")//at the index where ^ is true it will check if gender is M
                        {
                            malenum++;//increases by 1
                        }
                    }
                }
            }
            return malenum.ToString();//return num males to display on lbl
        }

        private void btn_Sort_Click(object sender, EventArgs e)
        {
            if (checkSDB == true)//if student database file is uploaded
            {
                while (ddl_SortingOptions.SelectedIndex == -1)//if a sorting option is not selected it will prompt user to do so 
                {
                    MessageBox.Show("Please select a sorting option");
                }


                if (chk_QuickSort.Checked)//if quick sort is checked
                {
                    if (ddl_SortingOptions.SelectedIndex == 0)//if the sorting option is firstname
                    {
                        lbl_Time1.Text = quickSort(StudentDataBase.firstname, 0, StudentDataBase.firstname.Length - 1);//data is quick sorted, time is returned

                        txt_StudentData.Text = "";//clears the lbl
                        for (int i = 0; i < Lines - 1; i++)//displays newly sorted data
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 1)//if the sorting option is lastname
                    {
                        lbl_Time1.Text = quickSort(StudentDataBase.lastname, 0, StudentDataBase.lastname.Length - 1);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 2)//if the sorting option is studentid
                    {
                        lbl_Time1.Text = quickSort(StudentDataBase.studentId, 0, StudentDataBase.studentId.Length - 1);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 3)//if the sorting option is gender
                    {
                        lbl_Time1.Text = quickSort(StudentDataBase.gender, 0, StudentDataBase.gender.Length - 1);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 4)//if the sorting option is grade
                    {
                        lbl_Time1.Text = quickSort(StudentDataBase.grade, 0, StudentDataBase.grade.Length - 1);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 5)
                    {
                        lbl_Time1.Text = quickSort(StudentDataBase.dob, 0, StudentDataBase.dob.Length - 1);//if the sorting option is dateofbirth
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                }


                else//^same thing but buuble sort
                {
                    if (ddl_SortingOptions.SelectedIndex == 0)
                    {
                        lbl_Time1.Text = bubbleSort(StudentDataBase.firstname);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 1)
                    {
                        lbl_Time1.Text = bubbleSort(StudentDataBase.lastname);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 2)
                    {
                        lbl_Time1.Text = bubbleSort(StudentDataBase.studentId);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 3)
                    {
                        lbl_Time1.Text = bubbleSort(StudentDataBase.gender);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 4)
                    {
                        lbl_Time1.Text = bubbleSort(StudentDataBase.grade);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                    else if (ddl_SortingOptions.SelectedIndex == 5)
                    {
                        lbl_Time1.Text = bubbleSort(StudentDataBase.dob);
                        txt_StudentData.Text = "";
                        for (int i = 0; i < Lines - 1; i++)
                        {
                            txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Load Student Database...");
            }
        }
        public static string quickSort(string[] sort, int start, int end)
        {
            Stopwatch stop = Stopwatch.StartNew();//starts timing
            int i = start;//index ref to check elements before the pivot
            int j = end;//index ref to check elements after the pivot
            string pivot = sort[(start + end) / 2];//pivot point in the middle
            while (i <= j)//until the pivot is reached
            {
                while (string.Compare(sort[i], pivot) < 0)//increases index if the element is less than pivot until it finds an element which isnt
                {
                    i++;
                }
                while (string.Compare(sort[j], pivot) > 0)//decreases index if the element is greater than pivot until it finds an element which isnt
                {
                    j--;
                }
                if (i <= j)
                {
                    //swapping all the arrays respectively
                    string temp = StudentDataBase.firstname[i];
                    StudentDataBase.firstname[i] = StudentDataBase.firstname[j];
                    StudentDataBase.firstname[j] = temp;
                    string temp1 = StudentDataBase.lastname[i];
                    StudentDataBase.lastname[i] = StudentDataBase.lastname[j];
                    StudentDataBase.lastname[j] = temp1;
                    string temp2 = StudentDataBase.studentId[i];
                    StudentDataBase.studentId[i] = StudentDataBase.studentId[j];
                    StudentDataBase.studentId[j] = temp2;
                    string temp3 = StudentDataBase.gender[i];
                    StudentDataBase.gender[i] = StudentDataBase.gender[j];
                    StudentDataBase.gender[j] = temp3;
                    string temp4 = StudentDataBase.grade[i];
                    StudentDataBase.grade[i] = StudentDataBase.grade[j];
                    StudentDataBase.grade[j] = temp4;
                    string temp5 = StudentDataBase.dob[i];
                    StudentDataBase.dob[i] = StudentDataBase.dob[j];
                    StudentDataBase.dob[j] = temp5;

                    i++;
                    j--;
                }
            }
            if (start < j)
            {
                quickSort(sort, start, j);//call method again, recursion call
            }//before the pivot
            if (i < end)
            {
                quickSort(sort, i, end);//call method again, recursion call
            }//after the pivot
            return stop.ElapsedTicks.ToString();//ends time and returns to display on lbl
        }
        public static string bubbleSort(string[] sort)
        {
            Stopwatch stop = Stopwatch.StartNew();//starts timing
            for (int i = 0; i < sort.Length; i++)//repeats until sorted
            {
                for (int j = 0; j < sort.Length - 1; j++)//len-1 becuz we will add 1 to index, it makes sure it doesnt go out of bounds
                {
                    if (string.Compare(sort[j], sort[j + 1]) > 0)//compares string at index and index+1
                    {
                        //swapping all the arrays respectively
                        string temp = StudentDataBase.firstname[j];
                        StudentDataBase.firstname[j] = StudentDataBase.firstname[j + 1];
                        StudentDataBase.firstname[j + 1] = temp;
                        string temp1 = StudentDataBase.lastname[j];
                        StudentDataBase.lastname[j] = StudentDataBase.lastname[j + 1];
                        StudentDataBase.lastname[j + 1] = temp1;
                        string temp2 = StudentDataBase.studentId[j];
                        StudentDataBase.studentId[j] = StudentDataBase.studentId[j + 1];
                        StudentDataBase.studentId[j + 1] = temp2;
                        string temp3 = StudentDataBase.gender[j];
                        StudentDataBase.gender[j] = StudentDataBase.gender[j + 1];
                        StudentDataBase.gender[j + 1] = temp3;
                        string temp4 = StudentDataBase.grade[j];
                        StudentDataBase.grade[j] = StudentDataBase.grade[j + 1];
                        StudentDataBase.grade[j + 1] = temp4;
                        string temp5 = StudentDataBase.dob[j];
                        StudentDataBase.dob[j] = StudentDataBase.dob[j + 1];
                        StudentDataBase.dob[j + 1] = temp5;
                    }
                }
            }
            return stop.ElapsedTicks.ToString();//ends time and returns to display on lbl
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if(checkSDB == true)
            {
                if (txt_SearchTangent.Text == "Enter search tangent...")//checks if search tangent is inputed
                {
                    MessageBox.Show("Enter search tangent...");
                }
                else
                {
                    if (ddl_SearchingOptions.SelectedIndex == -1)//checks if a searching option is selected
                    {
                        MessageBox.Show("Please select a searching option");
                    }
                    else
                    {
                        string search = txt_SearchTangent.Text;//stores the search tangent
                        if (ddl_SearchingOptions.SelectedIndex == 0)//if searching op is firstname
                        {
                            Stopwatch stop = Stopwatch.StartNew();//starts timing
                            int notfound = 0;//to check if all the elements dont match 
                            txt_StudentData.Text = "";//clears lbl
                            for (int i = 0; i < StudentDataBase.firstname.Length - 1; i++)
                            {
                                if (StudentDataBase.firstname[i] == search)//if input matches with the firstname array
                                {
                                    txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;//outputs in lbl each instance
                                }
                                else
                                {
                                    notfound++;//increase by 1 
                                }
                            }
                            if (notfound == StudentDataBase.firstname.Length - 1)//if it is the number of elements in the array 
                            {
                                txt_StudentData.Text = "Not Found";//outputs tht none are found
                            }
                            lbl_Time3.Text = stop.ElapsedTicks.ToString();
                        }
                        else if (ddl_SearchingOptions.SelectedIndex == 1)
                        {
                            Stopwatch stop = Stopwatch.StartNew();
                            int notfound = 0;
                            txt_StudentData.Text = "";
                            for (int i = 0; i < StudentDataBase.lastname.Length - 1; i++)
                            {
                                if (StudentDataBase.lastname[i] == search)
                                {
                                    txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                                }
                                else
                                {
                                    notfound++;
                                }
                            }
                            if (notfound == StudentDataBase.lastname.Length - 1)
                            {
                                txt_StudentData.Text = "Not Found";
                            }
                            lbl_Time3.Text = stop.ElapsedTicks.ToString();
                        }
                        else if (ddl_SearchingOptions.SelectedIndex == 2)
                        {
                            Stopwatch stop = Stopwatch.StartNew();
                            int notfound = 0;
                            txt_StudentData.Text = "";
                            for (int i = 0; i < StudentDataBase.studentId.Length - 1; i++)
                            {
                                if (StudentDataBase.studentId[i] == search)
                                {
                                    txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                                }
                                else
                                {
                                    notfound++;
                                }
                            }
                            if (notfound == StudentDataBase.studentId.Length - 1)
                            {
                                txt_StudentData.Text = "Not Found";
                            }
                            lbl_Time3.Text = stop.ElapsedTicks.ToString();
                        }
                        else if (ddl_SearchingOptions.SelectedIndex == 3)
                        {
                            Stopwatch stop = Stopwatch.StartNew();
                            int notfound = 0;
                            txt_StudentData.Text = "";
                            for (int i = 0; i < StudentDataBase.gender.Length - 1; i++)
                            {
                                if (StudentDataBase.gender[i] == search)
                                {
                                    txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                                }
                                else
                                {
                                    notfound++;
                                }
                            }
                            if (notfound == StudentDataBase.gender.Length - 1)
                            {
                                txt_StudentData.Text = "Not Found";
                            }
                            lbl_Time3.Text = stop.ElapsedTicks.ToString();
                        }
                        else if (ddl_SearchingOptions.SelectedIndex == 4)
                        {
                            Stopwatch stop = Stopwatch.StartNew();
                            int notfound = 0;
                            txt_StudentData.Text = "";
                            for (int i = 0; i < StudentDataBase.grade.Length - 1; i++)
                            {
                                if (StudentDataBase.grade[i] == search)
                                {
                                    txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                                }
                                else
                                {
                                    notfound++;
                                }
                            }
                            if (notfound == StudentDataBase.grade.Length - 1)
                            {
                                txt_StudentData.Text = "Not Found";
                            }
                            lbl_Time3.Text = stop.ElapsedTicks.ToString();
                        }
                        else if (ddl_SearchingOptions.SelectedIndex == 5)
                        {
                            Stopwatch stop = Stopwatch.StartNew();
                            int notfound = 0;
                            txt_StudentData.Text = "";
                            for (int i = 0; i < StudentDataBase.dob.Length - 1; i++)
                            {
                                if (StudentDataBase.dob[i] == search)
                                {
                                    txt_StudentData.Text += StudentDataBase.firstname[i] + ", " + StudentDataBase.lastname[i] + ", " + StudentDataBase.studentId[i] + ", " + StudentDataBase.gender[i] + ", " + StudentDataBase.grade[i] + ", " + StudentDataBase.dob[i] + Environment.NewLine;
                                }
                                else
                                {
                                    notfound++;
                                }
                            }
                            if (notfound == StudentDataBase.dob.Length - 1)
                            {
                                txt_StudentData.Text = "Not Found";
                            }
                            lbl_Time3.Text = stop.ElapsedTicks.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Load Student Database...");
            }
        }

        private void btn_Winner_Click(object sender, EventArgs e)
        {
            //i manually did this because i had no more brain power left to make it efficient sorry sir 
            if (checkSDB == true && checkSV == true)
            {
                //post1
                int a = 0;
                int b = 0;
                int c = 0;
                for (int i = 0; i < voters; i++)
                {
                    if (StudentDataBase.Post1V[i].Trim() == "Ayesha Abdullah")
                    {
                        a++;
                    }
                    else if (StudentDataBase.Post1V[i].Trim() == "Fiza Shahid")
                    {
                        b++;
                    }
                    else if (StudentDataBase.Post1V[i].Trim() == "Kalista Thavakumar")
                    {
                        c++;
                    }
                    
                }
                if (a > b && b >= c)
                {
                    MessageBox.Show("Post 1: Ayesha Abdullah wins with " + a + " votes");
                }
                else if (b > c && c >= a)
                {
                    MessageBox.Show("Post 1: Fiza Shahid wins with " + b + " votes");
                }
                else if (c > a && a >= b)
                {
                    MessageBox.Show("Post 1: Kalista Thavakumar wins with " + c + " votes");
                }
                //post2
                a = 0;
                b = 0;
                for (int i = 0; i < voters; i++)
                {
                    if (StudentDataBase.Post2V[i].Trim() == "Shivani Anand")
                    {
                        a++;
                    }
                    else if (StudentDataBase.Post2V[i].Trim() == "Danika Guerrero")
                    {
                        b++;
                    }
                }
                if (a > b)
                {
                    MessageBox.Show("Post 2: Shivani Anand wins with " + a + " votes");
                }
                else
                {
                    MessageBox.Show("Post 2: Danika Guerrero wins with " + b + " votes");
                }
                //post3
                a = 0;
                b = 0;
                for (int i = 0; i < voters; i++)
                {
                    if (StudentDataBase.Post3V[i].Trim() == "Sasha Fell")
                    {
                        a++;
                    }
                    else if (StudentDataBase.Post3V[i].Trim() == "Maria Halimi")
                    {
                        b++;
                    }
                }
                if (a > b)
                {
                    MessageBox.Show("Post 3: Sasha Fell wins with " + a + " votes");
                }
                else
                {
                    MessageBox.Show("Post 3: Maria Halimi wins with " + b + " votes");
                }
                //post4
                a = 0;
                b = 0;
                c = 0;
                for (int i = 0; i < voters; i++)
                {
                    if (StudentDataBase.Post4V[i].Trim() == "Zaina Nofal")
                    {
                        a++;
                    }
                    else if (StudentDataBase.Post4V[i].Trim() == "Sarah Al-Dereal")
                    {
                        b++;
                    }
                    else if (StudentDataBase.Post4V[i].Trim() == "Malak Alhadidi")
                    {
                        c++;
                    }
                }
                if (a > b && b >= c)
                {
                    MessageBox.Show("Post 4: Zaina Nofal wins with " + a + " votes");
                }
                else if (b > c && c >= a)
                {
                    MessageBox.Show("Post 4: Sarah Al-Dereal wins with " + b + " votes");
                }
                else if (c > a && a >= b)
                {
                    MessageBox.Show("Post 4: Malak Alhadidi wins with " + c + " votes");
                }
            }
            else
            {
                MessageBox.Show("Load Student DataBase and Student Votes");
            }
        }
    }
}
