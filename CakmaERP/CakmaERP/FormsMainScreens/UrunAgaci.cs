﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CakmaERP.FormsMainScreens
{
    public partial class UrunAgaci : Form
    {
        public UrunAgaci()
        {
            InitializeComponent();

            //LoadData();
        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM UrunAgaci");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text) && !string.IsNullOrEmpty(txtMalzemeTipi.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "firma_kodu", txtFirmaKodu.Text },
                    { "malzeme_tipi", txtMalzemeTipi.Text }
                };

                CRUD.Create("UrunAgaci", data);
                MessageBox.Show("Veri başarıyla eklendi.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text) && !string.IsNullOrEmpty(txtMalzemeTipi.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "malzeme_tipi", txtMalzemeTipi.Text }
                };

                string condition = $"firma_kodu = '{txtFirmaKodu.Text}'";
                CRUD.Update("UrunAgaci", data, condition);
                MessageBox.Show("Veri başarıyla güncellendi.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text))
            {
                string condition = $"firma_kodu = '{txtFirmaKodu.Text}'";
                CRUD.Delete("UrunAgaci", condition);
                MessageBox.Show("Veri başarıyla silindi.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtFirmaKodu.Text = row.Cells["firma_kodu"].Value.ToString();
                txtMalzemeTipi.Text = row.Cells["malzeme_tipi"].Value.ToString();
            }
        }
    }
}
