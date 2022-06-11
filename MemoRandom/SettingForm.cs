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

namespace MemoRandom
{
    public partial class SettingForm : Form
    {
        public const string strSettingFile = @"Setting.ini";
        public const string strInitFolderPath = @"C:\bbrk";
        public const string strExtension = @".bbrk";
        public SettingForm()
        {
            InitializeComponent();
            initDisp();
        }

        private void initDisp()
        {
            string strFolderPath = FileAccessCom.getFolderPath(strSettingFile, strInitFolderPath);
            this.txtFolderPath.Text = strFolderPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // ダイアログのタイトル
                openFileDialog.Title = "フォルダを選択してください。";


                // デフォルトのフォルダ
                openFileDialog.InitialDirectory = this.txtFolderPath.Text;


                // ダイアログボックスに表示する文字列
                openFileDialog.FileName = "SelectFolder";


                // フォルダのみを表示
                openFileDialog.Filter = "Folder|.";


                // 存在しないファイル指定時の警告
                openFileDialog.CheckFileExists = false;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtFolderPath.Text = Path.GetDirectoryName(openFileDialog.FileName);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FileAccessCom.FolderCheck(this.txtFolderPath.Text);
            FileAccessCom.updateFile(this.txtFolderPath.Text,"", strSettingFile);
            this.Close();
        }

        private void SettingForm_KeyDown(object sender, KeyEventArgs e)
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
