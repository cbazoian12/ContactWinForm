///<author>Christian Bazoian</author>
/// <date>March 4, 2016</date>

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ContactRecordForm
{
    /// <summary>
    /// This is a program that uses a WinForm to communicate with a flat file. The flat file contains a collection of names
    /// and mailing addresses. The form can be used to search, add, and delete records using the flat file.
    /// </summary>
    public partial class RecordDateGridView : Form
    {
        public RecordDateGridView()
        {
            InitializeComponent();
            DataGridViewSetup();
        }

        /// <summary>
        /// Sets up the Data Grid View to display the current list of contacts.
        /// </summary>
        private void DataGridViewSetup()
        {
            FileSetUp("contacts.txt");
        }

        /// <summary>
        /// The listener that responds to any cells that are clicked.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void RecordDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RecordDataGridView.CurrentCell != null && RecordDataGridView.CurrentCell.Value != null) //if cell and contentents are not null
            {
                InputTextBox.Text = GetDataGridRow();
            }
            else
            {
                InputTextBox.Text = "No Selection";
            }
        }

        /// <summary>
        /// Listener for any changes to the input text box.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            //Do nothing
        }

        /// <summary>
        /// Listener for the search button. When clicked, the contact flat file will be searched for whatever text is in the input text box.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string input = InputTextBox.Text; //get input

            string record = FormatRecord(input); //format input

            File.Delete("search.txt"); //delete search file if it already exists

            string line = null;

            System.IO.StreamReader file = new System.IO.StreamReader("contacts.txt");
            
            //add column headers to new file that will contains searches
            StreamWriter w = File.AppendText("search.txt");
            w.WriteLine("Name HouseNumber Street City State Zip");
            w.Close();

            while((line = file.ReadLine()) != null)
            {
                if(line.Contains(record))
                {
                    using (StreamWriter sw = File.AppendText("search.txt"))
                    {
                        sw.WriteLine(line); //write the line of text from text box
                    }
                }
            }

            FileSetUp("search.txt"); //use the new file to set up the Data Grid View
        }

        /// <summary>
        /// Listener for the add button. Record in the text box will be added to the flat file.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            string input = InputTextBox.Text; //get input

            string record = FormatRecord(input); //format input

            if (!ContactFileContains(input)) //if the contact doesn't already exist
            {
                var count = input.Count(x => x == ','); //find the number of commas in input

                if(count == 5) //if there are at least five commas, it can be a valid record.
                {
                    using (StreamWriter w = File.AppendText("contacts.txt")) //appbend text to contact list.
                    {
                        w.WriteLine(record); //write the line of text from text box
                        w.Flush();
                    }
                }
                else
                {
                    InputTextBox.Text = "Invalid Format";
                }
            }
            else
            {
                InputTextBox.Text = "Record already exists";
            }

            InputTextBox.Text = "";
            RefreshButton_Click(null, null); //refresh the data grid
        }

        /// <summary>
        /// Delete button listener. Deletes the file specified in the text box if it indeed exists.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != "" && InputTextBox.Text != null) //make sure text box is not empty
            {
                string input = InputTextBox.Text; //get input
                string record = FormatRecord(input); //format input

                string line = null;

                using (StreamReader reader = new StreamReader("contacts.txt")) //read in contacts file
                {
                    using (StreamWriter writer = new StreamWriter("tempFile.txt")) //create a temp file to write to
                    {
                        while ((line = reader.ReadLine()) != null) //read in all lines in contacts file
                        {
                            if (line.Equals(record)) //if reading in a line that equals the line to delete
                            {
                                continue; //skip over it
                            }
                            writer.WriteLine(line); //write all lines to temp file 
                        }
                    }
                }

                File.Delete("contacts.txt"); //delete contacts file so it can be re-made

                using (StreamReader reader = new StreamReader("tempFile.txt")) //open the temp file
                {
                    using (StreamWriter writer = new StreamWriter("contacts.txt")) //create a new contacts file to write to
                    {
                        while ((line = reader.ReadLine()) != null) //while there are still lines left
                        {
                            writer.WriteLine(line); //write line
                        }
                    }
                }
                File.Delete("tempFile.txt"); // delete the temp file
                RefreshButton_Click(null, null); //refresh the data grid 
                InputTextBox.Text = ""; //clear textbox
            }
            else
            {
                InputTextBox.Text = "No Selection";
            }
        }

        /// <summary>
        /// Listener for the Refresh button. Refreshes the data grid view to display most current flat file contents.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RecordDataGridView.DataSource = null; //nullify the dataSource
            RecordDataGridView.Rows.Clear(); //clear the rows
            DataGridViewSetup();  //publish update contents to dataGridView
        }

        /// <summary>
        /// Listener for the close button. Closes the WinForm.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Gets the contents of the currently selected row on the data grid view.
        /// </summary>
        /// <returns>A comma delimeted string representation of the currently selected row.</returns>
        private string GetDataGridRow()
        {
            //get the contents of each cell of currently selected row and return it compiled together as a string.
            string name = RecordDataGridView.CurrentRow.Cells[0].Value.ToString();
            string houseNumber = RecordDataGridView.CurrentRow.Cells[1].Value.ToString();
            string street = RecordDataGridView.CurrentRow.Cells[2].Value.ToString();
            string city = RecordDataGridView.CurrentRow.Cells[3].Value.ToString();
            string state = RecordDataGridView.CurrentRow.Cells[4].Value.ToString();
            string zip = RecordDataGridView.CurrentRow.Cells[5].Value.ToString();
            string text = name + "," + houseNumber + "," + street + "," + city + "," + state + "," + zip;
            return text;
        }

        /// <summary>
        /// Searches the contact flat file for any possible instance of the text in the intput text box.
        /// </summary>
        /// <param name="contact">The text to search for.</param>
        /// <returns>A boolean value.</returns>
        private bool ContactFileContains(string contact)
        {
            using (StreamReader reader = new StreamReader("contacts.txt")) //read in contacts file
            {
                string line = null;
                while ((line = reader.ReadLine()) != null) //read in all lines in contacts file
                {
                    if (line.Equals(contact)) //if reading in a line that equals the line to delete
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// A listener for the instruction label. Does nothing.
        /// </summary>
        /// <param name="sender">Provides access to the sender object.</param>
        /// <param name="e">Provides access to the DataGridView event.</param>
        private void FormatLabelInstructions_Click(object sender, EventArgs e)
        {
            //Do nothing.
        }

        /// <summary>
        /// Sets up the file with the data grid view.
        /// </summary>
        /// <param name="file">Path to the file.</param>
        private void FileSetUp(string file)
        {
            RecordDataGridView.DataSource = null;
            //When initialized, automatically bring up the current contact list
            System.IO.StreamReader dataFile = new System.IO.StreamReader(file); //open flat file
            string[] columnnames = dataFile.ReadLine().Split(' '); //split each line by spaces
            DataTable dt = new DataTable(); //create a new data table to hold the information in.

            foreach (string column in columnnames) //get each column name
            {
                dt.Columns.Add(column); //add column name to data file
            }

            string newLine; //Create a new string to hold each row of information in txt file

            while ((newLine = dataFile.ReadLine()) != null) //while the file still has text in it
            {
                DataRow dr = dt.NewRow(); //create a new row in the data table
                string[] values = newLine.Split(','); //split each entry in the flat file by spaces

                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i]; //enter each value from flat file into a data row
                }

                dt.Rows.Add(dr); //add the new data row into the data table
            }

            dataFile.Close();
            RecordDataGridView.DataSource = dt; //set the data source for the data grid view as the data table just created.
        }

        /// <summary>
        /// Formats a string to a format that the flat file is written in.
        /// </summary>
        /// <param name="record">The string to format.</param>
        /// <returns></returns>
        string FormatRecord(string record)
        {
            record.Replace(", ", ","); //remove any spaces after commas
            record.Replace(" ,", ","); //remove any spaces before commas
            record.Trim(); //remove any white space before or after the record
            return record;
        }
        
    }
}
