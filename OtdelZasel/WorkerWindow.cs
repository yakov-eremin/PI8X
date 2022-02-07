using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using Syncfusion.XlsIO;
using System.IO;

namespace OtdelZasel
{
    public partial class WorkerWindow : Form
    {
        long id_employee = 0;
        protected void setEmployeeName(long id_employee)
        {
            Connection.getInstance().connection.Open();
            //SQL команда
            var sql = "select \"Surname\", \"First_Name\", \"Last_Name\" from \"Employee\" where \"ID_Employee\" = :id_employee";
            var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
            cmd.Parameters.AddWithValue("id_employee", id_employee);
            var result = cmd.ExecuteReader();
            result.Read();
            label_EmployeeName.Text = "";
            label_EmployeeName.Text += result.GetValue(0).ToString().Trim() + " ";
            label_EmployeeName.Text += result.GetValue(1).ToString().Trim() + " ";
            label_EmployeeName.Text += result.GetValue(2).ToString().Trim() + " ";
            Connection.getInstance().connection.Close();
        }
        
        public WorkerWindow(long ID)
        {
            id_employee = ID;
            InitializeComponent();

            setEmployeeName(id_employee);
            dataGridView_Petitions.AllowUserToAddRows = false;
        }

        #region Обработка заявлений
        long id_petition = -1;

        protected void updateUnproccessedPetition()
        {
            richTextBox_textOfSelectedPetition.Clear();
            label_LeavingReason.Text = "";
            label_typeOfPetition.Text = "";
            try
            {
                //Обязательный коннект
                Connection.getInstance().connection.Open();
                //SQL команда
                var sql = @"select * from UnProcessedPetitions;";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                var dt = new System.Data.DataTable();
                dt.Load(cmd.ExecuteReader());
                
                Connection.getInstance().connection.Close();
                dataGridView_Petitions.DataSource = null;
                dataGridView_Petitions.DataSource = dt;

                positionOfText = dt.Columns.IndexOf("Текст");

                // скрою ID
                dataGridView_Petitions.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось загрузить необработанные заявления: " + ex.Message);
            }
        }

        private void WorkerWindow_Load(object sender, EventArgs e)
        {
            updateUnproccessedPetition();
        }


        private void tabPage_Petitions_Enter(object sender, EventArgs e)
        {
            updateUnproccessedPetition();
        }

        int positionOfText = 4;
        private void dataGridView_Petitions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = dataGridView_Petitions.CurrentCell.RowIndex;
            id_petition = long.Parse(dataGridView_Petitions.Rows[i].Cells[0].Value.ToString());
            loadTextOfPetitionAndContent(id_petition, dataGridView_Petitions.Rows[i].Cells[positionOfText].Value.ToString());
        }
        protected void loadTextOfPetitionAndContent(long petition_id, String text = "")
        {
            richTextBox_textOfSelectedPetition.Text = text;
            label_LeavingReason.Text = "";
            // произведу поиск типа заявления
            try
            {
                bool isCheckInPetition = true;
                Connection.getInstance().connection.Open();
                var sql = "select \"ID_CheckInPetition\", \"ScanPassport1\" from \"CheckInPetition\" where \"ID_Petition\" = :id_petition";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                cmd.Parameters.AddWithValue("id_petition", id_petition);
                var result = cmd.ExecuteReader();
                
                long id_leavingReason = 0;
                if (result.HasRows == false)
                {
                    Connection.getInstance().connection.Close();
                    Connection.getInstance().connection.Open();
                    sql = "select \"ID_CheckOutPetition\", \"ID_LeavingReason\" from \"CheckOutPetition\" where \"ID_Petition\" = :id_petition";

                    cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                    cmd.Parameters.AddWithValue("id_petition", id_petition);
                    result = cmd.ExecuteReader();
                    result.Read();
                    id_leavingReason = (long)result.GetValue(1);
                    
                    isCheckInPetition = false;
                }

                if (isCheckInPetition)
                {
                    label_Содержимое.Text = "Приложения";
                    label_typeOfPetition.Text = "Заявление на заселение";
                }
                else
                {
                    label_Содержимое.Text = "Причина выселения:";
                    label_typeOfPetition.Text = "Заявление на выселение";

                    Connection.getInstance().connection.Close();
                    Connection.getInstance().connection.Open();
                    sql = "select \"Text\" from \"LeavingReason\" where \"ID_LeavingReason\" = :id_leavingReason";
                    //Подключние команды
                    cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                    cmd.Parameters.AddWithValue("id_leavingReason", id_leavingReason);
                    result = cmd.ExecuteReader();
                    result.Read();
                    label_LeavingReason.Text = result.GetValue(0).ToString();
                }

                Connection.getInstance().connection.Close();
            }
            catch(Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось открыть заявление" + ex.Message);
            }
        }
        private void button_Accept_Click(object sender, EventArgs e)
        {
            proccessPetition(id_petition, true);
        }
        private void button_Reject_Click(object sender, EventArgs e)
        {
            proccessPetition(id_petition, false);
        }
        protected void proccessPetition(long id_petition, bool is_accepted)
        {
            richTextBox_textOfSelectedPetition.Clear();
            try
            {
                if( richTextBox_Message.Text.Length == 0)
                {
                    throw new Exception("Введен пустой ответ на заявление! ");
                }
                if (id_petition < 0)
                {
                    throw new Exception("Не выбрано заявление");
                }
                //Обязательный коннект
                Connection.getInstance().connection.Open();
                //SQL команда
                var sql = @"select * from createresultmessage(:id_employee, :id_petition, :is_accepted, :text)";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                cmd.Parameters.AddWithValue("text", richTextBox_Message.Text);
                cmd.Parameters.AddWithValue("id_employee", id_employee);
                cmd.Parameters.AddWithValue("id_petition", id_petition);
                cmd.Parameters.AddWithValue("is_accepted", is_accepted);

                var resultMessage = cmd.ExecuteScalar();

                Connection.getInstance().connection.Close();
                updateUnproccessedPetition();
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось обработать заявление: " + ex.Message);
            }
        }

