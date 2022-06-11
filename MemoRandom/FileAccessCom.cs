using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoRandom
{
    class FileAccessCom
    {
        // ファイルからデータクラスへ格納
        static public ListDataClass getListDataClass(string DirectoryPath)
        {
            ListDataClass listDataClass = new ListDataClass();
            int intFileNo = 0;

            try
            {
                string[] AllFileName = Directory.GetFiles(DirectoryPath, "*" + SettingForm.strExtension, System.IO.SearchOption.AllDirectories);

                foreach (string FilePath in AllFileName)
                {
                    if (File.Exists(FilePath))
                    {
                        listDataClass.UpdateTime.Add(System.IO.File.GetLastWriteTime(FilePath));
                        listDataClass.Title.Add(getTitle(FilePath));
                        listDataClass.FileNo.Add(intFileNo);
                        listDataClass.Message.Add(getMessage(FilePath));
                        listDataClass.FileName.Add(FilePath);
                        intFileNo++;
                    }
                }
                listDataClass.FileCount = AllFileName.Length;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return listDataClass;
        }

        // ファイルからタイトルを取得
        static private string getTitle(string FilePath)
        {
            string strTitle = string.Empty;

            try
            {
                //ファイルをオープンする
                using (StreamReader sr = new StreamReader(FilePath, Encoding.GetEncoding("UTF-8")))
                {
                    strTitle = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return strTitle;
        }

        // ファイルからメッセージを取得
        static private string getMessage(string FilePath)
        {
            string strMessage = string.Empty;
            int intFirstRow = 0;
            string Line = string.Empty;

            try
            {
                //ファイルをオープンする
                using (StreamReader sr = new StreamReader(FilePath, Encoding.GetEncoding("UTF-8")))
                {
                    while ((Line = sr.ReadLine()) != null)
                    {
                        if (intFirstRow != 0)
                        {
                            strMessage += Line + "\r\n";
                        }
                        intFirstRow++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return strMessage;
        }

        // Setting.iniから格納先パスを取得
        static public string getFolderPath(string strSettingFile,string strInitFolderPath)
        {
            string strFolderPath = string.Empty;
            if (File.Exists(strSettingFile))
            {
                strFolderPath = getTitle(strSettingFile);
            }
            else
            {
                createSettingFile(strInitFolderPath, "", strSettingFile);
                strFolderPath = strInitFolderPath;
            }

            return strFolderPath;
        }

        static public void createSettingFile(string strTitle,string strMessage,string strFilePath)
        {
            File.AppendAllText(strFilePath, strTitle + "\r\n" + strMessage);
        }

        static public void createFile(string strTitle, string strMessage, string strFilePath)
        {
            string strFileName = getFileName();
            FileAccessCom.FolderCheck(strFilePath);
            File.AppendAllText(strFilePath + @"\" + strFileName, strTitle + "\r\n" + strMessage);
        }

        static public void updateFile(string strTitle, string strMessage, string strFilePath)
        {
            File.WriteAllText(strFilePath, strTitle + "\r\n" + strMessage);
        }

        static public void deleteFile(string strFilePath)
        {
            File.Delete(strFilePath);
        }

        static public void FolderCheck(string strFolderPath)
        {
            if (!Directory.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }
        }

        static private string getFileName()
        {
            string strFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString();
            return strFileName + SettingForm.strExtension;
        }
    }
}
