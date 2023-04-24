namespace Hand2
{
    partial class mainPage
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
            this.fltrCompany = new System.Windows.Forms.ComboBox();
            this.fltrType = new System.Windows.Forms.ComboBox();
            this.fltrVersion = new System.Windows.Forms.TextBox();
            this.fltrYear = new System.Windows.Forms.TextBox();
            this.fltrHand = new System.Windows.Forms.TextBox();
            this.fltrGear = new System.Windows.Forms.ComboBox();
            this.fltrGas = new System.Windows.Forms.ComboBox();
            this.fltrKilometers = new System.Windows.Forms.TextBox();
            this.fltrFromPrice = new System.Windows.Forms.TextBox();
            this.fltrToPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ciYear = new System.Windows.Forms.Label();
            this.ciAddDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ciPrice = new System.Windows.Forms.Label();
            this.ciCarType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ciLabelGasType = new System.Windows.Forms.Label();
            this.ciVersion = new System.Windows.Forms.Label();
            this.ciGasType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ciCompany = new System.Windows.Forms.Label();
            this.ciColor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ciGear = new System.Windows.Forms.Label();
            this.ciSellerName = new System.Windows.Forms.Label();
            this.ciHand = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ciKilos = new System.Windows.Forms.Label();
            this.ciDescription = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditCar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ciPictureBox = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ciPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fltrCompany
            // 
            this.fltrCompany.AutoCompleteCustomSource.AddRange(new string[] {
            "Acura",
            "Alfa Romeo",
            "Aston Martin",
            "Audi",
            "Bentley",
            "BMW",
            "Bugatti",
            "Buick",
            "Cadillac",
            "Chevrolet",
            "Chrysler",
            "Citroen",
            "Dodge",
            "Ferrari",
            "Fiat",
            "Ford",
            "Geely",
            "General Motors",
            "GMC",
            "Honda",
            "Hyundai",
            "Infiniti",
            "Jaguar",
            "Jeep",
            "Kia",
            "Koenigsegg",
            "Lamborghini",
            "Land Rover",
            "Lexus",
            "Maserati",
            "Mazda",
            "McLaren",
            "Mercedes-Benz",
            "Mini",
            "Mitsubishi",
            "Nissan",
            "Pagani",
            "Pagani",
            "Peugeot",
            "Porsche",
            "Ram",
            "Renault",
            "Rolls Royce",
            "Saab",
            "Subaru",
            "Suzuki",
            "TATA Motors",
            "Tesla",
            "Toyota",
            "Volkswagen",
            "Volvo"});
            this.fltrCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.fltrCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fltrCompany.FormattingEnabled = true;
            this.fltrCompany.Items.AddRange(new object[] {
            "Any Company",
            "Acura",
            "Alfa Romeo",
            "Aston Martin",
            "Audi",
            "Bentley",
            "BMW",
            "Bugatti",
            "Buick",
            "Cadillac",
            "Chevrolet",
            "Chrysler",
            "Citroen",
            "Davidson",
            "Dodge",
            "Ferrari",
            "Fiat",
            "Ford",
            "Geely",
            "General Motors",
            "GMC",
            "Honda",
            "Hyundai",
            "Infiniti",
            "Jaguar",
            "Jeep",
            "Kawasaki",
            "Kia",
            "Koenigsegg",
            "Lamborghini",
            "Land Rover",
            "Lexus",
            "MAN",
            "Maserati",
            "Mazda",
            "McLaren",
            "Mercedes-Benz",
            "Mini",
            "Mitsubishi",
            "Nissan",
            "Opel",
            "Pagani",
            "Peugeot",
            "Porsche",
            "Ram",
            "Renault",
            "Rolls Royce",
            "Saab",
            "Skoda",
            "Subaru",
            "Suzuki",
            "TATA Motors",
            "Tesla",
            "Toyota",
            "Volkswagen",
            "Volvo"});
            this.fltrCompany.Location = new System.Drawing.Point(129, 8);
            this.fltrCompany.Margin = new System.Windows.Forms.Padding(2);
            this.fltrCompany.Name = "fltrCompany";
            this.fltrCompany.Size = new System.Drawing.Size(94, 21);
            this.fltrCompany.TabIndex = 31;
            this.fltrCompany.Text = "Company";
            this.fltrCompany.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrType
            // 
            this.fltrType.AutoCompleteCustomSource.AddRange(new string[] {
            "Acura",
            "Alfa Romeo",
            "Aston Martin",
            "Audi",
            "Bentley",
            "BMW",
            "Bugatti",
            "Buick",
            "Cadillac",
            "Chevrolet",
            "Chrysler",
            "Citroen",
            "Dodge",
            "Ferrari",
            "Fiat",
            "Ford",
            "Geely",
            "General Motors",
            "GMC",
            "Honda",
            "Hyundai",
            "Infiniti",
            "Jaguar",
            "Jeep",
            "Kia",
            "Koenigsegg",
            "Lamborghini",
            "Land Rover",
            "Lexus",
            "Maserati",
            "Mazda",
            "McLaren",
            "Mercedes-Benz",
            "Mini",
            "Mitsubishi",
            "Nissan",
            "Pagani",
            "Pagani",
            "Peugeot",
            "Porsche",
            "Ram",
            "Renault",
            "Rolls Royce",
            "Saab",
            "Subaru",
            "Suzuki",
            "TATA Motors",
            "Tesla",
            "Toyota",
            "Volkswagen",
            "Volvo"});
            this.fltrType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.fltrType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fltrType.FormattingEnabled = true;
            this.fltrType.Items.AddRange(new object[] {
            "Any Type",
            "Private",
            "Vans",
            "Jeeps",
            "Motorbikes",
            "Special"});
            this.fltrType.Location = new System.Drawing.Point(36, 8);
            this.fltrType.Margin = new System.Windows.Forms.Padding(2);
            this.fltrType.Name = "fltrType";
            this.fltrType.Size = new System.Drawing.Size(90, 21);
            this.fltrType.TabIndex = 32;
            this.fltrType.Text = "Type";
            this.fltrType.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrVersion
            // 
            this.fltrVersion.Location = new System.Drawing.Point(227, 9);
            this.fltrVersion.Margin = new System.Windows.Forms.Padding(2);
            this.fltrVersion.Name = "fltrVersion";
            this.fltrVersion.Size = new System.Drawing.Size(76, 20);
            this.fltrVersion.TabIndex = 33;
            this.fltrVersion.Text = "Version";
            this.fltrVersion.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrYear
            // 
            this.fltrYear.Location = new System.Drawing.Point(307, 9);
            this.fltrYear.Margin = new System.Windows.Forms.Padding(2);
            this.fltrYear.Name = "fltrYear";
            this.fltrYear.Size = new System.Drawing.Size(68, 20);
            this.fltrYear.TabIndex = 34;
            this.fltrYear.Text = "Year";
            this.fltrYear.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrHand
            // 
            this.fltrHand.Location = new System.Drawing.Point(379, 9);
            this.fltrHand.Margin = new System.Windows.Forms.Padding(2);
            this.fltrHand.Name = "fltrHand";
            this.fltrHand.Size = new System.Drawing.Size(77, 20);
            this.fltrHand.TabIndex = 35;
            this.fltrHand.Text = "Hand";
            this.fltrHand.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrGear
            // 
            this.fltrGear.AutoCompleteCustomSource.AddRange(new string[] {
            "Acura",
            "Alfa Romeo",
            "Aston Martin",
            "Audi",
            "Bentley",
            "BMW",
            "Bugatti",
            "Buick",
            "Cadillac",
            "Chevrolet",
            "Chrysler",
            "Citroen",
            "Dodge",
            "Ferrari",
            "Fiat",
            "Ford",
            "Geely",
            "General Motors",
            "GMC",
            "Honda",
            "Hyundai",
            "Infiniti",
            "Jaguar",
            "Jeep",
            "Kia",
            "Koenigsegg",
            "Lamborghini",
            "Land Rover",
            "Lexus",
            "Maserati",
            "Mazda",
            "McLaren",
            "Mercedes-Benz",
            "Mini",
            "Mitsubishi",
            "Nissan",
            "Pagani",
            "Pagani",
            "Peugeot",
            "Porsche",
            "Ram",
            "Renault",
            "Rolls Royce",
            "Saab",
            "Subaru",
            "Suzuki",
            "TATA Motors",
            "Tesla",
            "Toyota",
            "Volkswagen",
            "Volvo"});
            this.fltrGear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.fltrGear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fltrGear.FormattingEnabled = true;
            this.fltrGear.Items.AddRange(new object[] {
            "Any Type",
            "Manual",
            "Automatic",
            "Robotic"});
            this.fltrGear.Location = new System.Drawing.Point(460, 8);
            this.fltrGear.Margin = new System.Windows.Forms.Padding(2);
            this.fltrGear.Name = "fltrGear";
            this.fltrGear.Size = new System.Drawing.Size(71, 21);
            this.fltrGear.TabIndex = 37;
            this.fltrGear.Text = "Gear Type";
            this.fltrGear.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrGas
            // 
            this.fltrGas.AutoCompleteCustomSource.AddRange(new string[] {
            "Acura",
            "Alfa Romeo",
            "Aston Martin",
            "Audi",
            "Bentley",
            "BMW",
            "Bugatti",
            "Buick",
            "Cadillac",
            "Chevrolet",
            "Chrysler",
            "Citroen",
            "Dodge",
            "Ferrari",
            "Fiat",
            "Ford",
            "Geely",
            "General Motors",
            "GMC",
            "Honda",
            "Hyundai",
            "Infiniti",
            "Jaguar",
            "Jeep",
            "Kia",
            "Koenigsegg",
            "Lamborghini",
            "Land Rover",
            "Lexus",
            "Maserati",
            "Mazda",
            "McLaren",
            "Mercedes-Benz",
            "Mini",
            "Mitsubishi",
            "Nissan",
            "Pagani",
            "Pagani",
            "Peugeot",
            "Porsche",
            "Ram",
            "Renault",
            "Rolls Royce",
            "Saab",
            "Subaru",
            "Suzuki",
            "TATA Motors",
            "Tesla",
            "Toyota",
            "Volkswagen",
            "Volvo"});
            this.fltrGas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.fltrGas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fltrGas.FormattingEnabled = true;
            this.fltrGas.Items.AddRange(new object[] {
            "Any Type",
            "Gas",
            "Petrol",
            "Hyprid / Gas",
            "Hyprid / Petrol",
            "Full Hyprid"});
            this.fltrGas.Location = new System.Drawing.Point(534, 8);
            this.fltrGas.Margin = new System.Windows.Forms.Padding(2);
            this.fltrGas.Name = "fltrGas";
            this.fltrGas.Size = new System.Drawing.Size(71, 21);
            this.fltrGas.TabIndex = 38;
            this.fltrGas.Text = "Gas Type";
            this.fltrGas.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrKilometers
            // 
            this.fltrKilometers.Location = new System.Drawing.Point(609, 10);
            this.fltrKilometers.Margin = new System.Windows.Forms.Padding(2);
            this.fltrKilometers.Name = "fltrKilometers";
            this.fltrKilometers.Size = new System.Drawing.Size(73, 20);
            this.fltrKilometers.TabIndex = 39;
            this.fltrKilometers.Text = "Max Kilometers";
            this.fltrKilometers.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrFromPrice
            // 
            this.fltrFromPrice.Location = new System.Drawing.Point(685, 10);
            this.fltrFromPrice.Margin = new System.Windows.Forms.Padding(2);
            this.fltrFromPrice.Name = "fltrFromPrice";
            this.fltrFromPrice.Size = new System.Drawing.Size(73, 20);
            this.fltrFromPrice.TabIndex = 40;
            this.fltrFromPrice.Text = "From Price";
            this.fltrFromPrice.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // fltrToPrice
            // 
            this.fltrToPrice.Location = new System.Drawing.Point(761, 10);
            this.fltrToPrice.Margin = new System.Windows.Forms.Padding(2);
            this.fltrToPrice.Name = "fltrToPrice";
            this.fltrToPrice.Size = new System.Drawing.Size(73, 20);
            this.fltrToPrice.TabIndex = 41;
            this.fltrToPrice.Text = "To Price";
            this.fltrToPrice.Leave += new System.EventHandler(this.leftTheTextArea);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(874, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 19);
            this.label2.TabIndex = 43;
            this.label2.Text = "Guest";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1083, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 23);
            this.button4.TabIndex = 86;
            this.button4.Text = "Menu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.button1.Image = global::Hand2.Properties.Resources.rsz_search_33363;
            this.button1.Location = new System.Drawing.Point(838, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 27);
            this.button1.TabIndex = 42;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(10)))));
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.fltrCompany);
            this.panel3.Controls.Add(this.fltrType);
            this.panel3.Controls.Add(this.fltrVersion);
            this.panel3.Controls.Add(this.fltrYear);
            this.panel3.Controls.Add(this.fltrHand);
            this.panel3.Controls.Add(this.fltrGear);
            this.panel3.Controls.Add(this.fltrGas);
            this.panel3.Controls.Add(this.fltrKilometers);
            this.panel3.Controls.Add(this.fltrFromPrice);
            this.panel3.Controls.Add(this.fltrToPrice);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(-23, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1483, 38);
            this.panel3.TabIndex = 88;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button5.Location = new System.Drawing.Point(967, 9);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 24);
            this.button5.TabIndex = 47;
            this.button5.Text = "LOGIN";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(711, 405);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "Added:";
            // 
            // ciYear
            // 
            this.ciYear.AutoSize = true;
            this.ciYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciYear.Location = new System.Drawing.Point(758, 388);
            this.ciYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciYear.Name = "ciYear";
            this.ciYear.Size = new System.Drawing.Size(0, 13);
            this.ciYear.TabIndex = 70;
            // 
            // ciAddDate
            // 
            this.ciAddDate.AutoSize = true;
            this.ciAddDate.BackColor = System.Drawing.Color.Transparent;
            this.ciAddDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciAddDate.Location = new System.Drawing.Point(759, 406);
            this.ciAddDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciAddDate.Name = "ciAddDate";
            this.ciAddDate.Size = new System.Drawing.Size(0, 13);
            this.ciAddDate.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(720, 387);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Year:";
            // 
            // ciPrice
            // 
            this.ciPrice.AutoSize = true;
            this.ciPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciPrice.Location = new System.Drawing.Point(694, 423);
            this.ciPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciPrice.Name = "ciPrice";
            this.ciPrice.Size = new System.Drawing.Size(0, 29);
            this.ciPrice.TabIndex = 74;
            // 
            // ciCarType
            // 
            this.ciCarType.AutoSize = true;
            this.ciCarType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciCarType.Location = new System.Drawing.Point(759, 370);
            this.ciCarType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciCarType.Name = "ciCarType";
            this.ciCarType.Size = new System.Drawing.Size(0, 13);
            this.ciCarType.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(696, 369);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Car Type:";
            // 
            // ciLabelGasType
            // 
            this.ciLabelGasType.AutoSize = true;
            this.ciLabelGasType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciLabelGasType.Location = new System.Drawing.Point(877, 334);
            this.ciLabelGasType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciLabelGasType.Name = "ciLabelGasType";
            this.ciLabelGasType.Size = new System.Drawing.Size(65, 13);
            this.ciLabelGasType.TabIndex = 76;
            this.ciLabelGasType.Text = "Gas Type:";
            // 
            // ciVersion
            // 
            this.ciVersion.AutoSize = true;
            this.ciVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciVersion.Location = new System.Drawing.Point(759, 352);
            this.ciVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciVersion.Name = "ciVersion";
            this.ciVersion.Size = new System.Drawing.Size(0, 13);
            this.ciVersion.TabIndex = 66;
            // 
            // ciGasType
            // 
            this.ciGasType.AutoSize = true;
            this.ciGasType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciGasType.Location = new System.Drawing.Point(940, 335);
            this.ciGasType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciGasType.Name = "ciGasType";
            this.ciGasType.Size = new System.Drawing.Size(0, 13);
            this.ciGasType.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(706, 351);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "Version:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(900, 352);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 78;
            this.label9.Text = "Color:";
            // 
            // ciCompany
            // 
            this.ciCompany.AutoSize = true;
            this.ciCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciCompany.Location = new System.Drawing.Point(759, 334);
            this.ciCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciCompany.Name = "ciCompany";
            this.ciCompany.Size = new System.Drawing.Size(0, 13);
            this.ciCompany.TabIndex = 64;
            this.ciCompany.Click += new System.EventHandler(this.ciCompany_Click);
            // 
            // ciColor
            // 
            this.ciColor.AutoSize = true;
            this.ciColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciColor.Location = new System.Drawing.Point(940, 352);
            this.ciColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciColor.Name = "ciColor";
            this.ciColor.Size = new System.Drawing.Size(0, 13);
            this.ciColor.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(697, 333);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Company:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(863, 370);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Seller Name:";
            // 
            // ciGear
            // 
            this.ciGear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciGear.Location = new System.Drawing.Point(963, 305);
            this.ciGear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciGear.Name = "ciGear";
            this.ciGear.Size = new System.Drawing.Size(92, 15);
            this.ciGear.TabIndex = 62;
            this.ciGear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ciSellerName
            // 
            this.ciSellerName.AutoSize = true;
            this.ciSellerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciSellerName.Location = new System.Drawing.Point(940, 370);
            this.ciSellerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciSellerName.Name = "ciSellerName";
            this.ciSellerName.Size = new System.Drawing.Size(0, 13);
            this.ciSellerName.TabIndex = 81;
            // 
            // ciHand
            // 
            this.ciHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciHand.Location = new System.Drawing.Point(881, 305);
            this.ciHand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciHand.Name = "ciHand";
            this.ciHand.Size = new System.Drawing.Size(50, 15);
            this.ciHand.TabIndex = 61;
            this.ciHand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(867, 388);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 82;
            this.label11.Text = "Description:";
            // 
            // ciKilos
            // 
            this.ciKilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciKilos.Location = new System.Drawing.Point(750, 299);
            this.ciKilos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciKilos.Name = "ciKilos";
            this.ciKilos.Size = new System.Drawing.Size(91, 22);
            this.ciKilos.TabIndex = 60;
            this.ciKilos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ciDescription
            // 
            this.ciDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ciDescription.Location = new System.Drawing.Point(868, 406);
            this.ciDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ciDescription.Name = "ciDescription";
            this.ciDescription.Size = new System.Drawing.Size(206, 80);
            this.ciDescription.TabIndex = 83;
            this.ciDescription.Click += new System.EventHandler(this.ciDescription_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Hand2.Properties.Resources.rsz_1265247_200;
            this.pictureBox3.Location = new System.Drawing.Point(983, 253);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 59;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Hand2.Properties.Resources.rsz_11642_200;
            this.pictureBox2.Location = new System.Drawing.Point(880, 253);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(695, 458);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(117, 23);
            this.btnSendMail.TabIndex = 85;
            this.btnSendMail.Text = "Send Message";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hand2.Properties.Resources.rsz_122592_200;
            this.pictureBox1.Location = new System.Drawing.Point(771, 253);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditCar
            // 
            this.btnEditCar.Image = global::Hand2.Properties.Resources.rsz_7706;
            this.btnEditCar.Location = new System.Drawing.Point(813, 452);
            this.btnEditCar.Name = "btnEditCar";
            this.btnEditCar.Size = new System.Drawing.Size(32, 34);
            this.btnEditCar.TabIndex = 87;
            this.btnEditCar.UseVisualStyleBackColor = true;
            this.btnEditCar.Click += new System.EventHandler(this.btnEditCar_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(2, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 424);
            this.panel1.TabIndex = 45;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(58, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(574, 120);
            this.label3.TabIndex = 0;
            this.label3.Text = "No Results";
            this.label3.Visible = false;
            // 
            // ciPictureBox
            // 
            this.ciPictureBox.Location = new System.Drawing.Point(723, 62);
            this.ciPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.ciPictureBox.Name = "ciPictureBox";
            this.ciPictureBox.Size = new System.Drawing.Size(321, 180);
            this.ciPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ciPictureBox.TabIndex = 75;
            this.ciPictureBox.TabStop = false;
            // 
            // mainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1086, 494);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnEditCar);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.ciDescription);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ciSellerName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ciColor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ciGasType);
            this.Controls.Add(this.ciLabelGasType);
            this.Controls.Add(this.ciPictureBox);
            this.Controls.Add(this.ciPrice);
            this.Controls.Add(this.ciAddDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ciYear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ciCarType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ciVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ciCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ciGear);
            this.Controls.Add(this.ciHand);
            this.Controls.Add(this.ciKilos);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1102, 533);
            this.MinimumSize = new System.Drawing.Size(1102, 510);
            this.Name = "mainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Page";
            this.Load += new System.EventHandler(this.mainPage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainPage_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainPage_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainPage_MouseClick);
            this.MouseEnter += new System.EventHandler(this.mainPage_MouseEnter);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ciPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fltrCompany;
        private System.Windows.Forms.ComboBox fltrType;
        private System.Windows.Forms.TextBox fltrVersion;
        private System.Windows.Forms.TextBox fltrYear;
        private System.Windows.Forms.TextBox fltrHand;
        private System.Windows.Forms.ComboBox fltrGear;
        private System.Windows.Forms.ComboBox fltrGas;
        private System.Windows.Forms.TextBox fltrKilometers;
        private System.Windows.Forms.TextBox fltrFromPrice;
        private System.Windows.Forms.TextBox fltrToPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ciYear;
        private System.Windows.Forms.Label ciAddDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ciPrice;
        private System.Windows.Forms.Label ciCarType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ciLabelGasType;
        private System.Windows.Forms.Label ciVersion;
        private System.Windows.Forms.Label ciGasType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ciCompany;
        private System.Windows.Forms.Label ciColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label ciGear;
        private System.Windows.Forms.Label ciSellerName;
        private System.Windows.Forms.Label ciHand;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label ciKilos;
        private System.Windows.Forms.Label ciDescription;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEditCar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ciPictureBox;
        public System.Windows.Forms.Label label3;
    }
}