        #endregion


        #region Выселение

        long checkOutReasonWithDept = 2;
        private void tabPage_ChechOut_Enter(object sender, EventArgs e)
        {
            Update_CheckOut_Petitions();

            Connection.getInstance().connection.Open();
            var sql = "select \"ID_LeavingReason\" from \"LeavingReason\" where (lower(\"Text\") LIKE '%неоплат%')";
            var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
            checkOutReasonWithDept = (long) cmd.ExecuteScalar();
            Connection.getInstance().connection.Close();
        }

        bool checkOutWithPetitions = true;
        private void radioButton_WithPetitions_CheckedChanged(object sender, EventArgs e)
        {
            checkOutWithPetitions = radioButton_WithPetitions.Checked;
            Update_CheckOut_Petitions();
        }
        
        private void Update_CheckOut_Petitions()
        {

            if(checkOutWithPetitions)
            {
                try
                {
                    //Обязательный коннект
                    Connection.getInstance().connection.Open();
                    //SQL команда
                    var sql = @"select * from UnProcessedCheckOutPetitions;";
                    //Подключние команды
                    var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                    var dt = new System.Data.DataTable();
                    dt.Load(cmd.ExecuteReader());

                    Connection.getInstance().connection.Close();
                    dataGridView_CitizensForCheckOut.DataSource = null;
                    dataGridView_CitizensForCheckOut.DataSource = dt;

                    // скрою ID
                    dataGridView_CitizensForCheckOut.Columns[0].Visible = false;
                    dataGridView_CitizensForCheckOut.Columns[1].Visible = false;
                }
                catch (Exception ex)
                {
                    Connection.getInstance().connection.Close();
                    MessageBox.Show("Не удалось загрузить заявления: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    //Обязательный коннект
                    Connection.getInstance().connection.Open();
                    //SQL команда
                    var sql = @"select * from debtors;";
                    //Подключние команды
                    var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                    var dt = new System.Data.DataTable();
                    dt.Load(cmd.ExecuteReader());

                    Connection.getInstance().connection.Close();
                    dataGridView_CitizensForCheckOut.DataSource = null;
                    dataGridView_CitizensForCheckOut.DataSource = dt;

                    // скрою ID
                    dataGridView_CitizensForCheckOut.Columns[0].Visible = false;
                    dataGridView_CitizensForCheckOut.Columns[1].Visible = false;
                }
                catch (Exception ex)
                {
                    Connection.getInstance().connection.Close();
                    MessageBox.Show("Не удалось загрузить список должников: " + ex.Message);
                }
            }
        }

        private long id_citizenForCheckOut = -1;
        private long id_leavingReasonForCheckOut = 2;
        private void dataGridView_CitizensForCheckOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = dataGridView_CitizensForCheckOut.CurrentCell.RowIndex;
            id_citizenForCheckOut = long.Parse(dataGridView_CitizensForCheckOut.Rows[i].Cells[0].Value.ToString());
            if (checkOutWithPetitions)
                id_leavingReasonForCheckOut = long.Parse(dataGridView_CitizensForCheckOut.Rows[i].Cells[1].Value.ToString());
            else
                id_leavingReasonForCheckOut = checkOutReasonWithDept;
        }

