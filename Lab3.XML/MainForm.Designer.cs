namespace Lab3.XML
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.resultView = new System.Windows.Forms.RichTextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.xmlPath = new System.Windows.Forms.TextBox();
            this.xmlPathInvite = new System.Windows.Forms.Label();
            this.titleCheck = new System.Windows.Forms.CheckBox();
            this.title = new System.Windows.Forms.TextBox();
            this.genreCheck = new System.Windows.Forms.CheckBox();
            this.yearCheck = new System.Windows.Forms.CheckBox();
            this.countryCheck = new System.Windows.Forms.CheckBox();
            this.directorCheck = new System.Windows.Forms.CheckBox();
            this.actorCheck = new System.Windows.Forms.CheckBox();
            this.imdbRateCheck = new System.Windows.Forms.CheckBox();
            this.kinopoiskRateCheck = new System.Windows.Forms.CheckBox();
            this.anotationCheck = new System.Windows.Forms.CheckBox();
            this.lengthCheck = new System.Windows.Forms.CheckBox();
            this.fromYear = new System.Windows.Forms.DateTimePicker();
            this.toYear = new System.Windows.Forms.DateTimePicker();
            this.fromInvite = new System.Windows.Forms.Label();
            this.toInvite = new System.Windows.Forms.Label();
            this.genres = new System.Windows.Forms.ComboBox();
            this.countries = new System.Windows.Forms.ComboBox();
            this.director = new System.Windows.Forms.TextBox();
            this.actor = new System.Windows.Forms.TextBox();
            this.imdbRate = new System.Windows.Forms.TextBox();
            this.kinopoiskRate = new System.Windows.Forms.TextBox();
            this.anotation = new System.Windows.Forms.TextBox();
            this.length = new System.Windows.Forms.TextBox();
            this.makeXslTransform = new System.Windows.Forms.Button();
            this.xslPathInvite = new System.Windows.Forms.Label();
            this.xslPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // resultView
            // 
            this.resultView.Location = new System.Drawing.Point(317, 64);
            this.resultView.Name = "resultView";
            this.resultView.Size = new System.Drawing.Size(326, 295);
            this.resultView.TabIndex = 0;
            this.resultView.Text = "";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(12, 336);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Шукати";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // xmlPath
            // 
            this.xmlPath.Location = new System.Drawing.Point(120, 12);
            this.xmlPath.Name = "xmlPath";
            this.xmlPath.Size = new System.Drawing.Size(523, 20);
            this.xmlPath.TabIndex = 2;
            this.xmlPath.Text = "C:\\Users\\Роман\\Documents\\GitHub\\Lab3.XML\\Lab3.XML\\Base.xml";
            this.xmlPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xmlPath_KeyDown);
            // 
            // xmlPathInvite
            // 
            this.xmlPathInvite.AutoSize = true;
            this.xmlPathInvite.Location = new System.Drawing.Point(9, 15);
            this.xmlPathInvite.Name = "xmlPathInvite";
            this.xmlPathInvite.Size = new System.Drawing.Size(110, 13);
            this.xmlPathInvite.TabIndex = 3;
            this.xmlPathInvite.Text = "Шлях до XML файлу:";
            // 
            // titleCheck
            // 
            this.titleCheck.AutoSize = true;
            this.titleCheck.Location = new System.Drawing.Point(12, 66);
            this.titleCheck.Name = "titleCheck";
            this.titleCheck.Size = new System.Drawing.Size(61, 17);
            this.titleCheck.TabIndex = 4;
            this.titleCheck.Text = "Назва:";
            this.titleCheck.UseVisualStyleBackColor = true;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(120, 64);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(191, 20);
            this.title.TabIndex = 5;
            // 
            // genreCheck
            // 
            this.genreCheck.AutoSize = true;
            this.genreCheck.Location = new System.Drawing.Point(12, 89);
            this.genreCheck.Name = "genreCheck";
            this.genreCheck.Size = new System.Drawing.Size(58, 17);
            this.genreCheck.TabIndex = 6;
            this.genreCheck.Text = "Жанр:";
            this.genreCheck.UseVisualStyleBackColor = true;
            // 
            // yearCheck
            // 
            this.yearCheck.AutoSize = true;
            this.yearCheck.Location = new System.Drawing.Point(12, 118);
            this.yearCheck.Name = "yearCheck";
            this.yearCheck.Size = new System.Drawing.Size(100, 17);
            this.yearCheck.TabIndex = 8;
            this.yearCheck.Text = "Рік створення:";
            this.yearCheck.UseVisualStyleBackColor = true;
            // 
            // countryCheck
            // 
            this.countryCheck.AutoSize = true;
            this.countryCheck.Location = new System.Drawing.Point(12, 168);
            this.countryCheck.Name = "countryCheck";
            this.countryCheck.Size = new System.Drawing.Size(63, 17);
            this.countryCheck.TabIndex = 9;
            this.countryCheck.Text = "Країна:";
            this.countryCheck.UseVisualStyleBackColor = true;
            // 
            // directorCheck
            // 
            this.directorCheck.AutoSize = true;
            this.directorCheck.Location = new System.Drawing.Point(12, 191);
            this.directorCheck.Name = "directorCheck";
            this.directorCheck.Size = new System.Drawing.Size(74, 17);
            this.directorCheck.TabIndex = 10;
            this.directorCheck.Text = "Режисер:";
            this.directorCheck.UseVisualStyleBackColor = true;
            // 
            // actorCheck
            // 
            this.actorCheck.AutoSize = true;
            this.actorCheck.Location = new System.Drawing.Point(12, 214);
            this.actorCheck.Name = "actorCheck";
            this.actorCheck.Size = new System.Drawing.Size(59, 17);
            this.actorCheck.TabIndex = 11;
            this.actorCheck.Text = "Актор:";
            this.actorCheck.UseVisualStyleBackColor = true;
            // 
            // imdbRateCheck
            // 
            this.imdbRateCheck.AutoSize = true;
            this.imdbRateCheck.Location = new System.Drawing.Point(12, 237);
            this.imdbRateCheck.Name = "imdbRateCheck";
            this.imdbRateCheck.Size = new System.Drawing.Size(56, 17);
            this.imdbRateCheck.TabIndex = 12;
            this.imdbRateCheck.Text = "IMDB:";
            this.imdbRateCheck.UseVisualStyleBackColor = true;
            // 
            // kinopoiskRateCheck
            // 
            this.kinopoiskRateCheck.AutoSize = true;
            this.kinopoiskRateCheck.Location = new System.Drawing.Point(12, 260);
            this.kinopoiskRateCheck.Name = "kinopoiskRateCheck";
            this.kinopoiskRateCheck.Size = new System.Drawing.Size(81, 17);
            this.kinopoiskRateCheck.TabIndex = 13;
            this.kinopoiskRateCheck.Text = "Кінопошук:";
            this.kinopoiskRateCheck.UseVisualStyleBackColor = true;
            // 
            // anotationCheck
            // 
            this.anotationCheck.AutoSize = true;
            this.anotationCheck.Location = new System.Drawing.Point(12, 283);
            this.anotationCheck.Name = "anotationCheck";
            this.anotationCheck.Size = new System.Drawing.Size(73, 17);
            this.anotationCheck.TabIndex = 14;
            this.anotationCheck.Text = "Анотація:";
            this.anotationCheck.UseVisualStyleBackColor = true;
            // 
            // lengthCheck
            // 
            this.lengthCheck.AutoSize = true;
            this.lengthCheck.Location = new System.Drawing.Point(12, 306);
            this.lengthCheck.Name = "lengthCheck";
            this.lengthCheck.Size = new System.Drawing.Size(96, 17);
            this.lengthCheck.TabIndex = 15;
            this.lengthCheck.Text = "Довжина (хв):";
            this.lengthCheck.UseVisualStyleBackColor = true;
            // 
            // fromYear
            // 
            this.fromYear.CustomFormat = "yyyy";
            this.fromYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromYear.Location = new System.Drawing.Point(152, 114);
            this.fromYear.Name = "fromYear";
            this.fromYear.ShowUpDown = true;
            this.fromYear.Size = new System.Drawing.Size(57, 20);
            this.fromYear.TabIndex = 16;
            // 
            // toYear
            // 
            this.toYear.CustomFormat = "yyyy";
            this.toYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toYear.Location = new System.Drawing.Point(152, 140);
            this.toYear.Name = "toYear";
            this.toYear.ShowUpDown = true;
            this.toYear.Size = new System.Drawing.Size(57, 20);
            this.toYear.TabIndex = 17;
            // 
            // fromInvite
            // 
            this.fromInvite.AutoSize = true;
            this.fromInvite.Location = new System.Drawing.Point(121, 119);
            this.fromInvite.Name = "fromInvite";
            this.fromInvite.Size = new System.Drawing.Size(25, 13);
            this.fromInvite.TabIndex = 18;
            this.fromInvite.Text = "Від:";
            // 
            // toInvite
            // 
            this.toInvite.AutoSize = true;
            this.toInvite.Location = new System.Drawing.Point(121, 144);
            this.toInvite.Name = "toInvite";
            this.toInvite.Size = new System.Drawing.Size(25, 13);
            this.toInvite.TabIndex = 19;
            this.toInvite.Text = "До:";
            // 
            // genres
            // 
            this.genres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genres.FormattingEnabled = true;
            this.genres.Location = new System.Drawing.Point(120, 87);
            this.genres.Name = "genres";
            this.genres.Size = new System.Drawing.Size(191, 21);
            this.genres.Sorted = true;
            this.genres.TabIndex = 20;
            // 
            // countries
            // 
            this.countries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countries.FormattingEnabled = true;
            this.countries.Location = new System.Drawing.Point(120, 166);
            this.countries.Name = "countries";
            this.countries.Size = new System.Drawing.Size(190, 21);
            this.countries.Sorted = true;
            this.countries.TabIndex = 21;
            // 
            // director
            // 
            this.director.Location = new System.Drawing.Point(120, 189);
            this.director.Name = "director";
            this.director.Size = new System.Drawing.Size(190, 20);
            this.director.TabIndex = 22;
            // 
            // actor
            // 
            this.actor.Location = new System.Drawing.Point(120, 212);
            this.actor.Name = "actor";
            this.actor.Size = new System.Drawing.Size(190, 20);
            this.actor.TabIndex = 23;
            // 
            // imdbRate
            // 
            this.imdbRate.Location = new System.Drawing.Point(120, 235);
            this.imdbRate.Name = "imdbRate";
            this.imdbRate.Size = new System.Drawing.Size(190, 20);
            this.imdbRate.TabIndex = 24;
            // 
            // kinopoiskRate
            // 
            this.kinopoiskRate.Location = new System.Drawing.Point(120, 257);
            this.kinopoiskRate.Name = "kinopoiskRate";
            this.kinopoiskRate.Size = new System.Drawing.Size(190, 20);
            this.kinopoiskRate.TabIndex = 25;
            // 
            // anotation
            // 
            this.anotation.Location = new System.Drawing.Point(120, 281);
            this.anotation.Name = "anotation";
            this.anotation.Size = new System.Drawing.Size(190, 20);
            this.anotation.TabIndex = 26;
            // 
            // length
            // 
            this.length.Location = new System.Drawing.Point(120, 304);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(190, 20);
            this.length.TabIndex = 27;
            // 
            // makeXslTransform
            // 
            this.makeXslTransform.Location = new System.Drawing.Point(93, 336);
            this.makeXslTransform.Name = "makeXslTransform";
            this.makeXslTransform.Size = new System.Drawing.Size(147, 23);
            this.makeXslTransform.TabIndex = 28;
            this.makeXslTransform.Text = "Трансформувати в HTML";
            this.makeXslTransform.UseVisualStyleBackColor = true;
            this.makeXslTransform.Click += new System.EventHandler(this.makeXslTransform_Click);
            // 
            // xslPathInvite
            // 
            this.xslPathInvite.AutoSize = true;
            this.xslPathInvite.Location = new System.Drawing.Point(9, 41);
            this.xslPathInvite.Name = "xslPathInvite";
            this.xslPathInvite.Size = new System.Drawing.Size(108, 13);
            this.xslPathInvite.TabIndex = 29;
            this.xslPathInvite.Text = "Шлях до XSL файлу:";
            // 
            // xslPath
            // 
            this.xslPath.Location = new System.Drawing.Point(120, 38);
            this.xslPath.Name = "xslPath";
            this.xslPath.Size = new System.Drawing.Size(523, 20);
            this.xslPath.TabIndex = 30;
            this.xslPath.Text = "C:\\Users\\Роман\\Documents\\GitHub\\Lab3.XML\\Lab3.XML\\BaseToHTML.xsl";
            this.xslPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xslPath_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 372);
            this.Controls.Add(this.xslPath);
            this.Controls.Add(this.xslPathInvite);
            this.Controls.Add(this.makeXslTransform);
            this.Controls.Add(this.length);
            this.Controls.Add(this.anotation);
            this.Controls.Add(this.kinopoiskRate);
            this.Controls.Add(this.imdbRate);
            this.Controls.Add(this.actor);
            this.Controls.Add(this.director);
            this.Controls.Add(this.countries);
            this.Controls.Add(this.genres);
            this.Controls.Add(this.toInvite);
            this.Controls.Add(this.fromInvite);
            this.Controls.Add(this.toYear);
            this.Controls.Add(this.fromYear);
            this.Controls.Add(this.lengthCheck);
            this.Controls.Add(this.anotationCheck);
            this.Controls.Add(this.kinopoiskRateCheck);
            this.Controls.Add(this.imdbRateCheck);
            this.Controls.Add(this.actorCheck);
            this.Controls.Add(this.directorCheck);
            this.Controls.Add(this.countryCheck);
            this.Controls.Add(this.yearCheck);
            this.Controls.Add(this.genreCheck);
            this.Controls.Add(this.title);
            this.Controls.Add(this.titleCheck);
            this.Controls.Add(this.xmlPathInvite);
            this.Controls.Add(this.xmlPath);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.resultView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox resultView;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox xmlPath;
        private System.Windows.Forms.Label xmlPathInvite;
        private System.Windows.Forms.CheckBox titleCheck;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.CheckBox genreCheck;
        private System.Windows.Forms.CheckBox yearCheck;
        private System.Windows.Forms.CheckBox countryCheck;
        private System.Windows.Forms.CheckBox directorCheck;
        private System.Windows.Forms.CheckBox actorCheck;
        private System.Windows.Forms.CheckBox imdbRateCheck;
        private System.Windows.Forms.CheckBox kinopoiskRateCheck;
        private System.Windows.Forms.CheckBox anotationCheck;
        private System.Windows.Forms.CheckBox lengthCheck;
        private System.Windows.Forms.DateTimePicker fromYear;
        private System.Windows.Forms.DateTimePicker toYear;
        private System.Windows.Forms.Label fromInvite;
        private System.Windows.Forms.Label toInvite;
        private System.Windows.Forms.ComboBox genres;
        private System.Windows.Forms.ComboBox countries;
        private System.Windows.Forms.TextBox director;
        private System.Windows.Forms.TextBox actor;
        private System.Windows.Forms.TextBox imdbRate;
        private System.Windows.Forms.TextBox kinopoiskRate;
        private System.Windows.Forms.TextBox anotation;
        private System.Windows.Forms.TextBox length;
        private System.Windows.Forms.Button makeXslTransform;
        private System.Windows.Forms.Label xslPathInvite;
        private System.Windows.Forms.TextBox xslPath;
    }
}

