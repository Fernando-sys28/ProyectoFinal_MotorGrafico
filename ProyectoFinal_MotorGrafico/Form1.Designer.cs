namespace ProyectoFinal_MotorGrafico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.RotarXScroll = new System.Windows.Forms.TrackBar();
            this.escalarScroll = new System.Windows.Forms.TrackBar();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.camaraYScroll = new System.Windows.Forms.TrackBar();
            this.traslationsZScroll = new System.Windows.Forms.TrackBar();
            this.camaraXScroll = new System.Windows.Forms.TrackBar();
            this.camaraZScroll = new System.Windows.Forms.TrackBar();
            this.RotarYScroll = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.labelFrames = new System.Windows.Forms.Label();
            this.buttonGuardarFrame = new System.Windows.Forms.Button();
            this.buttonReproducir = new System.Windows.Forms.Button();
            this.checkAnimAll = new System.Windows.Forms.CheckBox();
            this.checkReverse = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotarXScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalarScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraYScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsZScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraXScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraZScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotarYScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(290, 51);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(897, 664);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 556);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 57);
            this.button4.TabIndex = 5;
            this.button4.Text = "Rotar en XYZ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 326);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 40);
            this.button5.TabIndex = 6;
            this.button5.Text = "Cube";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(28, 372);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 40);
            this.button6.TabIndex = 7;
            this.button6.Text = "Cylinder";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(28, 418);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(107, 40);
            this.button7.TabIndex = 8;
            this.button7.Text = "Sphere";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(29, 510);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(107, 40);
            this.button8.TabIndex = 9;
            this.button8.Text = "Prisma pentagonal";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(28, 464);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(107, 40);
            this.button9.TabIndex = 10;
            this.button9.Text = "Cone";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // RotarXScroll
            // 
            this.RotarXScroll.BackColor = System.Drawing.Color.Black;
            this.RotarXScroll.Location = new System.Drawing.Point(290, 753);
            this.RotarXScroll.Margin = new System.Windows.Forms.Padding(2);
            this.RotarXScroll.Maximum = 360;
            this.RotarXScroll.Minimum = -360;
            this.RotarXScroll.Name = "RotarXScroll";
            this.RotarXScroll.RightToLeftLayout = true;
            this.RotarXScroll.Size = new System.Drawing.Size(897, 45);
            this.RotarXScroll.TabIndex = 11;
            this.RotarXScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RotarXScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.RotarXScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseMove);
            this.RotarXScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // escalarScroll
            // 
            this.escalarScroll.BackColor = System.Drawing.Color.Black;
            this.escalarScroll.Location = new System.Drawing.Point(1181, 51);
            this.escalarScroll.Margin = new System.Windows.Forms.Padding(2);
            this.escalarScroll.Maximum = 25;
            this.escalarScroll.Minimum = -25;
            this.escalarScroll.Name = "escalarScroll";
            this.escalarScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.escalarScroll.Size = new System.Drawing.Size(45, 664);
            this.escalarScroll.TabIndex = 12;
            this.escalarScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.escalarScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseDown);
            this.escalarScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseMove);
            this.escalarScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.escalarScroll_MouseUp);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Location = new System.Drawing.Point(28, 26);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(112, 44);
            this.btnBuscarArchivo.TabIndex = 13;
            this.btnBuscarArchivo.Text = "Open OBJ";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click_1);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(28, 86);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(152, 233);
            this.treeView1.TabIndex = 14;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // camaraYScroll
            // 
            this.camaraYScroll.BackColor = System.Drawing.Color.Black;
            this.camaraYScroll.Location = new System.Drawing.Point(1225, 51);
            this.camaraYScroll.Margin = new System.Windows.Forms.Padding(2);
            this.camaraYScroll.Maximum = 25;
            this.camaraYScroll.Minimum = -25;
            this.camaraYScroll.Name = "camaraYScroll";
            this.camaraYScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.camaraYScroll.Size = new System.Drawing.Size(45, 664);
            this.camaraYScroll.TabIndex = 16;
            this.camaraYScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.camaraYScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camaraYScroll_MouseDown);
            this.camaraYScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.camaraYScroll_MouseMove);
            this.camaraYScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.camaraYScroll_MouseUp);
            // 
            // traslationsZScroll
            // 
            this.traslationsZScroll.BackColor = System.Drawing.Color.Black;
            this.traslationsZScroll.Location = new System.Drawing.Point(1315, 51);
            this.traslationsZScroll.Margin = new System.Windows.Forms.Padding(2);
            this.traslationsZScroll.Maximum = 25;
            this.traslationsZScroll.Minimum = -25;
            this.traslationsZScroll.Name = "traslationsZScroll";
            this.traslationsZScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.traslationsZScroll.Size = new System.Drawing.Size(45, 664);
            this.traslationsZScroll.TabIndex = 17;
            this.traslationsZScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.traslationsZScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.traslationsZScroll_MouseDown);
            this.traslationsZScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.traslationsZScroll_MouseMove);
            this.traslationsZScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.traslationsZScroll_MouseUp);
            // 
            // camaraXScroll
            // 
            this.camaraXScroll.BackColor = System.Drawing.Color.Black;
            this.camaraXScroll.Location = new System.Drawing.Point(290, 710);
            this.camaraXScroll.Margin = new System.Windows.Forms.Padding(2);
            this.camaraXScroll.Maximum = 25;
            this.camaraXScroll.Minimum = -25;
            this.camaraXScroll.Name = "camaraXScroll";
            this.camaraXScroll.RightToLeftLayout = true;
            this.camaraXScroll.Size = new System.Drawing.Size(897, 45);
            this.camaraXScroll.TabIndex = 18;
            this.camaraXScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.camaraXScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camaraXScroll_MouseDown);
            this.camaraXScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.camaraXScroll_MouseMove);
            this.camaraXScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.camaraXScroll_MouseUp);
            // 
            // camaraZScroll
            // 
            this.camaraZScroll.BackColor = System.Drawing.Color.Black;
            this.camaraZScroll.Location = new System.Drawing.Point(1270, 51);
            this.camaraZScroll.Margin = new System.Windows.Forms.Padding(2);
            this.camaraZScroll.Maximum = 25;
            this.camaraZScroll.Minimum = -25;
            this.camaraZScroll.Name = "camaraZScroll";
            this.camaraZScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.camaraZScroll.Size = new System.Drawing.Size(45, 664);
            this.camaraZScroll.TabIndex = 19;
            this.camaraZScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.camaraZScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camaraZScroll_MouseDown);
            this.camaraZScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.camaraZScroll_MouseMove);
            this.camaraZScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.camaraZScroll_MouseUp);
            // 
            // RotarYScroll
            // 
            this.RotarYScroll.BackColor = System.Drawing.Color.Black;
            this.RotarYScroll.Location = new System.Drawing.Point(250, 51);
            this.RotarYScroll.Margin = new System.Windows.Forms.Padding(2);
            this.RotarYScroll.Maximum = 360;
            this.RotarYScroll.Minimum = -360;
            this.RotarYScroll.Name = "RotarYScroll";
            this.RotarYScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.RotarYScroll.Size = new System.Drawing.Size(45, 664);
            this.RotarYScroll.TabIndex = 20;
            this.RotarYScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RotarYScroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RotarYScroll_MouseDown);
            this.RotarYScroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RotarYScroll_MouseMove);
            this.RotarYScroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RotarYScroll_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(1202, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 120);
            this.label1.TabIndex = 21;
            this.label1.Text = "E\r\nS\r\nC\r\nA\r\nL\r\nA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(1248, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 160);
            this.label2.TabIndex = 22;
            this.label2.Text = "C\r\nA\r\nM\r\nA\r\nR\r\nA\r\n\r\nY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(1291, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 160);
            this.label3.TabIndex = 23;
            this.label3.Text = "C\r\nA\r\nM\r\nA\r\nR\r\nA\r\n\r\nZ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.Snow;
            this.label4.Location = new System.Drawing.Point(270, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 140);
            this.label4.TabIndex = 24;
            this.label4.Text = "R\r\nO\r\nT\r\nA\r\nR\r\n\r\nY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(1335, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 220);
            this.label5.TabIndex = 25;
            this.label5.Text = "T\r\nR\r\nA\r\nS\r\nL\r\nA\r\nD\r\nA\r\nR\r\n\r\nZ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(695, 729);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "CAMARA X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ForeColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(687, 777);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "ROTAR EN X";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(29, 618);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(81, 46);
            this.button10.TabIndex = 28;
            this.button10.Text = "Stop";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 695);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(61, 20);
            this.textBox1.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Snow;
            this.label8.Location = new System.Drawing.Point(26, 680);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "FOV:";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(29, 719);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(81, 43);
            this.button11.TabIndex = 31;
            this.button11.Text = "Change";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(290, 6);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(831, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.BackColor = System.Drawing.Color.Black;
            this.trackBar2.Location = new System.Drawing.Point(205, 51);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar2.Maximum = 360;
            this.trackBar2.Minimum = -360;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 664);
            this.trackBar2.TabIndex = 33;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseDown_1);
            this.trackBar2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseMove_1);
            this.trackBar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar2_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.ForeColor = System.Drawing.Color.Snow;
            this.label9.Location = new System.Drawing.Point(224, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 140);
            this.label9.TabIndex = 34;
            this.label9.Text = "R\r\nO\r\nT\r\nA\r\nR\r\n\r\nZ";
            // 
            // labelFrames
            // 
            this.labelFrames.AutoSize = true;
            this.labelFrames.Location = new System.Drawing.Point(631, 36);
            this.labelFrames.Name = "labelFrames";
            this.labelFrames.Size = new System.Drawing.Size(54, 13);
            this.labelFrames.TabIndex = 35;
            this.labelFrames.Text = "FRAMES:";
            // 
            // buttonGuardarFrame
            // 
            this.buttonGuardarFrame.Location = new System.Drawing.Point(115, 618);
            this.buttonGuardarFrame.Name = "buttonGuardarFrame";
            this.buttonGuardarFrame.Size = new System.Drawing.Size(75, 46);
            this.buttonGuardarFrame.TabIndex = 36;
            this.buttonGuardarFrame.Text = "Añadir Frame";
            this.buttonGuardarFrame.UseVisualStyleBackColor = true;
            this.buttonGuardarFrame.Click += new System.EventHandler(this.buttonGuardarFrame_Click);
            // 
            // buttonReproducir
            // 
            this.buttonReproducir.Location = new System.Drawing.Point(115, 669);
            this.buttonReproducir.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReproducir.Name = "buttonReproducir";
            this.buttonReproducir.Size = new System.Drawing.Size(61, 35);
            this.buttonReproducir.TabIndex = 37;
            this.buttonReproducir.Text = "PLAY";
            this.buttonReproducir.UseVisualStyleBackColor = true;
            this.buttonReproducir.Click += new System.EventHandler(this.buttonReproducir_Click);
            // 
            // checkAnimAll
            // 
            this.checkAnimAll.AutoSize = true;
            this.checkAnimAll.Enabled = false;
            this.checkAnimAll.Location = new System.Drawing.Point(115, 710);
            this.checkAnimAll.Name = "checkAnimAll";
            this.checkAnimAll.Size = new System.Drawing.Size(87, 17);
            this.checkAnimAll.TabIndex = 38;
            this.checkAnimAll.Text = "Animar todas";
            this.checkAnimAll.UseVisualStyleBackColor = true;
            // 
            // checkReverse
            // 
            this.checkReverse.AutoSize = true;
            this.checkReverse.Location = new System.Drawing.Point(115, 729);
            this.checkReverse.Name = "checkReverse";
            this.checkReverse.Size = new System.Drawing.Size(133, 17);
            this.checkReverse.TabIndex = 39;
            this.checkReverse.Text = "Animación en Reversa";
            this.checkReverse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1398, 829);
            this.Controls.Add(this.checkReverse);
            this.Controls.Add(this.checkAnimAll);
            this.Controls.Add(this.buttonReproducir);
            this.Controls.Add(this.buttonGuardarFrame);
            this.Controls.Add(this.labelFrames);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RotarYScroll);
            this.Controls.Add(this.camaraZScroll);
            this.Controls.Add(this.camaraXScroll);
            this.Controls.Add(this.traslationsZScroll);
            this.Controls.Add(this.camaraYScroll);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.escalarScroll);
            this.Controls.Add(this.RotarXScroll);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotarXScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalarScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraYScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traslationsZScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraXScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camaraZScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotarYScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TrackBar escalarScroll;
        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.TrackBar RotarXScroll;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TrackBar camaraYScroll;
        private System.Windows.Forms.TrackBar traslationsZScroll;
        private System.Windows.Forms.TrackBar camaraXScroll;
        private System.Windows.Forms.TrackBar camaraZScroll;
        private System.Windows.Forms.TrackBar RotarYScroll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelFrames;
        public System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonGuardarFrame;
        private System.Windows.Forms.Button buttonReproducir;
        private System.Windows.Forms.CheckBox checkAnimAll;
        private System.Windows.Forms.CheckBox checkReverse;
    }
}

