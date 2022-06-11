using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoRandom
{
    public partial class InsertForm : Form
    {
        private const string conNewFormName = "新規登録";
        private const string conEditFormName = "編集";
        private const string conTitle = "タイトル";
        private const string conMessage = "本文";

        private EditDataClass EditDataClass = new EditDataClass();

        // true：新規登録画面、false：編集画面
        private bool blnNewForm = true;

        public InsertForm()
        {
            InitializeComponent();
            this.Text = conNewFormName;
        }

        public InsertForm(EditDataClass editDataClass)
        {
            InitializeComponent();
            this.Text = conEditFormName;
            this.EditDataClass = editDataClass;
            initEditForm();
            blnNewForm = false;
        }

        private void initEditForm()
        {
            this.txtTitle.Text = this.EditDataClass.Title;
            this.txtMessage.Text = this.EditDataClass.Message;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string strFolderPath = string.Empty;
            strFolderPath = FileAccessCom.getFolderPath(SettingForm.strSettingFile, SettingForm.strInitFolderPath);

            if (this.blnNewForm)
            {
                FileAccessCom.createFile(this.txtTitle.Text, this.txtMessage.Text, strFolderPath);
            }
            else
            {
                FileAccessCom.updateFile(this.txtTitle.Text, this.txtMessage.Text, this.EditDataClass.FileName);
            }
            this.Close();
        }

        private void InsertForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
