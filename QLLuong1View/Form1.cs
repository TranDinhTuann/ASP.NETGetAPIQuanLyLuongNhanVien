using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace QLLuong1View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataViewGrid();
            LoadComBoBox();
        }

        public void LoadDataViewGrid()
        {
            string link = "http://localhost/test1/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            dataGridView1.DataSource = arr;
        }
        public void LoadComBoBox()
        {

            string link = "http://localhost/test1/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr1 = data as DonVi[];
            cbomadonvi.DataSource = arr1;
            cbomadonvi.ValueMember = "madonvi";
            cbomadonvi.DisplayMember = "tendonvi";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtmanv.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            txthoten.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            txtgioitinh.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            txthsluong.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            cbomadonvi.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            string poststring = string.Format("?manv={0}&hoten={1}&gioitinh={2}&hsluong={3}&madonvi={4}", txtmanv.Text, txthoten.Text, txtgioitinh.Text, txthsluong.Text, cbomadonvi.SelectedValue);
            string link = "http://localhost/test1/api/nhanvien" + poststring;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";

            byte[] byteArr = Encoding.UTF8.GetBytes(poststring);
            request.ContentLength = byteArr.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArr, 0, byteArr.Length);
            dataStream.Close();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            WebResponse response = request.GetResponse();
            object data = js.ReadObject(response.GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataViewGrid();
                MessageBox.Show("Them thanh cong");
            }
            else
            {
                MessageBox.Show("Them that bai");
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            string putstring = string.Format("?manv={0}&hoten={1}&gioitinh={2}&hsluong={3}&madonvi={4}", txtmanv.Text, txthoten.Text, txtgioitinh.Text, txthsluong.Text, cbomadonvi.SelectedValue);
            string link = "http://localhost/test1/api/nhanvien" + putstring;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json; charset=UTF-8";

            byte[] byteArr = Encoding.UTF8.GetBytes(putstring);
            request.ContentLength = byteArr.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArr,0, byteArr.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(response.GetResponseStream());
            bool kq = (bool)data;
            if(kq)
            {
                LoadDataViewGrid();
                MessageBox.Show("Sua thanh cong");
            }
            else
            {
                MessageBox.Show("Sua that bai");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string deleteString = string.Format("?manv={0}", txtmanv.Text);
            string link = "http://localhost/test1/api/nhanvien" + deleteString;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "DELETE";
            request.ContentType = "application/json; charset=UTF-8";

            byte[] byteArr = Encoding.UTF8.GetBytes(deleteString);
            request.ContentLength = byteArr.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArr, 0, byteArr.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(response.GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataViewGrid();
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
        }

        // lay theo gioi tinh
        private void button4_Click(object sender, EventArgs e)
        {
            string gioitinh = txtgioitinh.Text;
            string link = "http://localhost/test1/api/nhanvien?gioitinh=" + gioitinh;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            dataGridView1.DataSource = arr;
        }

        private void btnLayTheoDV_Click(object sender, EventArgs e)
        {
            string madonvi = cbomadonvi.Text;
            string link = "http://localhost/test1/api/nhanvien?madonvi=" + madonvi;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            dataGridView1.DataSource = arr;
        }

        private void btnLayTheoLuong_Click(object sender, EventArgs e)
        {
            string link = "http://localhost/test1/api/nhanvien?minhsluong=1&maxhsluong=3000000";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            dataGridView1.DataSource = arr;
        }
    }
}
