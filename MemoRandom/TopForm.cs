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
    public partial class TopForm : Form
    {
        private ListDataClass ListDataClass = new ListDataClass();

        // コンストラクタ
        public TopForm()
        {
            InitializeComponent();
            //初期表示
            InitDisp();
        }

        // 初期表示
        private void InitDisp()
        {
            this.dataGridView1.Rows.Clear();

            string strFolderPath = string.Empty;
            strFolderPath = FileAccessCom.getFolderPath(SettingForm.strSettingFile, SettingForm.strInitFolderPath);
            FileAccessCom.FolderCheck(strFolderPath);

            ListDataClass = FileAccessCom.getListDataClass(strFolderPath);

            for(int i = 0;i < this.ListDataClass.FileCount; i++)
            {
                this.dataGridView1.Rows.Add(this.ListDataClass.FileNo[i],this.ListDataClass.UpdateTime[i].ToString("yyyy/MM/dd HH:mm:ss"), this.ListDataClass.Title[i]);
            }
        }

        // ファイル削除
        private void Delete()
        {
            string strFileName = string.Empty;

            // 選択行のファイルIDよりファイル名を取得
            strFileName = getFileName();

            FileAccessCom.deleteFile(strFileName);
        }

        // 選択行のファイルIDからファイル名を取得
        private string getFileName()
        {
            int intFileNo = 0;
            string strFileName = string.Empty;

            intFileNo = (int)this.dataGridView1.SelectedCells[0].Value;

            strFileName = this.ListDataClass.FileName[intFileNo];

            return strFileName;
        }

        // 選択行のファイルIDからタイトルを取得
        private string getTitle()
        {
            int intFileNo = 0;
            string strTitle = string.Empty;

            intFileNo = (int)this.dataGridView1.SelectedCells[0].Value;

            strTitle = this.ListDataClass.Title[intFileNo];

            return strTitle;
        }

        // 選択行のファイルIDからメッセージを取得
        private string getMessage()
        {
            int intFileNo = 0;
            string strMessage = string.Empty;

            intFileNo = (int)this.dataGridView1.SelectedCells[0].Value;

            strMessage = this.ListDataClass.Message[intFileNo];

            return strMessage;
        }

        // 新規登録ボタンクリックイベント
        private void btnNew_Click(object sender, EventArgs e)
        {
            Form form = new InsertForm();
            this.Visible = false;
            form.ShowDialog();
            InitDisp();
            this.Visible = true;
        }

        // 削除ボタンクリックイベント
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
            this.InitDisp();
        }

        // 設定ボタンクリックイベント
        private void btnSetting_Click(object sender, EventArgs e)
        {
            Form form = new SettingForm();
            this.Visible = false;
            form.ShowDialog();
            InitDisp();
            this.Visible = true;
        }

        // 一覧ダブルクリックイベント
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditDataClass editDataClass = new EditDataClass();
            editDataClass.FileName = getFileName();
            editDataClass.Title = getTitle();
            editDataClass.Message = getMessage();

            Form form = new InsertForm(editDataClass);
            this.Visible = false;
            form.ShowDialog();
            InitDisp();
            this.Visible = true ;
        }

        private void TopForm_KeyDown(object sender, KeyEventArgs e)
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
