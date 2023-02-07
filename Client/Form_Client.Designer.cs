namespace Client
{
    partial class Form_Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ConMenuDir = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConMenuDirCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuDirDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuDirRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuDirMove = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuDirZipping = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConMenuFileCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuFileMove = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuFileDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuFileStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuFileUnZipping = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConMenuProcStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuProcClose = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.GroupBoxUpdate = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.TxtUrlUpdate = new System.Windows.Forms.TextBox();
            this.GroupBoxProcess = new System.Windows.Forms.GroupBox();
            this.ListBoxProcess = new System.Windows.Forms.ListBox();
            this.GroupBoxGetObject = new System.Windows.Forms.GroupBox();
            this.RadioButtonWebCam = new System.Windows.Forms.RadioButton();
            this.RadioButtonProcess = new System.Windows.Forms.RadioButton();
            this.RadioButtonScreen = new System.Windows.Forms.RadioButton();
            this.ButtonGetObject = new System.Windows.Forms.Button();
            this.GroupBoxUpload = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonUpload = new System.Windows.Forms.Button();
            this.TxtFileName = new System.Windows.Forms.TextBox();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.ButtonBack = new System.Windows.Forms.Button();
            this.TxtPathCatalog = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListBoxCatalog = new System.Windows.Forms.ListBox();
            this.ListBoxFile = new System.Windows.Forms.ListBox();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBoxOnlineUsers = new System.Windows.Forms.GroupBox();
            this.TextBoxCurrentUser = new System.Windows.Forms.TextBox();
            this.ListBoxOnlineUsers = new System.Windows.Forms.ListBox();
            this.GroupBoxServerControl = new System.Windows.Forms.GroupBox();
            this.TxtSCPathTwo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ButtonSCStartCommand = new System.Windows.Forms.Button();
            this.ComboBoxSC = new System.Windows.Forms.ComboBox();
            this.TxtSCPathOne = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtFlag = new System.Windows.Forms.TextBox();
            this.TxtCommand = new System.Windows.Forms.TextBox();
            this.RTxtLog = new System.Windows.Forms.RichTextBox();
            this.ButtonFocus = new System.Windows.Forms.Button();
            this.ButtonStartCommand = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ListBoxScenario = new System.Windows.Forms.ListBox();
            this.ButtonDelScenarioCommand = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtCommandScenario = new System.Windows.Forms.TextBox();
            this.ButtonAddScenarioCommand = new System.Windows.Forms.Button();
            this.ButtonStartScenario = new System.Windows.Forms.Button();
            this.ConMenuDir.SuspendLayout();
            this.ConMenuFile.SuspendLayout();
            this.ConMenuProcess.SuspendLayout();
            this.TabPage4.SuspendLayout();
            this.GroupBoxUpdate.SuspendLayout();
            this.GroupBoxProcess.SuspendLayout();
            this.GroupBoxGetObject.SuspendLayout();
            this.GroupBoxUpload.SuspendLayout();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBoxOnlineUsers.SuspendLayout();
            this.GroupBoxServerControl.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConMenuDir
            // 
            this.ConMenuDir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConMenuDirCreate,
            this.ConMenuDirDelete,
            this.ConMenuDirRename,
            this.ConMenuDirMove,
            this.ConMenuDirZipping});
            this.ConMenuDir.Name = "ConMenuDir";
            this.ConMenuDir.Size = new System.Drawing.Size(162, 114);
            // 
            // ConMenuDirCreate
            // 
            this.ConMenuDirCreate.Name = "ConMenuDirCreate";
            this.ConMenuDirCreate.Size = new System.Drawing.Size(161, 22);
            this.ConMenuDirCreate.Text = "Создать";
            this.ConMenuDirCreate.Click += new System.EventHandler(this.ConMenuDirCreate_Click);
            // 
            // ConMenuDirDelete
            // 
            this.ConMenuDirDelete.Name = "ConMenuDirDelete";
            this.ConMenuDirDelete.Size = new System.Drawing.Size(161, 22);
            this.ConMenuDirDelete.Text = "Удалить";
            this.ConMenuDirDelete.Click += new System.EventHandler(this.ConMenuDirDelete_Click);
            // 
            // ConMenuDirRename
            // 
            this.ConMenuDirRename.Name = "ConMenuDirRename";
            this.ConMenuDirRename.Size = new System.Drawing.Size(161, 22);
            this.ConMenuDirRename.Text = "Переименовать";
            this.ConMenuDirRename.Click += new System.EventHandler(this.ConMenuDirRename_Click);
            // 
            // ConMenuDirMove
            // 
            this.ConMenuDirMove.Name = "ConMenuDirMove";
            this.ConMenuDirMove.Size = new System.Drawing.Size(161, 22);
            this.ConMenuDirMove.Text = "Переместить";
            this.ConMenuDirMove.Click += new System.EventHandler(this.ConMenuDirMove_Click);
            // 
            // ConMenuDirZipping
            // 
            this.ConMenuDirZipping.Name = "ConMenuDirZipping";
            this.ConMenuDirZipping.Size = new System.Drawing.Size(161, 22);
            this.ConMenuDirZipping.Text = "Сжать в архив";
            this.ConMenuDirZipping.Click += new System.EventHandler(this.ConMenuDirZipping_Click);
            // 
            // ConMenuFile
            // 
            this.ConMenuFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConMenuFileCreate,
            this.ConMenuFileDelete,
            this.ConMenuFileRename,
            this.ConMenuFileMove,
            this.ConMenuFileDownload,
            this.ConMenuFileStart,
            this.ConMenuFileUnZipping});
            this.ConMenuFile.Name = "ContextMenuStrip";
            this.ConMenuFile.Size = new System.Drawing.Size(168, 158);
            // 
            // ConMenuFileCreate
            // 
            this.ConMenuFileCreate.Name = "ConMenuFileCreate";
            this.ConMenuFileCreate.Size = new System.Drawing.Size(167, 22);
            this.ConMenuFileCreate.Text = "Создать";
            this.ConMenuFileCreate.Click += new System.EventHandler(this.ConMenuFileCreate_Click);
            // 
            // ConMenuFileDelete
            // 
            this.ConMenuFileDelete.Name = "ConMenuFileDelete";
            this.ConMenuFileDelete.Size = new System.Drawing.Size(167, 22);
            this.ConMenuFileDelete.Text = "Удалить";
            this.ConMenuFileDelete.Click += new System.EventHandler(this.ConMenuFileDelete_Click);
            // 
            // ConMenuFileRename
            // 
            this.ConMenuFileRename.Name = "ConMenuFileRename";
            this.ConMenuFileRename.Size = new System.Drawing.Size(167, 22);
            this.ConMenuFileRename.Text = "Переименовать";
            this.ConMenuFileRename.Click += new System.EventHandler(this.ConMenuFileRename_Click);
            // 
            // ConMenuFileMove
            // 
            this.ConMenuFileMove.Name = "ConMenuFileMove";
            this.ConMenuFileMove.Size = new System.Drawing.Size(167, 22);
            this.ConMenuFileMove.Text = "Переместить";
            this.ConMenuFileMove.Click += new System.EventHandler(this.ConMenuFileMove_Click);
            // 
            // ConMenuFileDownload
            // 
            this.ConMenuFileDownload.Name = "ConMenuFileDownload";
            this.ConMenuFileDownload.Size = new System.Drawing.Size(167, 22);
            this.ConMenuFileDownload.Text = "Скачать";
            this.ConMenuFileDownload.Click += new System.EventHandler(this.ConMenuFileDownload_Click);
            // 
            // ConMenuFileStart
            // 
            this.ConMenuFileStart.Name = "ConMenuFileStart";
            this.ConMenuFileStart.Size = new System.Drawing.Size(167, 22);
            this.ConMenuFileStart.Text = "Запустить";
            this.ConMenuFileStart.Click += new System.EventHandler(this.ConMenuFileStart_Click);
            // 
            // ConMenuFileUnZipping
            // 
            this.ConMenuFileUnZipping.Name = "ConMenuFileUnZipping";
            this.ConMenuFileUnZipping.Size = new System.Drawing.Size(167, 22);
            this.ConMenuFileUnZipping.Text = "Разархивировать";
            this.ConMenuFileUnZipping.Click += new System.EventHandler(this.ConMenuFileUnZipping_Click);
            // 
            // ConMenuProcess
            // 
            this.ConMenuProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConMenuProcStart,
            this.ConMenuProcClose});
            this.ConMenuProcess.Name = "ConMenuProcess";
            this.ConMenuProcess.Size = new System.Drawing.Size(130, 48);
            // 
            // ConMenuProcStart
            // 
            this.ConMenuProcStart.Name = "ConMenuProcStart";
            this.ConMenuProcStart.Size = new System.Drawing.Size(129, 22);
            this.ConMenuProcStart.Text = "Запустить";
            this.ConMenuProcStart.Click += new System.EventHandler(this.ConMenuProcStart_Click);
            // 
            // ConMenuProcClose
            // 
            this.ConMenuProcClose.Name = "ConMenuProcClose";
            this.ConMenuProcClose.Size = new System.Drawing.Size(129, 22);
            this.ConMenuProcClose.Text = "Закрыть";
            this.ConMenuProcClose.Click += new System.EventHandler(this.ConMenuProcClose_Click);
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.GroupBoxUpdate);
            this.TabPage4.Controls.Add(this.GroupBoxProcess);
            this.TabPage4.Controls.Add(this.GroupBoxGetObject);
            this.TabPage4.Controls.Add(this.GroupBoxUpload);
            this.TabPage4.Location = new System.Drawing.Point(4, 22);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(1044, 515);
            this.TabPage4.TabIndex = 3;
            this.TabPage4.Text = "Управление";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // GroupBoxUpdate
            // 
            this.GroupBoxUpdate.Controls.Add(this.label11);
            this.GroupBoxUpdate.Controls.Add(this.ButtonUpdate);
            this.GroupBoxUpdate.Controls.Add(this.TxtUrlUpdate);
            this.GroupBoxUpdate.Location = new System.Drawing.Point(6, 207);
            this.GroupBoxUpdate.Name = "GroupBoxUpdate";
            this.GroupBoxUpdate.Size = new System.Drawing.Size(294, 91);
            this.GroupBoxUpdate.TabIndex = 50;
            this.GroupBoxUpdate.TabStop = false;
            this.GroupBoxUpdate.Text = "Обновление mss.exe";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "URL:";
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(213, 62);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(75, 23);
            this.ButtonUpdate.TabIndex = 1;
            this.ButtonUpdate.Text = "Обновить";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // TxtUrlUpdate
            // 
            this.TxtUrlUpdate.Location = new System.Drawing.Point(6, 32);
            this.TxtUrlUpdate.Name = "TxtUrlUpdate";
            this.TxtUrlUpdate.Size = new System.Drawing.Size(282, 20);
            this.TxtUrlUpdate.TabIndex = 0;
            // 
            // GroupBoxProcess
            // 
            this.GroupBoxProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxProcess.Controls.Add(this.ListBoxProcess);
            this.GroupBoxProcess.Location = new System.Drawing.Point(306, 6);
            this.GroupBoxProcess.Name = "GroupBoxProcess";
            this.GroupBoxProcess.Size = new System.Drawing.Size(274, 323);
            this.GroupBoxProcess.TabIndex = 49;
            this.GroupBoxProcess.TabStop = false;
            this.GroupBoxProcess.Text = "Процессы:";
            // 
            // ListBoxProcess
            // 
            this.ListBoxProcess.ContextMenuStrip = this.ConMenuProcess;
            this.ListBoxProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxProcess.FormattingEnabled = true;
            this.ListBoxProcess.Location = new System.Drawing.Point(3, 16);
            this.ListBoxProcess.Name = "ListBoxProcess";
            this.ListBoxProcess.Size = new System.Drawing.Size(268, 304);
            this.ListBoxProcess.Sorted = true;
            this.ListBoxProcess.TabIndex = 0;
            // 
            // GroupBoxGetObject
            // 
            this.GroupBoxGetObject.Controls.Add(this.RadioButtonWebCam);
            this.GroupBoxGetObject.Controls.Add(this.RadioButtonProcess);
            this.GroupBoxGetObject.Controls.Add(this.RadioButtonScreen);
            this.GroupBoxGetObject.Controls.Add(this.ButtonGetObject);
            this.GroupBoxGetObject.Location = new System.Drawing.Point(6, 6);
            this.GroupBoxGetObject.Name = "GroupBoxGetObject";
            this.GroupBoxGetObject.Size = new System.Drawing.Size(294, 90);
            this.GroupBoxGetObject.TabIndex = 48;
            this.GroupBoxGetObject.TabStop = false;
            this.GroupBoxGetObject.Text = "Получить объект:";
            // 
            // RadioButtonWebCam
            // 
            this.RadioButtonWebCam.AutoSize = true;
            this.RadioButtonWebCam.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonWebCam.Name = "RadioButtonWebCam";
            this.RadioButtonWebCam.Size = new System.Drawing.Size(117, 17);
            this.RadioButtonWebCam.TabIndex = 46;
            this.RadioButtonWebCam.TabStop = true;
            this.RadioButtonWebCam.Text = "Снимок (WebCam)";
            this.RadioButtonWebCam.UseVisualStyleBackColor = true;
            // 
            // RadioButtonProcess
            // 
            this.RadioButtonProcess.AutoSize = true;
            this.RadioButtonProcess.Location = new System.Drawing.Point(6, 65);
            this.RadioButtonProcess.Name = "RadioButtonProcess";
            this.RadioButtonProcess.Size = new System.Drawing.Size(197, 17);
            this.RadioButtonProcess.TabIndex = 45;
            this.RadioButtonProcess.TabStop = true;
            this.RadioButtonProcess.Text = "Список процессов (Task Manager)";
            this.RadioButtonProcess.UseVisualStyleBackColor = true;
            // 
            // RadioButtonScreen
            // 
            this.RadioButtonScreen.AutoSize = true;
            this.RadioButtonScreen.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonScreen.Name = "RadioButtonScreen";
            this.RadioButtonScreen.Size = new System.Drawing.Size(124, 17);
            this.RadioButtonScreen.TabIndex = 44;
            this.RadioButtonScreen.TabStop = true;
            this.RadioButtonScreen.Text = "Скриншот (Desktop)";
            this.RadioButtonScreen.UseVisualStyleBackColor = true;
            // 
            // ButtonGetObject
            // 
            this.ButtonGetObject.Location = new System.Drawing.Point(213, 19);
            this.ButtonGetObject.Name = "ButtonGetObject";
            this.ButtonGetObject.Size = new System.Drawing.Size(75, 23);
            this.ButtonGetObject.TabIndex = 43;
            this.ButtonGetObject.Text = "Получить";
            this.ButtonGetObject.UseVisualStyleBackColor = true;
            this.ButtonGetObject.Click += new System.EventHandler(this.ButtonGetObject_Click);
            // 
            // GroupBoxUpload
            // 
            this.GroupBoxUpload.Controls.Add(this.label9);
            this.GroupBoxUpload.Controls.Add(this.label8);
            this.GroupBoxUpload.Controls.Add(this.ButtonUpload);
            this.GroupBoxUpload.Controls.Add(this.TxtFileName);
            this.GroupBoxUpload.Controls.Add(this.TxtID);
            this.GroupBoxUpload.Location = new System.Drawing.Point(6, 102);
            this.GroupBoxUpload.Name = "GroupBoxUpload";
            this.GroupBoxUpload.Size = new System.Drawing.Size(294, 99);
            this.GroupBoxUpload.TabIndex = 44;
            this.GroupBoxUpload.TabStop = false;
            this.GroupBoxUpload.Text = "Загрузка файла на сервер:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Имя файла:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "URL:";
            // 
            // ButtonUpload
            // 
            this.ButtonUpload.Location = new System.Drawing.Point(212, 69);
            this.ButtonUpload.Name = "ButtonUpload";
            this.ButtonUpload.Size = new System.Drawing.Size(78, 23);
            this.ButtonUpload.TabIndex = 2;
            this.ButtonUpload.Text = "Загрузить";
            this.ButtonUpload.UseVisualStyleBackColor = true;
            this.ButtonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // TxtFileName
            // 
            this.TxtFileName.Location = new System.Drawing.Point(6, 71);
            this.TxtFileName.Name = "TxtFileName";
            this.TxtFileName.Size = new System.Drawing.Size(200, 20);
            this.TxtFileName.TabIndex = 1;
            this.TxtFileName.Text = "NewFile.file";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(6, 32);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(281, 20);
            this.TxtID.TabIndex = 0;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.ButtonBack);
            this.TabPage3.Controls.Add(this.TxtPathCatalog);
            this.TabPage3.Controls.Add(this.splitContainer1);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(1044, 515);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Каталоги";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // ButtonBack
            // 
            this.ButtonBack.Location = new System.Drawing.Point(6, 7);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(33, 23);
            this.ButtonBack.TabIndex = 46;
            this.ButtonBack.Text = "<<<";
            this.ButtonBack.UseVisualStyleBackColor = true;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // TxtPathCatalog
            // 
            this.TxtPathCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPathCatalog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtPathCatalog.Location = new System.Drawing.Point(45, 9);
            this.TxtPathCatalog.Name = "TxtPathCatalog";
            this.TxtPathCatalog.Size = new System.Drawing.Size(538, 20);
            this.TxtPathCatalog.TabIndex = 45;
            this.TxtPathCatalog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPathCatalog_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListBoxCatalog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListBoxFile);
            this.splitContainer1.Size = new System.Drawing.Size(576, 280);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 44;
            // 
            // ListBoxCatalog
            // 
            this.ListBoxCatalog.ContextMenuStrip = this.ConMenuDir;
            this.ListBoxCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxCatalog.FormattingEnabled = true;
            this.ListBoxCatalog.Location = new System.Drawing.Point(0, 0);
            this.ListBoxCatalog.Name = "ListBoxCatalog";
            this.ListBoxCatalog.Size = new System.Drawing.Size(153, 280);
            this.ListBoxCatalog.TabIndex = 41;
            this.ListBoxCatalog.DoubleClick += new System.EventHandler(this.ListBoxCatalog_DoubleClick);
            // 
            // ListBoxFile
            // 
            this.ListBoxFile.ContextMenuStrip = this.ConMenuFile;
            this.ListBoxFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxFile.FormattingEnabled = true;
            this.ListBoxFile.Location = new System.Drawing.Point(0, 0);
            this.ListBoxFile.Name = "ListBoxFile";
            this.ListBoxFile.Size = new System.Drawing.Size(419, 280);
            this.ListBoxFile.TabIndex = 38;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBoxOnlineUsers);
            this.TabPage1.Controls.Add(this.GroupBoxServerControl);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.TxtFlag);
            this.TabPage1.Controls.Add(this.TxtCommand);
            this.TabPage1.Controls.Add(this.RTxtLog);
            this.TabPage1.Controls.Add(this.ButtonFocus);
            this.TabPage1.Controls.Add(this.ButtonStartCommand);
            this.TabPage1.Controls.Add(this.ButtonClear);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(1044, 515);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Подключение";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupBoxOnlineUsers
            // 
            this.GroupBoxOnlineUsers.Controls.Add(this.TextBoxCurrentUser);
            this.GroupBoxOnlineUsers.Controls.Add(this.ListBoxOnlineUsers);
            this.GroupBoxOnlineUsers.Location = new System.Drawing.Point(595, 6);
            this.GroupBoxOnlineUsers.Name = "GroupBoxOnlineUsers";
            this.GroupBoxOnlineUsers.Size = new System.Drawing.Size(315, 263);
            this.GroupBoxOnlineUsers.TabIndex = 6;
            this.GroupBoxOnlineUsers.TabStop = false;
            this.GroupBoxOnlineUsers.Text = "Пользователи онлайн:";
            // 
            // TextBoxCurrentUser
            // 
            this.TextBoxCurrentUser.Location = new System.Drawing.Point(6, 19);
            this.TextBoxCurrentUser.Name = "TextBoxCurrentUser";
            this.TextBoxCurrentUser.Size = new System.Drawing.Size(303, 20);
            this.TextBoxCurrentUser.TabIndex = 25;
            // 
            // ListBoxOnlineUsers
            // 
            this.ListBoxOnlineUsers.FormattingEnabled = true;
            this.ListBoxOnlineUsers.Location = new System.Drawing.Point(6, 45);
            this.ListBoxOnlineUsers.Name = "ListBoxOnlineUsers";
            this.ListBoxOnlineUsers.Size = new System.Drawing.Size(303, 212);
            this.ListBoxOnlineUsers.TabIndex = 24;
            this.ListBoxOnlineUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxOnlineUsers_SelectedIndexChanged);
            // 
            // GroupBoxServerControl
            // 
            this.GroupBoxServerControl.Controls.Add(this.TxtSCPathTwo);
            this.GroupBoxServerControl.Controls.Add(this.label10);
            this.GroupBoxServerControl.Controls.Add(this.label5);
            this.GroupBoxServerControl.Controls.Add(this.ButtonSCStartCommand);
            this.GroupBoxServerControl.Controls.Add(this.ComboBoxSC);
            this.GroupBoxServerControl.Controls.Add(this.TxtSCPathOne);
            this.GroupBoxServerControl.Location = new System.Drawing.Point(4, 85);
            this.GroupBoxServerControl.Name = "GroupBoxServerControl";
            this.GroupBoxServerControl.Size = new System.Drawing.Size(288, 124);
            this.GroupBoxServerControl.TabIndex = 23;
            this.GroupBoxServerControl.TabStop = false;
            this.GroupBoxServerControl.Text = "Server Control";
            // 
            // TxtSCPathTwo
            // 
            this.TxtSCPathTwo.Enabled = false;
            this.TxtSCPathTwo.Location = new System.Drawing.Point(6, 96);
            this.TxtSCPathTwo.Name = "TxtSCPathTwo";
            this.TxtSCPathTwo.Size = new System.Drawing.Size(276, 20);
            this.TxtSCPathTwo.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Path Two:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Path One:";
            // 
            // ButtonSCStartCommand
            // 
            this.ButtonSCStartCommand.Location = new System.Drawing.Point(168, 16);
            this.ButtonSCStartCommand.Name = "ButtonSCStartCommand";
            this.ButtonSCStartCommand.Size = new System.Drawing.Size(114, 23);
            this.ButtonSCStartCommand.TabIndex = 2;
            this.ButtonSCStartCommand.Text = "Запустить команду";
            this.ButtonSCStartCommand.UseVisualStyleBackColor = true;
            this.ButtonSCStartCommand.Click += new System.EventHandler(this.ButtonSCStartCommand_Click);
            // 
            // ComboBoxSC
            // 
            this.ComboBoxSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSC.FormattingEnabled = true;
            this.ComboBoxSC.Items.AddRange(new object[] {
            "Проверка связи",
            "Включить службу",
            "Выключить службу",
            "Перезапустить службу",
            "Запустить процесс",
            "Переместить файл",
            "Получить лог"});
            this.ComboBoxSC.Location = new System.Drawing.Point(6, 17);
            this.ComboBoxSC.Name = "ComboBoxSC";
            this.ComboBoxSC.Size = new System.Drawing.Size(156, 21);
            this.ComboBoxSC.TabIndex = 1;
            this.ComboBoxSC.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSC_SelectedIndexChanged);
            // 
            // TxtSCPathOne
            // 
            this.TxtSCPathOne.Enabled = false;
            this.TxtSCPathOne.Location = new System.Drawing.Point(6, 57);
            this.TxtSCPathOne.Name = "TxtSCPathOne";
            this.TxtSCPathOne.Size = new System.Drawing.Size(276, 20);
            this.TxtSCPathOne.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "flag:";
            // 
            // TxtFlag
            // 
            this.TxtFlag.Location = new System.Drawing.Point(4, 58);
            this.TxtFlag.Name = "TxtFlag";
            this.TxtFlag.Size = new System.Drawing.Size(171, 20);
            this.TxtFlag.TabIndex = 20;
            // 
            // TxtCommand
            // 
            this.TxtCommand.Location = new System.Drawing.Point(4, 19);
            this.TxtCommand.Name = "TxtCommand";
            this.TxtCommand.Size = new System.Drawing.Size(291, 20);
            this.TxtCommand.TabIndex = 17;
            this.TxtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCommand_KeyDown);
            // 
            // RTxtLog
            // 
            this.RTxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTxtLog.Location = new System.Drawing.Point(7, 311);
            this.RTxtLog.Name = "RTxtLog";
            this.RTxtLog.Size = new System.Drawing.Size(1031, 198);
            this.RTxtLog.TabIndex = 3;
            this.RTxtLog.Text = "";
            // 
            // ButtonFocus
            // 
            this.ButtonFocus.Location = new System.Drawing.Point(-7, -30);
            this.ButtonFocus.Name = "ButtonFocus";
            this.ButtonFocus.Size = new System.Drawing.Size(0, 0);
            this.ButtonFocus.TabIndex = 19;
            this.ButtonFocus.UseVisualStyleBackColor = true;
            // 
            // ButtonStartCommand
            // 
            this.ButtonStartCommand.Location = new System.Drawing.Point(181, 56);
            this.ButtonStartCommand.Name = "ButtonStartCommand";
            this.ButtonStartCommand.Size = new System.Drawing.Size(114, 23);
            this.ButtonStartCommand.TabIndex = 18;
            this.ButtonStartCommand.Text = "Запустить команду";
            this.ButtonStartCommand.UseVisualStyleBackColor = true;
            this.ButtonStartCommand.Click += new System.EventHandler(this.ButtonStartCommand_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(45, 282);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 12;
            this.ButtonClear.Text = "Очистить";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Введите команду:";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPage1);
            this.TabControl.Controls.Add(this.TabPage3);
            this.TabControl.Controls.Add(this.TabPage4);
            this.TabControl.Controls.Add(this.TabPage2);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1052, 541);
            this.TabControl.TabIndex = 20;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.ListBoxScenario);
            this.TabPage2.Controls.Add(this.ButtonDelScenarioCommand);
            this.TabPage2.Controls.Add(this.label12);
            this.TabPage2.Controls.Add(this.TxtCommandScenario);
            this.TabPage2.Controls.Add(this.ButtonAddScenarioCommand);
            this.TabPage2.Controls.Add(this.ButtonStartScenario);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1044, 515);
            this.TabPage2.TabIndex = 4;
            this.TabPage2.Text = "Сценарии";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // ListBoxScenario
            // 
            this.ListBoxScenario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxScenario.FormattingEnabled = true;
            this.ListBoxScenario.Location = new System.Drawing.Point(329, 6);
            this.ListBoxScenario.Name = "ListBoxScenario";
            this.ListBoxScenario.Size = new System.Drawing.Size(252, 290);
            this.ListBoxScenario.TabIndex = 1;
            // 
            // ButtonDelScenarioCommand
            // 
            this.ButtonDelScenarioCommand.Location = new System.Drawing.Point(131, 48);
            this.ButtonDelScenarioCommand.Name = "ButtonDelScenarioCommand";
            this.ButtonDelScenarioCommand.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelScenarioCommand.TabIndex = 10;
            this.ButtonDelScenarioCommand.Text = "Удалить";
            this.ButtonDelScenarioCommand.UseVisualStyleBackColor = true;
            this.ButtonDelScenarioCommand.Click += new System.EventHandler(this.ButtonDelScenarioCommand_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Команда:";
            // 
            // TxtCommandScenario
            // 
            this.TxtCommandScenario.Location = new System.Drawing.Point(8, 22);
            this.TxtCommandScenario.Name = "TxtCommandScenario";
            this.TxtCommandScenario.Size = new System.Drawing.Size(315, 20);
            this.TxtCommandScenario.TabIndex = 7;
            // 
            // ButtonAddScenarioCommand
            // 
            this.ButtonAddScenarioCommand.Location = new System.Drawing.Point(212, 48);
            this.ButtonAddScenarioCommand.Name = "ButtonAddScenarioCommand";
            this.ButtonAddScenarioCommand.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddScenarioCommand.TabIndex = 0;
            this.ButtonAddScenarioCommand.Text = "Добавить";
            this.ButtonAddScenarioCommand.UseVisualStyleBackColor = true;
            this.ButtonAddScenarioCommand.Click += new System.EventHandler(this.ButtonAddScenarioCommand_Click);
            // 
            // ButtonStartScenario
            // 
            this.ButtonStartScenario.Location = new System.Drawing.Point(50, 48);
            this.ButtonStartScenario.Name = "ButtonStartScenario";
            this.ButtonStartScenario.Size = new System.Drawing.Size(75, 23);
            this.ButtonStartScenario.TabIndex = 4;
            this.ButtonStartScenario.Text = "Запустить";
            this.ButtonStartScenario.UseVisualStyleBackColor = true;
            this.ButtonStartScenario.Click += new System.EventHandler(this.ButtonStartScenario_Click);
            // 
            // Form_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1052, 541);
            this.Controls.Add(this.TabControl);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(613, 371);
            this.Name = "Form_Client";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Client_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Client_KeyDown);
            this.ConMenuDir.ResumeLayout(false);
            this.ConMenuFile.ResumeLayout(false);
            this.ConMenuProcess.ResumeLayout(false);
            this.TabPage4.ResumeLayout(false);
            this.GroupBoxUpdate.ResumeLayout(false);
            this.GroupBoxUpdate.PerformLayout();
            this.GroupBoxProcess.ResumeLayout(false);
            this.GroupBoxGetObject.ResumeLayout(false);
            this.GroupBoxGetObject.PerformLayout();
            this.GroupBoxUpload.ResumeLayout(false);
            this.GroupBoxUpload.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.GroupBoxOnlineUsers.ResumeLayout(false);
            this.GroupBoxOnlineUsers.PerformLayout();
            this.GroupBoxServerControl.ResumeLayout(false);
            this.GroupBoxServerControl.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip ConMenuFile;
        private System.Windows.Forms.ToolStripMenuItem ConMenuFileCreate;
        private System.Windows.Forms.ToolStripMenuItem ConMenuFileDelete;
        private System.Windows.Forms.ToolStripMenuItem ConMenuFileDownload;
        private System.Windows.Forms.ToolStripMenuItem ConMenuFileMove;
        private System.Windows.Forms.ToolStripMenuItem ConMenuFileRename;
        private System.Windows.Forms.ContextMenuStrip ConMenuDir;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDirCreate;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDirDelete;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDirRename;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDirMove;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDirZipping;
        private System.Windows.Forms.ToolStripMenuItem ConMenuFileUnZipping;
        private System.Windows.Forms.ContextMenuStrip ConMenuProcess;
        private System.Windows.Forms.ToolStripMenuItem ConMenuProcStart;
        private System.Windows.Forms.ToolStripMenuItem ConMenuProcClose;
        private System.Windows.Forms.TabPage TabPage4;
        private System.Windows.Forms.GroupBox GroupBoxProcess;
        private System.Windows.Forms.ListBox ListBoxProcess;
        private System.Windows.Forms.GroupBox GroupBoxGetObject;
        private System.Windows.Forms.RadioButton RadioButtonWebCam;
        private System.Windows.Forms.RadioButton RadioButtonProcess;
        private System.Windows.Forms.RadioButton RadioButtonScreen;
        private System.Windows.Forms.Button ButtonGetObject;
        private System.Windows.Forms.GroupBox GroupBoxUpload;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ButtonUpload;
        private System.Windows.Forms.TextBox TxtFileName;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.TabPage TabPage3;
        private System.Windows.Forms.TextBox TxtPathCatalog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox ListBoxCatalog;
        private System.Windows.Forms.ListBox ListBoxFile;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtFlag;
        private System.Windows.Forms.TextBox TxtCommand;
        private System.Windows.Forms.RichTextBox RTxtLog;
        private System.Windows.Forms.Button ButtonFocus;
        private System.Windows.Forms.Button ButtonStartCommand;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.GroupBox GroupBoxServerControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ButtonSCStartCommand;
        private System.Windows.Forms.ComboBox ComboBoxSC;
        private System.Windows.Forms.TextBox TxtSCPathOne;
        private System.Windows.Forms.TextBox TxtSCPathTwo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ButtonBack;
        private System.Windows.Forms.ToolStripMenuItem ConMenuFileStart;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtCommandScenario;
        private System.Windows.Forms.Button ButtonAddScenarioCommand;
        private System.Windows.Forms.Button ButtonStartScenario;
        private System.Windows.Forms.ListBox ListBoxScenario;
        private System.Windows.Forms.Button ButtonDelScenarioCommand;
        private System.Windows.Forms.GroupBox GroupBoxUpdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.TextBox TxtUrlUpdate;
        private System.Windows.Forms.GroupBox GroupBoxOnlineUsers;
        private System.Windows.Forms.ListBox ListBoxOnlineUsers;
        private System.Windows.Forms.TextBox TextBoxCurrentUser;
    }
}