using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet.Common;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Threading;

namespace ACCT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lvRemote.ListViewItemSorter = new ListViewColumnSorter();
            lvLocal.ListViewItemSorter = new ListViewColumnSorter();
        }
        string host = "10.5.199.100";
        string user = "ubechar";
        string password = "NC1280";
        Task loadDirTask = null;
        Task uploadTask = null;
        List<string> localFiles = new List<string>();


        private static void Sftp_ErrorOccurred(object sender, ExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (loadDirTask == null || loadDirTask.Status == TaskStatus.RanToCompletion)
            {
                btnShow.Text = "Connexion ...";
                btnShow.Enabled = false;
                loadDirTask = Task.Factory.StartNew(() => listDirContent()).ContinueWith(delegate
                {
                    btnShow.Invoke(new Action(() =>
                    {
                        btnShow.Text = "Afficher";
                        btnShow.Enabled = true;
                    }));
                });
            }
        }

        void listDirContent()
        {
            using (var sftp = new SftpClient(host, user, password))
            {
                sftp.ConnectionInfo.Timeout = TimeSpan.FromSeconds(2);
                sftp.ConnectionInfo.RetryAttempts = 15;
                for (int attempt = 0; attempt < 5; attempt++)
                {
                    btnShow.Invoke(new Action(() =>
                    {
                        btnShow.Text = $"Connexion ... ({attempt + 1})";
                    }));
                    try
                    {
                        sftp.Connect();
                    }
                    catch
                    {
                    }
                    if (sftp.IsConnected)
                        break;
                }

                if (sftp.IsConnected)
                {
                    var contents = sftp.ListDirectory(sftp.WorkingDirectory);
                    lvRemote.Invoke(new Action(() =>
                    {
                        lvRemote.BeginUpdate();
                        lvRemote.Items.Clear();
                        foreach (var file in contents)
                        {
                            var time = file.LastWriteTime;
                            var item = lvRemote.Items.Add(new ListViewItem(new[] {
                                file.Name+(file.IsDirectory?"/":""),
                                time.ToShortDateString() + " " + time.ToShortTimeString()
                            }));
                            item.ToolTipText = file.FullName;
                            item.Tag = file.LastWriteTime;
                            item.ImageIndex = GetExtensionIconIndex(file.IsDirectory ? "#0" : file.Name);
                        }
                        lvRemote.EndUpdate();
                        var sorter = lvRemote.ListViewItemSorter as ListViewColumnSorter;
                        sorter.SortColumn = 1;
                        sorter.Order = SortOrder.Descending;
                        lvRemote.Sort();
                    }));
                    sftp.Disconnect();
                }

            }
        }

        int GetExtensionIconIndex(string path)
        {
            if (path == "#0")
            {
                if (!ilIcons.Images.ContainsKey("#0"))
                {
                    Icon icon = IconTools.GetIconForFile(Path.GetTempPath(), ShellIconSize.SmallIcon);
                    ilIcons.Images.Add("#0", icon);
                }
                return ilIcons.Images.IndexOfKey("#0");
            }

            string ext = Path.GetExtension(path);
            ext = ext == "" ? "txt" : ext;
            if (!ilIcons.Images.ContainsKey(ext))
            {
                Icon icon = IconTools.GetIconForExtension(ext, ShellIconSize.SmallIcon);
                ilIcons.Images.Add(ext, icon);
            }
            return ilIcons.Images.IndexOfKey(ext);
        }

        private void lvRemote_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var sorter = (ListViewColumnSorter)lvRemote.ListViewItemSorter;
            sorter.Order = sorter.Order == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending;
            sorter.SortColumn = e.Column;
            lvRemote.Sort();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (uploadTask == null || uploadTask.Status == TaskStatus.RanToCompletion)
            {
                btnSend.Text = "upload ...";
                btnSend.Enabled = false;
                lvLocal.Enabled = false;
                uploadTask = Task.Factory.StartNew(() => uploadFiles()).ContinueWith(delegate
                {
                    btnSend.Invoke(new Action(() =>
                    {
                        btnSend.Text = "Envoyer";
                        btnSend.Enabled = true;
                        lvLocal.Enabled = true;
                        btnShow.PerformClick();
                    }));
                });
            }
        }

        void uploadFiles()
        {
            using (var sftp = new SftpClient(host, user, password))
            {
                sftp.ConnectionInfo.Timeout = TimeSpan.FromSeconds(2);
                sftp.ConnectionInfo.RetryAttempts = 15;
                for (int attempt = 0; attempt < 5; attempt++)
                {
                    try
                    {
                        sftp.Connect();
                    }
                    catch
                    {
                    }
                    if (sftp.IsConnected)
                        break;
                }

                if (sftp.IsConnected)
                {
                    List<string> uploadedFiles = new List<string>();
                    foreach (var file in localFiles)
                    {
                        var fileinfo = new FileInfo(file);
                        if (!fileinfo.Attributes.HasFlag(FileAttributes.Directory))
                            using (var ms = new FileStream(file, FileMode.Open))
                            {
                                sftp.BufferSize = (uint)ms.Length;
                                sftp.UploadFile(ms, Path.GetFileName(file), true, delegate
                                {
                                    Debug.WriteLine($"uploaded : {Path.GetFileName(file)}");
                                });
                                lvLocal.Invoke(new Action(delegate
                                {
                                    foreach (ListViewItem item in lvLocal.Items)
                                    {
                                        if (item.SubItems[2].Text == file)
                                        {
                                            item.Remove();
                                            uploadedFiles.Add(file);
                                            break;
                                        }
                                    }
                                }));
                            }
                    }
                    localFiles.RemoveAll(item => uploadedFiles.Contains(item));
                    sftp.Disconnect();
                }
            }
        }
    

