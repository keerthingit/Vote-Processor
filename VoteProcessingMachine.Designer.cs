namespace Assignment3_ChennabathniK
{
    partial class VoteProcessingMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_LoadStudentData = new System.Windows.Forms.Button();
            this.btn_LoadStudentVotes = new System.Windows.Forms.Button();
            this.grp_Sort = new System.Windows.Forms.GroupBox();
            this.chk_QuickSort = new System.Windows.Forms.CheckBox();
            this.lbl_Time1 = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.btn_Sort = new System.Windows.Forms.Button();
            this.ddl_SortingOptions = new System.Windows.Forms.ComboBox();
            this.grp_Search = new System.Windows.Forms.GroupBox();
            this.ddl_SearchingOptions = new System.Windows.Forms.ComboBox();
            this.lbl_Time3 = new System.Windows.Forms.Label();
            this.lbl_Time2 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_SearchTangent = new System.Windows.Forms.TextBox();
            this.grp_Summary = new System.Windows.Forms.GroupBox();
            this.lbl_NumFemales1 = new System.Windows.Forms.Label();
            this.lbl_NumFemales = new System.Windows.Forms.Label();
            this.lbl_NumMales1 = new System.Windows.Forms.Label();
            this.lbl_NumMales = new System.Windows.Forms.Label();
            this.lbl_NumVoters1 = new System.Windows.Forms.Label();
            this.lbl_NumVoters = new System.Windows.Forms.Label();
            this.btn_Winner = new System.Windows.Forms.Button();
            this.txt_StudentData = new System.Windows.Forms.TextBox();
            this.grp_Sort.SuspendLayout();
            this.grp_Search.SuspendLayout();
            this.grp_Summary.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_LoadStudentData
            // 
            this.btn_LoadStudentData.Location = new System.Drawing.Point(1062, 112);
            this.btn_LoadStudentData.Name = "btn_LoadStudentData";
            this.btn_LoadStudentData.Size = new System.Drawing.Size(465, 119);
            this.btn_LoadStudentData.TabIndex = 1;
            this.btn_LoadStudentData.Text = "Load Student Database";
            this.btn_LoadStudentData.UseVisualStyleBackColor = true;
            this.btn_LoadStudentData.Click += new System.EventHandler(this.btn_LoadStudentData_Click);
            // 
            // btn_LoadStudentVotes
            // 
            this.btn_LoadStudentVotes.Location = new System.Drawing.Point(1062, 302);
            this.btn_LoadStudentVotes.Name = "btn_LoadStudentVotes";
            this.btn_LoadStudentVotes.Size = new System.Drawing.Size(465, 119);
            this.btn_LoadStudentVotes.TabIndex = 2;
            this.btn_LoadStudentVotes.Text = "Load Student Votes";
            this.btn_LoadStudentVotes.UseVisualStyleBackColor = true;
            this.btn_LoadStudentVotes.Click += new System.EventHandler(this.btn_LoadStudentVotes_Click);
            // 
            // grp_Sort
            // 
            this.grp_Sort.Controls.Add(this.chk_QuickSort);
            this.grp_Sort.Controls.Add(this.lbl_Time1);
            this.grp_Sort.Controls.Add(this.lbl_Time);
            this.grp_Sort.Controls.Add(this.btn_Sort);
            this.grp_Sort.Controls.Add(this.ddl_SortingOptions);
            this.grp_Sort.Location = new System.Drawing.Point(1065, 483);
            this.grp_Sort.Name = "grp_Sort";
            this.grp_Sort.Size = new System.Drawing.Size(462, 309);
            this.grp_Sort.TabIndex = 3;
            this.grp_Sort.TabStop = false;
            this.grp_Sort.Text = "Sorting";
            // 
            // chk_QuickSort
            // 
            this.chk_QuickSort.AutoSize = true;
            this.chk_QuickSort.Location = new System.Drawing.Point(39, 116);
            this.chk_QuickSort.Name = "chk_QuickSort";
            this.chk_QuickSort.Size = new System.Drawing.Size(151, 33);
            this.chk_QuickSort.TabIndex = 7;
            this.chk_QuickSort.Text = "QuickSort";
            this.chk_QuickSort.UseVisualStyleBackColor = true;
            // 
            // lbl_Time1
            // 
            this.lbl_Time1.AutoSize = true;
            this.lbl_Time1.Location = new System.Drawing.Point(122, 163);
            this.lbl_Time1.Name = "lbl_Time1";
            this.lbl_Time1.Size = new System.Drawing.Size(21, 29);
            this.lbl_Time1.TabIndex = 6;
            this.lbl_Time1.Text = "-";
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(35, 163);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(81, 29);
            this.lbl_Time.TabIndex = 2;
            this.lbl_Time.Text = "Time: ";
            // 
            // btn_Sort
            // 
            this.btn_Sort.Location = new System.Drawing.Point(39, 209);
            this.btn_Sort.Name = "btn_Sort";
            this.btn_Sort.Size = new System.Drawing.Size(310, 63);
            this.btn_Sort.TabIndex = 1;
            this.btn_Sort.Text = "Sort Student Database";
            this.btn_Sort.UseVisualStyleBackColor = true;
            this.btn_Sort.Click += new System.EventHandler(this.btn_Sort_Click);
            // 
            // ddl_SortingOptions
            // 
            this.ddl_SortingOptions.FormattingEnabled = true;
            this.ddl_SortingOptions.Items.AddRange(new object[] {
            "First Name",
            "Last Name",
            "StudentID",
            "Gender",
            "Grade",
            "Age"});
            this.ddl_SortingOptions.Location = new System.Drawing.Point(39, 66);
            this.ddl_SortingOptions.Name = "ddl_SortingOptions";
            this.ddl_SortingOptions.Size = new System.Drawing.Size(363, 37);
            this.ddl_SortingOptions.TabIndex = 0;
            this.ddl_SortingOptions.Text = "Select Sorting Option...";
            // 
            // grp_Search
            // 
            this.grp_Search.Controls.Add(this.ddl_SearchingOptions);
            this.grp_Search.Controls.Add(this.lbl_Time3);
            this.grp_Search.Controls.Add(this.lbl_Time2);
            this.grp_Search.Controls.Add(this.btn_Search);
            this.grp_Search.Controls.Add(this.txt_SearchTangent);
            this.grp_Search.Location = new System.Drawing.Point(1065, 855);
            this.grp_Search.Name = "grp_Search";
            this.grp_Search.Size = new System.Drawing.Size(462, 309);
            this.grp_Search.TabIndex = 4;
            this.grp_Search.TabStop = false;
            this.grp_Search.Text = "Searching";
            // 
            // ddl_SearchingOptions
            // 
            this.ddl_SearchingOptions.FormattingEnabled = true;
            this.ddl_SearchingOptions.Items.AddRange(new object[] {
            "First Name",
            "Last Name",
            "StudentID",
            "Gender",
            "Grade",
            "Age"});
            this.ddl_SearchingOptions.Location = new System.Drawing.Point(39, 56);
            this.ddl_SearchingOptions.Name = "ddl_SearchingOptions";
            this.ddl_SearchingOptions.Size = new System.Drawing.Size(363, 37);
            this.ddl_SearchingOptions.TabIndex = 8;
            this.ddl_SearchingOptions.Text = "Select Searching Option...";
            // 
            // lbl_Time3
            // 
            this.lbl_Time3.AutoSize = true;
            this.lbl_Time3.Location = new System.Drawing.Point(122, 165);
            this.lbl_Time3.Name = "lbl_Time3";
            this.lbl_Time3.Size = new System.Drawing.Size(21, 29);
            this.lbl_Time3.TabIndex = 7;
            this.lbl_Time3.Text = "-";
            // 
            // lbl_Time2
            // 
            this.lbl_Time2.AutoSize = true;
            this.lbl_Time2.Location = new System.Drawing.Point(35, 165);
            this.lbl_Time2.Name = "lbl_Time2";
            this.lbl_Time2.Size = new System.Drawing.Size(81, 29);
            this.lbl_Time2.TabIndex = 7;
            this.lbl_Time2.Text = "Time: ";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(39, 207);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(310, 63);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Search Student Database";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_SearchTangent
            // 
            this.txt_SearchTangent.Location = new System.Drawing.Point(39, 110);
            this.txt_SearchTangent.Multiline = true;
            this.txt_SearchTangent.Name = "txt_SearchTangent";
            this.txt_SearchTangent.Size = new System.Drawing.Size(363, 41);
            this.txt_SearchTangent.TabIndex = 3;
            this.txt_SearchTangent.Text = "Enter search tangent...";
            // 
            // grp_Summary
            // 
            this.grp_Summary.Controls.Add(this.lbl_NumFemales1);
            this.grp_Summary.Controls.Add(this.lbl_NumFemales);
            this.grp_Summary.Controls.Add(this.lbl_NumMales1);
            this.grp_Summary.Controls.Add(this.lbl_NumMales);
            this.grp_Summary.Controls.Add(this.lbl_NumVoters1);
            this.grp_Summary.Controls.Add(this.lbl_NumVoters);
            this.grp_Summary.Location = new System.Drawing.Point(1610, 112);
            this.grp_Summary.Name = "grp_Summary";
            this.grp_Summary.Size = new System.Drawing.Size(462, 309);
            this.grp_Summary.TabIndex = 4;
            this.grp_Summary.TabStop = false;
            this.grp_Summary.Text = "Voting Summary";
            // 
            // lbl_NumFemales1
            // 
            this.lbl_NumFemales1.AutoSize = true;
            this.lbl_NumFemales1.Location = new System.Drawing.Point(265, 196);
            this.lbl_NumFemales1.Name = "lbl_NumFemales1";
            this.lbl_NumFemales1.Size = new System.Drawing.Size(21, 29);
            this.lbl_NumFemales1.TabIndex = 5;
            this.lbl_NumFemales1.Text = "-";
            // 
            // lbl_NumFemales
            // 
            this.lbl_NumFemales.AutoSize = true;
            this.lbl_NumFemales.Location = new System.Drawing.Point(38, 196);
            this.lbl_NumFemales.Name = "lbl_NumFemales";
            this.lbl_NumFemales.Size = new System.Drawing.Size(221, 29);
            this.lbl_NumFemales.TabIndex = 4;
            this.lbl_NumFemales.Text = "# of Female Voters:";
            // 
            // lbl_NumMales1
            // 
            this.lbl_NumMales1.AutoSize = true;
            this.lbl_NumMales1.Location = new System.Drawing.Point(236, 150);
            this.lbl_NumMales1.Name = "lbl_NumMales1";
            this.lbl_NumMales1.Size = new System.Drawing.Size(21, 29);
            this.lbl_NumMales1.TabIndex = 3;
            this.lbl_NumMales1.Text = "-";
            // 
            // lbl_NumMales
            // 
            this.lbl_NumMales.AutoSize = true;
            this.lbl_NumMales.Location = new System.Drawing.Point(38, 150);
            this.lbl_NumMales.Name = "lbl_NumMales";
            this.lbl_NumMales.Size = new System.Drawing.Size(192, 29);
            this.lbl_NumMales.TabIndex = 2;
            this.lbl_NumMales.Text = "# of Male Voters:";
            // 
            // lbl_NumVoters1
            // 
            this.lbl_NumVoters1.AutoSize = true;
            this.lbl_NumVoters1.Location = new System.Drawing.Point(177, 104);
            this.lbl_NumVoters1.Name = "lbl_NumVoters1";
            this.lbl_NumVoters1.Size = new System.Drawing.Size(21, 29);
            this.lbl_NumVoters1.TabIndex = 1;
            this.lbl_NumVoters1.Text = "-";
            // 
            // lbl_NumVoters
            // 
            this.lbl_NumVoters.AutoSize = true;
            this.lbl_NumVoters.Location = new System.Drawing.Point(38, 104);
            this.lbl_NumVoters.Name = "lbl_NumVoters";
            this.lbl_NumVoters.Size = new System.Drawing.Size(133, 29);
            this.lbl_NumVoters.TabIndex = 0;
            this.lbl_NumVoters.Text = "# of Voters:";
            // 
            // btn_Winner
            // 
            this.btn_Winner.Location = new System.Drawing.Point(1610, 483);
            this.btn_Winner.Name = "btn_Winner";
            this.btn_Winner.Size = new System.Drawing.Size(462, 681);
            this.btn_Winner.TabIndex = 10;
            this.btn_Winner.Text = "Determine Winner!";
            this.btn_Winner.UseVisualStyleBackColor = true;
            this.btn_Winner.Click += new System.EventHandler(this.btn_Winner_Click);
            // 
            // txt_StudentData
            // 
            this.txt_StudentData.Location = new System.Drawing.Point(65, 65);
            this.txt_StudentData.Multiline = true;
            this.txt_StudentData.Name = "txt_StudentData";
            this.txt_StudentData.ReadOnly = true;
            this.txt_StudentData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_StudentData.Size = new System.Drawing.Size(939, 1136);
            this.txt_StudentData.TabIndex = 12;
            this.txt_StudentData.Text = "Load Student Database...";
            // 
            // VoteProcessingMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2141, 1266);
            this.Controls.Add(this.txt_StudentData);
            this.Controls.Add(this.btn_Winner);
            this.Controls.Add(this.grp_Summary);
            this.Controls.Add(this.grp_Search);
            this.Controls.Add(this.grp_Sort);
            this.Controls.Add(this.btn_LoadStudentVotes);
            this.Controls.Add(this.btn_LoadStudentData);
            this.Name = "VoteProcessingMachine";
            this.Text = "Vote Processing Machine";
            this.grp_Sort.ResumeLayout(false);
            this.grp_Sort.PerformLayout();
            this.grp_Search.ResumeLayout(false);
            this.grp_Search.PerformLayout();
            this.grp_Summary.ResumeLayout(false);
            this.grp_Summary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_LoadStudentData;
        private System.Windows.Forms.Button btn_LoadStudentVotes;
        private System.Windows.Forms.GroupBox grp_Sort;
        private System.Windows.Forms.GroupBox grp_Search;
        private System.Windows.Forms.GroupBox grp_Summary;
        private System.Windows.Forms.Label lbl_NumFemales1;
        private System.Windows.Forms.Label lbl_NumFemales;
        private System.Windows.Forms.Label lbl_NumMales1;
        private System.Windows.Forms.Label lbl_NumMales;
        private System.Windows.Forms.Label lbl_NumVoters1;
        private System.Windows.Forms.Label lbl_NumVoters;
        private System.Windows.Forms.ComboBox ddl_SortingOptions;
        private System.Windows.Forms.Button btn_Sort;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_SearchTangent;
        private System.Windows.Forms.Button btn_Winner;
        private System.Windows.Forms.Label lbl_Time1;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_Time3;
        private System.Windows.Forms.Label lbl_Time2;
        private System.Windows.Forms.TextBox txt_StudentData;
        private System.Windows.Forms.CheckBox chk_QuickSort;
        private System.Windows.Forms.ComboBox ddl_SearchingOptions;
    }
}

