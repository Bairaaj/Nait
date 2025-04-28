//****************************************************************************************************************************
//Program:          LAB04_AdrianB
//Description:      DupFinder
//Date:             Dec, 13, 2023
//Author:           Adrian Baira
//Course:           CMPE1666
//Class:            CNTA01
//****************************************************************************************************************************
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
using System.Security.Cryptography;
using System.Reflection;
using System.Security.Policy;

namespace Lab04_AdrianBaira
{
    public partial class Form1 : Form
    {
        private MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider(); // hashing 
        List<FileInfo> subfolder; // to check subfolder and same the values in the subfolder in the list
        List<SMD5File> filenameswithas = new List<SMD5File>(); // to save the file for the hash and the path
        //struct to format and also save values
        private struct SMD5File
        {
            public string sPath; // file path
            public string sMD5; // hashes
            public SMD5File(string SPath, string SMD5) //constructor to save
            {
                sPath = SPath; // allow add into the stuct
                sMD5 = SMD5; // allow add into the struct
            }
            public override string ToString()
            {
                return $"{sMD5} : {sPath}"; // to format the string into the value
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            crypto.Initialize();
        }
        //**********************************************************************************************
        //Method:           private void UI_LBL_DROPFILES_DragDrop(object sender, DragEventArgs e)                          
        //Purpose:          to drop files and allow them to be hashsed
        //Returns:          a list with hashes and the file path
        //*********************************************************************************************
        private void UI_LBL_DROPFILES_DragDrop(object sender, DragEventArgs e)
        {
            List<string> files = new List<string>((string[])e.Data.GetData(DataFormats.FileDrop)); // to get data from the file drop
            foreach (string filepath in files)
            {
                if (File.GetAttributes(filepath).HasFlag(FileAttributes.Directory)) //to get the dierctory of the file
                {
                    DirectoryInfo di = new DirectoryInfo(filepath); // to save the path of the file
                    subfolder = di.EnumerateFiles("*.*", SearchOption.AllDirectories).ToList(); // and add to the list
                    foreach (FileInfo fileinfo in subfolder) // it will check each file in the subfolder
                    {
                        byte[] hash = crypto.ComputeHash(File.ReadAllBytes(fileinfo.FullName)); // it will hash the file 
                        filenameswithas.Add(new SMD5File($"{fileinfo.FullName}", BitConverter.ToString(hash))); //add it to the list
                    }
                }
                else
                {
                    byte[] hashs = crypto.ComputeHash(File.ReadAllBytes(filepath)); // if a single file is selected it will still add it into the list
                    filenameswithas.Add(new SMD5File($"{filepath}", BitConverter.ToString(hashs))); // to add it into the list
                }
            }
            Addtolistbox(filenameswithas);
        }
        //**********************************************************************************************
        //Method:           private void Addtolistbox()                           
        //Purpose:          to add the file into the list box
        //Returns:          listbox items
        //*********************************************************************************************
        private void Addtolistbox(List<SMD5File> listbox)
        {
            UI_LISTBOX.Items.Clear(); // to clear the items in listbox
            filenameswithas = filenameswithas.OrderBy(x => x.sMD5).ToList(); // orders the hashes by hex number
            foreach (SMD5File file in listbox)
            {
                UI_LISTBOX.Items.Add(file); // adds it into the listbox
            }
        }
        //**********************************************************************************************
        //Method:           private void UI_LBL_DROPFILES_DragEnter(object sender, DragEventArgs e)                       
        //Purpose:          to get the file drop
        //Returns:          file
        //*********************************************************************************************
        private void UI_LBL_DROPFILES_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_FINDDUPLICATES_Click(object sender, EventArgs e)                        
        //Purpose:          to show the user that there are duplicates
        //Returns:          duplicate files
        //*********************************************************************************************
        private void UI_BTN_FINDDUPLICATES_Click(object sender, EventArgs e)
        {
            UI_LISTBOX.Items.Clear(); // clears the items in the list box 
                                      // to add the duplicates in the list box
            List<SMD5File> duplicates = duplicatess();
            Addtolistbox(duplicates); // to display into the listbox
        }
        //**********************************************************************************************
        //Method:           private List<SMD5File> duplicatess()                   
        //Purpose:          To find duplicates
        //Returns:          List<SMD5File>
        //*********************************************************************************************
        private List<SMD5File> duplicatess()
        {
            var duplicatesg = filenameswithas.GroupBy(y => y.sMD5).Where(x => x.Count() > 1);
            List<SMD5File> duplicates = duplicatesg.SelectMany(x => x).ToList();
            return duplicates;

        }
        //**********************************************************************************************
        //Method:           private void UI_BTN_RESOLVEDUPLICATES_Click(object sender, EventArgs e)                            
        //Purpose:          To resolve the duplicates and show them in a file
        //Returns:          A file to show the user which duplcates are the same or not
        //*********************************************************************************************
        private void UI_BTN_RESOLVEDUPLICATES_Click(object sender, EventArgs e)
        {
            if(UI_LISTBOX.SelectedItem == null) // to check if the selected items
            {
                return; // if user did not select anythign just return and do nothing 
            }
            SMD5File selected = (SMD5File)UI_LISTBOX.SelectedItem; // if they do select something save it the value from the list that they selected
            
            string comarisions = "Checking file contents:\n"; // format

            foreach (SMD5File otherFile in filenameswithas)
            {
                if(otherFile.sMD5 == selected.sMD5 && otherFile.sPath != selected.sPath)
                {
                    bool contentsEqual = CompareHashes(selected.sPath, otherFile.sPath); // it will get the method to compare hashes
                    if (contentsEqual)
                    {
                        comarisions += $"{selected.sPath} is the same file as {otherFile.sPath}\n"; // add into the string for txt 
                    }
                    else
                    {
                        comarisions += $"{selected.sPath} is different from {otherFile.sPath}\n"; // add to the string
                    }
                }
                
            }
            File.WriteAllText("FileCompResults.txt", comarisions);
            System.Diagnostics.Process.Start("notepad.exe", "FileCompResults.txt");
        }
        //**********************************************************************************************
        //Method:           private bool CompareHashes(string hash1, string hash2)                            
        //Purpose:          to read the bytes from the file path given to it
        //Returns:          returns a true or false statement
        //*********************************************************************************************
        private bool CompareHashes(string hash1, string hash2)
        {
            byte[] file1 = File.ReadAllBytes(hash1);
            byte[] file2 = File.ReadAllBytes(hash2);

            return file1.SequenceEqual(file2);
        }
    }
}
