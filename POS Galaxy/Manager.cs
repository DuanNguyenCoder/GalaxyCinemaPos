using POS_Galaxy.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Windows.Forms;
using POS_Galaxy.DTO;

namespace POS_Galaxy
{
    public partial class Manager : Form
    {
        POS_galaxyDataSetTableAdapters.FilmTableAdapter film = new POS_galaxyDataSetTableAdapters.FilmTableAdapter();
        POS_galaxyDataSetTableAdapters.ShowTimeTableAdapter showtime = new POS_galaxyDataSetTableAdapters.ShowTimeTableAdapter();
        POS_galaxyDataSetTableAdapters.EmployeeTableAdapter employ = new POS_galaxyDataSetTableAdapters.EmployeeTableAdapter();

        
       
        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.pOS_galaxyDataSet.Employee);
            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.pOS_galaxyDataSet.Customer);
            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.pOS_galaxyDataSet.Invoice);
            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.ShowTime' table. You can move, or remove it, as needed.
            this.showTimeTableAdapter.Fill(this.pOS_galaxyDataSet.ShowTime);
           // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Film' table. You can move, or remove it, as needed.
            this.filmTableAdapter.Fill(this.pOS_galaxyDataSet.Film);
           


            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.pOS_galaxyDataSet.Company);
            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Catory' table. You can move, or remove it, as needed.
            this.catoryTableAdapter.Fill(this.pOS_galaxyDataSet.Catory);
            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.pOS_galaxyDataSet.Product);
            // TODO: This line of code loads data into the 'pOS_galaxyDataSet.Employee' table. You can move, or remove it, as needed.

            for (int i = 0; i < guna2DataGridView1.Columns.Count; i++)
                if (guna2DataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)guna2DataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            LoadDataFilm();
            LoadDataShowing();
            LoadDatanv();

        }

        private void LoadDataFilm()
        {
            filmname.DataBindings.Add(new Binding("Text", guna2DataGridView2.DataSource, "name"));
            idFilm.DataBindings.Add(new Binding("Text", guna2DataGridView2.DataSource, "FilmID"));
            typeFilm.DataBindings.Add(new Binding("Text", guna2DataGridView2.DataSource, "TypeFilm"));
            age.DataBindings.Add(new Binding("Text", guna2DataGridView2.DataSource, "AgeLimited"));
            ThoiGian.DataBindings.Add(new Binding("Text", guna2DataGridView2.DataSource, "time"));

        }
        private void LoadDatanv()
        {
            nv_id.DataBindings.Add(new Binding("Text", guna2DataGridView5.DataSource, "EmployeeID"));
            nv_name.DataBindings.Add(new Binding("Text", guna2DataGridView5.DataSource, "Name"));
            nv_diachi.DataBindings.Add(new Binding("Text", guna2DataGridView5.DataSource, "Address"));
            nv_sdt.DataBindings.Add(new Binding("Text", guna2DataGridView5.DataSource, "Phone"));
            nv_nam.Checked = true;

        }

        private void LoadDataShowing()
        {
            day.Value = int.Parse(DateTime.Today.ToString("dd"));
            month.Value = int.Parse(DateTime.Today.ToString("MM"));
            year.Value = int.Parse(DateTime.Today.ToString("yyyy"));
            ngayCongchieu.Text = DateTime.Today.ToString("dd/MM/yyyy");
            guna2ComboBox1.Text = "RAP 1";
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            day.Value = int.Parse(monthCalendar1.SelectionStart.ToString("dd"));
            month.Value = int.Parse(monthCalendar1.SelectionStart.ToString("MM"));
            year.Value = int.Parse(monthCalendar1.SelectionStart.ToString("yyyy"));
            ngayCongchieu.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
        }
        private void hour_ValueChanged(object sender, EventArgs e)
        {
            string[] time = guna2DataGridView3.CurrentRow.Cells[3].Value.ToString().Split(':');
            int f_hour = int.Parse(time[0]) ;
            int f_minutes = int.Parse(time[1]);
            int f_second = int.Parse(time[2]);
            // kiem tra neu thoi gian ket thuc suat lon hon 60 thi cap nhat ai gio va phut 
            //if (int.Parse(time[1]) + (int)minutes.Value > 60)
            //{

            //}
            /// thoi gian bat dau suat + thoi luong phim
            string s_Hour = hour.Value.ToString();
            string s_Minutes = minutes.Value.ToString();
            if (hour.Value < 10)
            {
                s_Hour = "0" + hour.Value;
            }
            if (minutes.Value < 10)
            {
               s_Minutes = "0" + minutes.Value;
            }
         
            starshow.Text = $"{s_Hour}:{s_Minutes}:{second.Value}0";



            // tinh thoi gian ket thuc
            TimeSpan time1 = new TimeSpan( (int)hour.Value,(int) minutes.Value, (int)second.Value);
            TimeSpan time2 = new TimeSpan(f_hour, f_minutes, f_second);

            var result = time1 + time2;
            if (result.ToString().Contains('.'))
            {
                string[] split = result.ToString().Split('.');
               endshow.Text = split[1].ToString();
            }
            else
            {
                endshow.Text = result.ToString();

            }
           
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
        
        }
        Image byteToImage(byte[] b)
        {
            MemoryStream a = new MemoryStream(b);
            return Image.FromStream(a);
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            //byte[] images = null;
            //try
            //{
            //    FileStream stream = new FileStream(guna2PictureBox1.ImageLocation, FileMode.Open, FileAccess.Read);
            //    BinaryReader brs = new BinaryReader(stream);
            //    images = brs.ReadBytes((int)stream.Length);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("chưa chọn đường dẫn hình!", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            int a = ProductsDAO.Instance.addNewProduct(txtName.Text,cbbUnit.Text,double.Parse( txtPrice.Text),(int)txtQuantity.Value,(int)cbbCompany.SelectedValue,(int)cbbCatory.SelectedValue,ImageToByte(guna2PictureBox1));
            if (a > 0) { MessageBox.Show("success"); this.productTableAdapter.Fill(this.pOS_galaxyDataSet.Product); }
            else { MessageBox.Show("fail"); }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All Files(*.*) | *.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    guna2PictureBox1.ImageLocation = imagelocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(guna2DataGridView1.CurrentRow.Cells[7].Value!= System.DBNull.Value)
            {
            byte[] b = (byte[])guna2DataGridView1.CurrentRow.Cells[7].Value;
            guna2PictureBox1.Image = byteToImage(b);
            }
            txtID.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbbUnit.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = String.Format("{0:0,0}", (decimal)guna2DataGridView1.CurrentRow.Cells[3].Value);
            txtQuantity.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbbCompany.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbbCatory.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

    private Byte[] ImageToByte( Guna2PictureBox picturebox)
        {
            byte[] images = null;

            try {
                FileStream stream = new FileStream(picturebox.ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);
            }

             catch (Exception)
            {
                MessageBox.Show("chưa chọn đường dẫn hình!", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return images;
         
        }
        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            //byte[] images = null;
            //try
            //{
            //    FileStream stream = new FileStream(guna2PictureBox1.ImageLocation, FileMode.Open, FileAccess.Read);
            //    BinaryReader brs = new BinaryReader(stream);
            //    images = brs.ReadBytes((int)stream.Length);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("chưa chọn đường dẫn hình!", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            int a = ProductsDAO.Instance.updateProduct(txtName.Text, cbbUnit.Text, double.Parse(txtPrice.Text), (int)txtQuantity.Value, (int)cbbCompany.SelectedValue, (int)cbbCatory.SelectedValue, ImageToByte(guna2PictureBox1),int.Parse( txtID.Text));
            if (a > 0) { MessageBox.Show("success"); this.productTableAdapter.Fill(this.pOS_galaxyDataSet.Product); }
            else { MessageBox.Show("fail"); }
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            int a = ProductsDAO.Instance.deleteProduct(int.Parse(txtID.Text));
            if (a > 0) { MessageBox.Show("success"); this.productTableAdapter.Fill(this.pOS_galaxyDataSet.Product); }
            else { MessageBox.Show("fail"); }
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cbbCatory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            this.productTableAdapter.FillByCatory(this.pOS_galaxyDataSet.Product, (int)cbbCatory.SelectedValue);
            }
            catch (Exception)
            {
            }
        }

        // add new film
        private void guna2TileButton8_Click(object sender, EventArgs e)
        {
            film.InsertQuery(null,filmname.Text,typeFilm.Text,ThoiGian.Text,(int)age.Value,ImageToByte(guna2PictureBox2));
            this.filmTableAdapter.Fill(this.pOS_galaxyDataSet.Film);
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                  
                if ( guna2DataGridView2.CurrentRow.Cells[1].Value.ToString() == "HaunTing" )
                {
                    axWindowsMediaPlayer1.Show();
                axWindowsMediaPlayer1.URL = @"C:\Users\duann\OneDrive\Tài liệu\Bandicam\bandicam 2022-07-02 01-34-28-664.mp4";

                }
                if (guna2DataGridView2.CurrentRow.Cells[2].Value.ToString() == "Avenger")
                {
                    axWindowsMediaPlayer1.Show();
                    axWindowsMediaPlayer1.URL = @"C:\Users\duann\OneDrive\Tài liệu\Bandicam\bandicam 2022-07-02 01-31-54-941.mp4";

                }
                if (guna2DataGridView2.CurrentRow.Cells[2].Value.ToString() == "Mắt biếc")
                {
                    axWindowsMediaPlayer1.Show();
                    axWindowsMediaPlayer1.URL = @"C:\Users\duann\OneDrive\Tài liệu\Bandicam\bandicam 2022-07-02 01-47-51-707.mp4";

                }
                if (guna2DataGridView2.CurrentRow.Cells[2].Value.ToString() == "Sát thủ")
                {
                    axWindowsMediaPlayer1.Show();
                    axWindowsMediaPlayer1.URL = @"C:\Users\duann\OneDrive\Tài liệu\Bandicam\bandicam 2022-07-02 01-34-28-664.mp4";

                }
                if (guna2DataGridView2.CurrentRow.Cells[2].Value.ToString() == "Ròm")
                {
                    axWindowsMediaPlayer1.Show();
                    axWindowsMediaPlayer1.URL = @"C:\Users\duann\OneDrive\Tài liệu\Bandicam\bandicam 2022-07-02 01-50-19-442.mp4";

                }
                if (guna2DataGridView2.CurrentRow.Cells[2].Value.ToString() == "Thái cực quyền")
                {
                    axWindowsMediaPlayer1.Show();
                    axWindowsMediaPlayer1.URL = @"C:\Users\duann\OneDrive\Tài liệu\Bandicam\bandicam 2022-07-02 01-34-28-664.mp4";

                }
                else
                {
                    axWindowsMediaPlayer1.Show();
                    axWindowsMediaPlayer1.URL = @"C:\Users\duann\OneDrive\Tài liệu\Bandicam\bandicam 2022-07-02 01-34-28-664.mp4";

                }
            }
            if (guna2DataGridView2.CurrentRow.Cells[7].Value != System.DBNull.Value)
            {
                byte[] b = (byte[])guna2DataGridView2.CurrentRow.Cells[7].Value;
                guna2PictureBox2.Image = byteToImage(b);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*) | *.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    guna2PictureBox2.ImageLocation = imagelocation;
                  
                   
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    movie.Text = imagelocation;


                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }

        }

        private void guna2TileButton7_Click(object sender, EventArgs e)
        {
            film.UpdateQuery(null, filmname.Text, typeFilm.Text, ThoiGian.Text, (int)age.Value, ImageToByte(guna2PictureBox2),int.Parse( idFilm.Text));
            this.filmTableAdapter.Fill(this.pOS_galaxyDataSet.Film);
        }

        private void guna2TileButton6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton12_Click(object sender, EventArgs e)
        {
            int idFilm = int.Parse(guna2DataGridView3.CurrentRow.Cells[0].Value.ToString());
            string[] splitNgay = ngayCongchieu.Text.Split('/');
            string[] splitStar = starshow.Text.Split(':');
            string[] splitEnd = endshow.Text.Split(':');
            DateTime _starshow = new DateTime(int.Parse( splitNgay[2]), int.Parse(splitNgay[1]), int.Parse(splitNgay[0]), int.Parse(splitStar[0]), int.Parse(splitStar[1]), int.Parse(splitStar[2]));
            DateTime _endshow = new DateTime(int.Parse(splitNgay[2]), int.Parse(splitNgay[1]), int.Parse(splitNgay[0]), int.Parse(splitEnd[0]), int.Parse(splitEnd[1]), int.Parse(splitEnd[2]));
            showtime.InsertQuery(idFilm,_starshow,_endshow,guna2ComboBox1.Text);

            this.showTimeTableAdapter.Fill(this.pOS_galaxyDataSet.ShowTime);
            MessageBox.Show("success");
        }

        private void day_ValueChanged(object sender, EventArgs e)
        {
            string date = day.Value.ToString() + "/" + month.Value.ToString()+ "/" + year.Value;
            ngayCongchieu.Text = date;
        }

        private void guna2TileButton10_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView5.CurrentRow.Cells[6].Value != System.DBNull.Value)
            {
                byte[] b = (byte[])guna2DataGridView5.CurrentRow.Cells[6].Value;
                nv_image.Image = byteToImage(b);
            }
        }
        /// them employee
        private void guna2TileButton16_Click(object sender, EventArgs e)
        {
         //   employ.InsertQuery()
        }
    }
}
