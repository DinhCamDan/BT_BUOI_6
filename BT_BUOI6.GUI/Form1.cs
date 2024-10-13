using BT_BUOI_6.BUS;
using BT_BUOI_6.DAL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BT_BUOI6.GUI
{
    public partial class Form1 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();
        public Form1()
        {
            InitializeComponent();
            studentService = new StudentService();
            facultyService = new FacultyService();
            majorService = new MajorService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvStudent);
                var listFacultys = facultyService.GetAll();
                var listStudents = studentService.GetAll();
                FillFalcultyCombobox(listFacultys);
                BindGrid(listStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvStudent.RowHeadersWidth = 40;

        }

        private void BindGrid(List<STUDENT> listStudents)
        {
             dgvStudent.Rows.Clear();
                foreach (var item in listStudents)
                {
                    int index = dgvStudent.Rows.Add();
                    dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                    dgvStudent.Rows[index].Cells[1].Value = item.StudentName;
                    if (item.Faculty != null)
                        dgvStudent.Rows[index].Cells[2].Value =
                        item.Faculty.FacultyName;
                    dgvStudent.Rows[index].Cells[3].Value = item.DTB + "";
                    if (item.MajorID != null)
                        dgvStudent.Rows[index].Cells[4].Value = item.Major.MajorName + "";
                    ShowAvatar(item.Avata);
                }
            
        }

        private void ShowAvatar(byte[] avatarData)
        {
            if (avatarData == null || avatarData.Length == 0)
            {
                picAvatar.Image = null;
            }
            else
            {
                using (var ms = new MemoryStream(avatarData))
                {
                    picAvatar.Image = Image.FromStream(ms);
                }
                picAvatar.Refresh();
            }
        }

        private byte[] GetAvatarData()
        {
            if (picAvatar.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picAvatar.Image.Save(ms, picAvatar.Image.RawFormat);     
                    return ms.ToArray();
                }
            }
            return null;
        }

        private void FillFalcultyCombobox(List<FACULTY> listFacultys)
        {
            listFacultys.Insert(0, new FACULTY());
            this.cbbFaculty.DataSource = listFacultys;
            this.cbbFaculty.DisplayMember = "FacultyName";
            this.cbbFaculty.ValueMember = "FacultyID";
        }

        private void setGridViewStyle(DataGridView dgvStudent)
        {
            dgvStudent.BorderStyle = BorderStyle.FixedSingle;
            dgvStudent.DefaultCellStyle.SelectionBackColor = Color.Gray;
            dgvStudent.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStudent.BackgroundColor = Color.White;
            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                var listStudents = new List<STUDENT>();
                if (this.checkBox1.Checked)
                    listStudents = studentService.GetAllHasNoMajor();
                else
                    listStudents = studentService.GetAll();
                BindGrid(listStudents);
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblQLSV_Click(object sender, EventArgs e)
        {

        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            try
            {
                double dtb;
                if (!double.TryParse(txtDTB.Text, out dtb) || dtb < 0 || dtb > 10)
                {
                    MessageBox.Show("Điểm trung bình không hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var upStudent = studentService.FindById(txtMSSV.Text);
                {
                    if (upStudent != null)
                    {
                        upStudent.StudentID = txtMSSV.Text;
                        upStudent.StudentName = txtHoTen.Text;
                        upStudent.FacultyID = cbbFaculty.SelectedValue.ToString();
                        upStudent.DTB = dtb;
                        upStudent.Avata = GetAvatarData();
                        studentService.InserUpdate(upStudent);
                        var listStudents = studentService.GetAll();
                        txtMSSV.Clear();
                        txtHoTen.Clear();
                        cbbFaculty.SelectedIndex = -1;
                        txtDTB.Clear();
                        picAvatar.Image = null;
                        MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var student = new STUDENT
                        {

                            StudentID = txtMSSV.Text,
                            StudentName = txtHoTen.Text,
                            FacultyID = cbbFaculty.SelectedValue.ToString(),
                            DTB = dtb,
                            Avata = GetAvatarData()
                        };

                        studentService.InserUpdate(student);
                        var listStudents = studentService.GetAll();
                        BindGrid(listStudents);
                        txtMSSV.Clear();
                        txtHoTen.Clear();
                        cbbFaculty.SelectedIndex = -1;
                        txtDTB.Clear();
                        picAvatar.Image = null;
                        MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }     
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string mssv = dgvStudent.SelectedRows[0].Cells[0].Value.ToString(); 
                    try
                    {
                        using (var context = new Model1())
                        {
                            var studentToDelete = context.STUDENTs.FirstOrDefault(s => s.StudentID == mssv);
                            if (studentToDelete != null)
                            {
                                context.STUDENTs.Remove(studentToDelete);
                                context.SaveChanges();
                                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var listStudents = studentService.GetAll();
                                BindGrid(listStudents);
                            }
                            else
                            {
                                MessageBox.Show("Sinh viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
