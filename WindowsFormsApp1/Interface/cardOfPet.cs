﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Controllers;
using DGVWF;

namespace WindowsFormsApp1
{
    public partial class cardOfPet : Form
    {
        Dictionary<String, DataGridView> currentDGVWFs = new Dictionary<String, DataGridView>
        {
            { "currentVaccinationsInDGVWF", new DataGridViewWithFilter() },
            { "currentVeterinaryActivitiesInDGVWF", new DataGridViewWithFilter() },
            { "currentAllVeterinaryActivitiesInDGVWF", new DataGridViewWithFilter() },
            { "currentPhotosInDGVWF", new DataGridView() },
            { "currentDocumentsFromVeterinaryActivitiesInDGVWF", new DataGridViewWithFilter() },

        };

        public cardOfPet(int id_pet)
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            OpenPet(id_pet);
        }

        private void event_cardOfPet_Load(object sender, EventArgs e)
        {

        }

        private void OpenPet(long id_pet)
        {
            CardOfPetController CardOfPet_controller = new CardOfPetController();
            Pet currentPet = CardOfPet_controller.OpenPet(id_pet);

            var firstPhotoFilePath = currentPet.Photos.First().Value.FilePath;

            pictureBox_photo.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(firstPhotoFilePath);

            label_name.Text = currentPet.Name;
            label_category.Text = currentPet.Category.Name;
            label_breed.Text = currentPet.Breed;
            label_gender.Text = currentPet.Category.Gender.Name;
            label_size.Text = currentPet.Size.Name;
            label_wool.Text = currentPet.Wool.Name;
            label_birthday.Text = currentPet.Birthday.ToString("dd.MM.yyyy");
            label_dateRegistry.Text = currentPet.DateRegistry.ToString("dd.MM.yyyy");
            label_passportNumber.Text = "№ " + currentPet.PassportNumber;
            label_ownerName.Text = currentPet.OwnerName;


            Dictionary<String, DataGridView> newDGVWFs = new Dictionary<String, DataGridView>
            {
                { "newVaccinationsInDGVWF", new DataGridViewWithFilter() },
                { "newVeterinaryActivitiesInDGVWF", new DataGridViewWithFilter() },
                { "newAllVeterinaryActivitiesInDGVWF", new DataGridViewWithFilter() },
                { "newPhotosInDGVWF", new DataGridView() },
                { "newDocumentsFromVeterinaryActivitiesInDGVWF", new DataGridViewWithFilter() },
            };

            //newVaccinationsInDGVWF
            {
                newDGVWFs["newVaccinationsInDGVWF"].AllowUserToAddRows = false;
                newDGVWFs["newVaccinationsInDGVWF"].AllowUserToResizeColumns = false;
                newDGVWFs["newVaccinationsInDGVWF"].AllowUserToResizeRows = false;
                newDGVWFs["newVaccinationsInDGVWF"].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDGVWFs["newVaccinationsInDGVWF"].RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                newDGVWFs["newVaccinationsInDGVWF"].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                newDGVWFs["newVaccinationsInDGVWF"].Dock = DockStyle.Fill;

                tabPage2.Controls.Add(newDGVWFs["newVaccinationsInDGVWF"]);
                currentDGVWFs["newVaccinationsInDGVWF"] = newDGVWFs["newVaccinationsInDGVWF"];

                DataTable DTToNewVaccinationsInDGVWF = new DataTable();

                DTToNewVaccinationsInDGVWF.Columns.Add("id");
                DTToNewVaccinationsInDGVWF.Columns.Add("Вакцина");
                DTToNewVaccinationsInDGVWF.Columns.Add("Дата", typeof(DateTime));

                foreach (Vaccination vaccination in currentPet.Vaccinations.Values)
                {
                    DTToNewVaccinationsInDGVWF.Rows.Add(vaccination.Id, vaccination.Name, vaccination.Date);
                }

                /////TODO: Убрать временные данные, после подключения БД
                //DTToNewVaccinationsInDGVWF.Rows.Add(1, "Против чего-то", new DateTime(2022, 04, 13));
                //DTToNewVaccinationsInDGVWF.Rows.Add(2, "Против того-то", new DateTime(2022, 04, 13));
                /////

                DataSet DSToNewVaccinationsInDGVWF = new DataSet();
                DSToNewVaccinationsInDGVWF.Tables.Add(DTToNewVaccinationsInDGVWF);

                newDGVWFs["newVaccinationsInDGVWF"].DataSource = DSToNewVaccinationsInDGVWF.Tables[0];
                newDGVWFs["newVaccinationsInDGVWF"].Columns["id"].Visible = false;
            }

            //newVeterinaryActivitiesInDGVWF
            {
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].AllowUserToAddRows = false;
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].AllowUserToResizeColumns = false;
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].AllowUserToResizeRows = false;
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].Dock = DockStyle.Fill;

                tabPage3.Controls.Add(newDGVWFs["newVeterinaryActivitiesInDGVWF"]);
                currentDGVWFs["newVeterinaryActivitiesInDGVWF"] = newDGVWFs["newVeterinaryActivitiesInDGVWF"];

                DataTable DTToNewVeterinaryActivitiesInDGVWF = new DataTable();

                DTToNewVeterinaryActivitiesInDGVWF.Columns.Add("id");
                DTToNewVeterinaryActivitiesInDGVWF.Columns.Add("Описание");
                DTToNewVeterinaryActivitiesInDGVWF.Columns.Add("Дата", typeof(DateTime));

                foreach (VeterinaryActivity veterinaryActivity in currentPet.VeterinaryActivities[true].Values)
                {
                    DTToNewVeterinaryActivitiesInDGVWF.Rows.Add(veterinaryActivity.Id, veterinaryActivity.StandardVeterinaryActivity.Name, veterinaryActivity.Date);
                }

                /////TODO: Убрать временные данные, после подключения БД
                //DTToNewVeterinaryActivitiesInDGVWF.Rows.Add(1, "Дегельминтизация", new DateTime(2022, 04, 13));
                //DTToNewVeterinaryActivitiesInDGVWF.Rows.Add(2, "Дегельминтизация", new DateTime(2022, 04, 13));
                /////

                DataSet DSToNewVeterinaryActivitiesInDGVWF = new DataSet();
                DSToNewVeterinaryActivitiesInDGVWF.Tables.Add(DTToNewVeterinaryActivitiesInDGVWF);

                newDGVWFs["newVeterinaryActivitiesInDGVWF"].DataSource = DSToNewVeterinaryActivitiesInDGVWF.Tables[0];
                newDGVWFs["newVeterinaryActivitiesInDGVWF"].Columns["id"].Visible = false;
            }

            //newAllVeterinaryActivitiesInDGVWF
            {
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].AllowUserToAddRows = false;
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].AllowUserToResizeColumns = false;
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].AllowUserToResizeRows = false;
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].Dock = DockStyle.Fill;

                tabPage4.Controls.Add(newDGVWFs["newAllVeterinaryActivitiesInDGVWF"]);
                currentDGVWFs["newAllVeterinaryActivitiesInDGVWF"] = newDGVWFs["newAllVeterinaryActivitiesInDGVWF"];

                DataTable DTToNewAllVeterinaryActivitiesInDGVWF = new DataTable();

                DTToNewAllVeterinaryActivitiesInDGVWF.Columns.Add("id");
                DTToNewAllVeterinaryActivitiesInDGVWF.Columns.Add("Описание");
                DTToNewAllVeterinaryActivitiesInDGVWF.Columns.Add("Дата", typeof(DateTime));

                foreach (VeterinaryActivity veterinaryActivity in currentPet.VeterinaryActivities[false].Values)
                {
                    DTToNewAllVeterinaryActivitiesInDGVWF.Rows.Add(veterinaryActivity.Id, veterinaryActivity.StandardVeterinaryActivity.Name, veterinaryActivity.Date);
                }

                /////TODO: Убрать временные данные, после подключения БД
                //DTToNewAllVeterinaryActivitiesInDGVWF.Rows.Add(1, "Обработка от эктопаразитов", new DateTime(2022, 04, 13));
                //DTToNewAllVeterinaryActivitiesInDGVWF.Rows.Add(2, "Дегельминтизация", new DateTime(2022, 04, 13));
                /////

                DataSet DSToNewAllVeterinaryActivitiesInDGVWF = new DataSet();
                DSToNewAllVeterinaryActivitiesInDGVWF.Tables.Add(DTToNewAllVeterinaryActivitiesInDGVWF);

                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].DataSource = DSToNewAllVeterinaryActivitiesInDGVWF.Tables[0];
                newDGVWFs["newAllVeterinaryActivitiesInDGVWF"].Columns["id"].Visible = false;
            }

            //newDocumentsFromVeterinaryActivitiesInDGVWF
            {
                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].AllowUserToAddRows = false;
                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].AllowUserToResizeColumns = false;
                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].AllowUserToResizeRows = false;
                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].Dock = DockStyle.Fill;

                tabPage5.Controls.Add(newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"]);
                currentDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"] = newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"];

                DataTable DTToNewDocumentsFromVeterinaryActivitiesInDGVWF = new DataTable();

                DTToNewDocumentsFromVeterinaryActivitiesInDGVWF.Columns.Add("Имя файла");
                DTToNewDocumentsFromVeterinaryActivitiesInDGVWF.Columns.Add("Описание");
                DTToNewDocumentsFromVeterinaryActivitiesInDGVWF.Columns.Add("Дата", typeof(DateTime));

                foreach (DocumentOfVeterinaryActivityForPet documentOfVeterinaryActivityForPet in currentPet.DocumentsOfVeterinaryActivities.Values)
                {
                    DTToNewDocumentsFromVeterinaryActivitiesInDGVWF.Rows.Add(documentOfVeterinaryActivityForPet.FilePath, documentOfVeterinaryActivityForPet.VeterinaryActivity.Description, documentOfVeterinaryActivityForPet.VeterinaryActivity.Date);
                }

                /////TODO: Убрать временные данные, после подключения БД
                //DTToNewDocumentsFromVeterinaryActivitiesInDGVWF.Rows.Add("Какой-то акт", "Обработка от эктопаразитов", new DateTime(2022, 04, 13));
                //DTToNewDocumentsFromVeterinaryActivitiesInDGVWF.Rows.Add("Второй акт", "Дегельминтизация", new DateTime(2022, 04, 13));
                /////

                DataSet DSToNewDocumentsFromVeterinaryActivitiesInDGVWF = new DataSet();
                DSToNewDocumentsFromVeterinaryActivitiesInDGVWF.Tables.Add(DTToNewDocumentsFromVeterinaryActivitiesInDGVWF);

                newDGVWFs["newDocumentsFromVeterinaryActivitiesInDGVWF"].DataSource = DSToNewDocumentsFromVeterinaryActivitiesInDGVWF.Tables[0];
            }

            //newPhotosInDGVWF
            {
                newDGVWFs["newPhotosInDGVWF"].AllowUserToAddRows = false;
                newDGVWFs["newPhotosInDGVWF"].AllowUserToResizeColumns = false;
                newDGVWFs["newPhotosInDGVWF"].AllowUserToResizeRows = false;
                newDGVWFs["newPhotosInDGVWF"].ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDGVWFs["newPhotosInDGVWF"].RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                newDGVWFs["newPhotosInDGVWF"].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                newDGVWFs["newPhotosInDGVWF"].AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                newDGVWFs["newPhotosInDGVWF"].Dock = DockStyle.Fill;

                tabPage6.Controls.Add(newDGVWFs["newPhotosInDGVWF"]);
                currentDGVWFs["newPhotosInDGVWF"] = newDGVWFs["newPhotosInDGVWF"];

                DataTable DTToNewPhotosInDGVWF = new DataTable();

                DTToNewPhotosInDGVWF.Columns.Add("Фото", typeof(Image));

                foreach (Photo photo in currentPet.Photos.Values)
                {
                    DTToNewPhotosInDGVWF.Rows.Add((Image)Properties.Resources.ResourceManager.GetObject(photo.FilePath));
                }

                DataSet DSToNewPhotosInDGVWF = new DataSet();
                DSToNewPhotosInDGVWF.Tables.Add(DTToNewPhotosInDGVWF);

                newDGVWFs["newPhotosInDGVWF"].DataSource = DSToNewPhotosInDGVWF.Tables[0];
            }

        }

        private void ExportToExcel(int id_pet)
        {
            CardOfPetController cardOfPetController = new CardOfPetController();
            cardOfPetController.ExportExcel(id_pet);
        }

        private void ExportToWord(int id_pet)
        {
            CardOfPetController cardOfPetController = new CardOfPetController();
            cardOfPetController.ExportWord(id_pet);
        }

        private void event_Click_CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
