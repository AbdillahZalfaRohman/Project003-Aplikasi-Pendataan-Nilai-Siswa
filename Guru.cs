﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belajar_Crud
{
    public partial class Guru : Form
    {
        public MySqlCommand cmd;
        public MySqlDataReader dr;
        public String id;
        public Guru()
        {
            InitializeComponent();
        }
        private void Tampil()
        {
            try
            {

                Koneksi.conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `guru`", Koneksi.conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dgsiswa.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }

        private void Guru_Load(object sender, EventArgs e)
        {
            Tampil();
            btDelete.Enabled = false;
            btUpdate.Enabled = false;
            btCancel.Enabled = false;
        }

        private void Clear()
        {
            txtnama.Text = "";
            txtnip.Text = "";

            btDelete.Enabled = false;
            btUpdate.Enabled = false;
            btCancel.Enabled = false;
            btInsert.Enabled = true;
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            
        }

        private void dgsiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
           
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btInsert_Click_1(object sender, EventArgs e)
        {
            if ((txtnama.Text == string.Empty) || (txtnip.Text == string.Empty))
            {
                MessageBox.Show("Input Data Terlebih Dahulu ");
            }
            else
            {
                try
                {
                    Koneksi.conn.Open();
                    //String Queri = "INSERT INTO guru (Nama, NIP) VALUES ('" + txtnama.Text + "', '" + txtnip.Text + "')";
                    cmd = new MySqlCommand("INSERT INTO guru (nama, nip) VALUES (@nama,@nip)", Koneksi.conn);
                    cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                    cmd.Parameters.AddWithValue("@nip", txtnip.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Simpan Data Guru");
                    Koneksi.conn.Close();

                    Tampil();
                    Clear();
                }
                catch (Exception)
                {

                    MessageBox.Show("Tambah Data Gagal");
                }
            }
        }

        private void btCancel_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtcari_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                Koneksi.conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `guru` where nama LIKE '%" + txtcari.Text + "%'", Koneksi.conn);
                DataSet ds = new DataSet();

                da.Fill(ds);
                dgsiswa.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM guru WHERE  `id`= '" + id + "'", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Hapus Data Guru");
                Koneksi.conn.Close();

                Tampil();
                Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Hapus Data Gagal");
            }
        }

        private void btUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                String Queri = "UPDATE guru SET `nama`='" + txtnama.Text + "', `nip`='" + txtnip.Text + "' WHERE  `id`='" + id + "'";
                cmd = new MySqlCommand(Queri, Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Update Data Guru");
                Koneksi.conn.Close();

                Tampil();
                Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Update Gagal");
            }
        }

        private void dgsiswa_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btDelete.Enabled = true;
            btUpdate.Enabled = true;
            btCancel.Enabled = true;
            btInsert.Enabled = false;

            int baris = dgsiswa.CurrentCell.RowIndex;
            id = dgsiswa.Rows[baris].Cells[0].Value.ToString();
            txtnama.Text = dgsiswa.Rows[baris].Cells[1].Value.ToString();
            txtnip.Text = dgsiswa.Rows[baris].Cells[2].Value.ToString();
        }
    }
}