//void UploadDirectory(SftpClient client, string localPath, string remotePath)
//        {
//            if (!client.Exists(remotePath))
//            {
//                client.CreateDirectory(remotePath);
//            }
//            var infos = new DirectoryInfo(localPath).EnumerateFileSystemInfos();
//            foreach (FileSystemInfo info in infos)
//            {
//                if (info.Attributes.HasFlag(FileAttributes.Directory))
//                {
//                    //string subPath = remotePath + "/" + info.Name;
//                    //if (!client.Exists(subPath))
//                    //{
//                    //    client.CreateDirectory(subPath);
//                    //}
//                    UploadDirectory(client, info.FullName, remotePath + "/" + info.Name);
//                }
//                else
//                {
//                    using (Stream fileStream = new FileStream(info.FullName, FileMode.Open))
//                    {
//                        client.UploadFile(fileStream, remotePath + "/" + info.Name);
//                    }
//                }
//            }
//        }


        private void lvLocal_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                addLocalFile(file);
            }
        }

        private void addLocalFile(string file)
        {
            if (!localFiles.Contains(file))
            {
                FileInfo info = new FileInfo(file);
                if (info.Attributes.HasFlag(FileAttributes.Directory))
                    return;
                localFiles.Add(file);
                string name = Path.GetFileName(file);
                DateTime time = info.LastWriteTime;
                var item = lvLocal.Items.Add(new ListViewItem(new[] { name, time.ToShortDateString() + " " + time.ToShortTimeString(), file }));
                ilIcons.Images.Add(IconTools.GetIconForFile(file, ShellIconSize.SmallIcon));
                item.ImageIndex = ilIcons.Images.Count - 1;
                item.ToolTipText = info.FullName;
            }
        }

        private void lvLocal_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvLocal_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var sorter = (ListViewColumnSorter)lvLocal.ListViewItemSorter;
            sorter.Order = sorter.Order == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending;
            sorter.SortColumn = e.Column;
            lvLocal.Sort();
        }

        private void lvLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lvLocal.SelectedItems != null)
                    foreach (ListViewItem item in lvLocal.SelectedItems)
                    {
                        localFiles.RemoveAt(item.Index);
                        item.Remove();
                    }
            }
        }
    }
}