        private void button_CheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if(id_citizenForCheckOut < 0)
                {
                    throw new Exception("Выберите гражданина для выселения");
                }
                //Обязательный коннект
                Connection.getInstance().connection.Open();
                //SQL команда
                var sql = @"select * from checkoutcitizen(:id_citizen, :id_leaving_reason)";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);

                cmd.Parameters.AddWithValue("id_citizen", id_citizenForCheckOut);
                cmd.Parameters.AddWithValue("id_leaving_reason", id_leavingReasonForCheckOut);

                var resultMessage = cmd.ExecuteScalar();

                Connection.getInstance().connection.Close();
                Update_CheckOut_Petitions();
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось выселить: " + ex.Message);
            }
        }

        #endregion


        #region Заселение

        private void tabPage_CheckIn_Enter(object sender, EventArgs e)
        {
            Update_CheckInCitizen();

            Connection.getInstance().connection.Open();
            var sql = "select \"ID_LeavingReason\" from \"LeavingReason\" where (lower(\"Text\") LIKE '%неоплат%')";
            var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
            checkOutReasonWithDept = (long)cmd.ExecuteScalar();
            Connection.getInstance().connection.Close();
        }

        long id_freePlace = -1;
        long id_citizenForCheckIn = -1;

        private void dataGridView_FreePlaces_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = dataGridView_FreePlaces.CurrentCell.RowIndex;
            id_freePlace = long.Parse(dataGridView_FreePlaces.Rows[i].Cells[0].Value.ToString());
        }


        private void dataGridView_CitizensForCheckIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = dataGridView_CitizensForCheckIn.CurrentCell.RowIndex;
            id_citizenForCheckIn = long.Parse(dataGridView_CitizensForCheckIn.Rows[i].Cells[0].Value.ToString());
        }
        private void Update_CheckInCitizen()
        {
            try
            {
                Connection.getInstance().connection.Open();
                var sql = "select * from \"FreePlaces\";";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                var dt = new System.Data.DataTable();
                dt.Load(cmd.ExecuteReader());
                Connection.getInstance().connection.Close();
                dataGridView_FreePlaces.DataSource = null;
                dataGridView_FreePlaces.DataSource = dt;
                // скрою ID
                dataGridView_FreePlaces.Columns[0].Visible = false;
                dataGridView_FreePlaces.Columns[3].Width = 80;
                dataGridView_FreePlaces.Columns[4].Width = 80;
                dataGridView_FreePlaces.Columns[5].Width = 80;
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось загрузить свободные места: " + ex.Message);
            }

            
            try
            {
                Connection.getInstance().connection.Open();
                var sql = @"select * from unprocessedcheckinpetitions;";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                var dt = new System.Data.DataTable();
                dt.Load(cmd.ExecuteReader());
                Connection.getInstance().connection.Close();
                dataGridView_CitizensForCheckIn.DataSource = null;
                dataGridView_CitizensForCheckIn.DataSource = dt;
                // скрою ID
                dataGridView_CitizensForCheckIn.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось отобразить граждан для заселения: " + ex.Message);
            }
        }

        private void button_CheckInCitizen_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_citizenForCheckIn < 0)
                {
                    throw new Exception("Выберите гражданина для заселение");
                }
                if (id_freePlace < 0)
                {
                    throw new Exception("Выберите свободное место для заселение");
                }
                //Обязательный коннект
                Connection.getInstance().connection.Open();
                //SQL команда
                var sql = @"select * from checkincitizen(:id_employee, :id_citizen, :id_place)";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                cmd.Parameters.AddWithValue("id_employee", id_employee);
                cmd.Parameters.AddWithValue("id_citizen", id_citizenForCheckIn);
                cmd.Parameters.AddWithValue("id_place", id_freePlace);
                var resultMessage = cmd.ExecuteScalar();
                Connection.getInstance().connection.Close();
                Update_CheckInCitizen();
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось отобразить граждан для заселения: " + ex.Message);
            }
        }

        #endregion

        private void tabPage_AllLivingCitizens_Enter(object sender, EventArgs e)
        {
            try
            {
                //Обязательный коннект
                Connection.getInstance().connection.Open();
                //SQL команда
                var sql = @"select * from allLivingCitizens;";
                //Подключние команды
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                var dt = new System.Data.DataTable();
                dt.Load(cmd.ExecuteReader());
                Connection.getInstance().connection.Close();
                dataGridView_AllLivingCitizens.DataSource = null;
                dataGridView_AllLivingCitizens.DataSource = dt;
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось загрузить список проживающих граждан: " + ex.Message);
            }
        }

        private void button_SaveLivingCitizens_Click(object sender, EventArgs e)
        {
            saveFileDialog_LivingCitizens = new SaveFileDialog();
            saveFileDialog_LivingCitizens.Filter = "Excel|*.xls;*.xlsx;";

            if (saveFileDialog_LivingCitizens.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileName = saveFileDialog_LivingCitizens.FileName;

                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet worksheet = workbook.Worksheets[0];
                    //Adding text to a cell
                    for (int i = 1; i < dataGridView_AllLivingCitizens.Columns.Count + 1; i++)
                    {
                        worksheet.Range[1, i].Text = dataGridView_AllLivingCitizens.Columns[i - 1].HeaderText;
                    }
                    worksheet.Name = "Проживающие граждане";
                    for (int i = 0; i < dataGridView_AllLivingCitizens.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView_AllLivingCitizens.Columns.Count; j++)
                        {
                            worksheet.Range[i + 2, j + 1].Text = dataGridView_AllLivingCitizens.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    application.Save(fileName);
                }
            }
        }
    }
}

