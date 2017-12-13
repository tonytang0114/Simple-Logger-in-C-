using System;
using System.IO;
using SimpleLogger.IService;
namespace SimpleLogger
{
    public class LogWriter:ILogWriter
    {
        private string Log_path;
        public string Log_PATH
        {
            get
            {
                return Log_path;
            }
            set
            {
                Log_path = value;
            }
        }

        private string Log_folder;
        public string Log_FOLDER
        {
            get
            {
                return Log_folder;
            }
            set
            {
                Log_folder = value;
            }
        }

        private string Archive_log;
        public string Archive_Log
        {
            get
            {
                return Archive_log;
            }

            set
            {
                Archive_log = value;
            }
        }


        public string Log_Filename;
        public string Log_FILENAME
        {
            get
            {
                return Log_Filename;
            }
            set
            {
                Log_Filename = value;
            }
        }

        private string Log_fullpath;

        public LogWriter(string Log_path, string Log_folder, string File_name, string Archive_log)
        {
            this.Log_path = Log_path;
            this.Log_folder = Log_folder;
            this.Log_Filename = File_name;
            this.Archive_log = Archive_log;

            Log_Filename = Generate_File_with_a_standard();
            Log_fullpath = Generate_Log_Path(Log_Filename);

            CheckFolderIfExist();
            CreateStreamForLog();
        }

        public void CheckFolderIfExist()
        {
            try
            {
                //Any and all directories specified in path are created, 
                //unless they already exist or unless some part of path is invalid. 
                //The path parameter specifies a directory path, not a file path. If the directory already exists, this method does nothing.
                Directory.CreateDirectory(Log_path);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
        }

        public void CreateStreamForLog()
        {
            using (StreamWriter sw = new StreamWriter(Log_fullpath))
            {
                sw.Close();
            }
        }

        public string Generate_File_with_a_standard()
        {
            //Subject to change...
            return Path.Combine(String.Format(Log_Filename,DateTime.Now.ToString("yyyyMMdd")));
        }

        public string Generate_Log_Path(string filename)
        {
            return Path.Combine(Log_path + filename);
        }

        public void WriteLine(string text)
        {
            using (FileStream fs = new FileStream(Log_fullpath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(text);
            }
        }

        public void Move_To_Archive_Folder()
        {
            String[] filenameslist = Directory.GetFiles(Log_path);
            try
            {

                if (filenameslist != null && filenameslist.Length > 0)
                {
                    //Move to archive
                    foreach (string filename in filenameslist)
                    {
                        string tempfilename = Path.GetFileName(filename);
                        string tempFullarchivePath = Path.Combine(Archive_log + tempfilename);

                        if (File.Exists(tempFullarchivePath))
                        {
                            File.Delete(tempFullarchivePath);
                        }
                        File.Move(Log_fullpath, tempFullarchivePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
