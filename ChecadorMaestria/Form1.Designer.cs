namespace ChecadorMaestria
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
            this.Menu_Herramientas = new System.Windows.Forms.MenuStrip();
            this.Opt_Archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.Opt_Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.Opt_Recientes = new System.Windows.Forms.ToolStripMenuItem();
            this.Opt_Ultimo = new System.Windows.Forms.ToolStripMenuItem();
            this.Opt_Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.Opt_SvGrafica = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Opt_Todos = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Arbol_VistaEstudiantes = new System.Windows.Forms.TreeView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Menu_Herramientas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_Herramientas
            // 
            this.Menu_Herramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opt_Archivo,
            this.Opt_Guardar,
            this.directoriosToolStripMenuItem,
            this.vistasToolStripMenuItem});
            this.Menu_Herramientas.Location = new System.Drawing.Point(0, 0);
            this.Menu_Herramientas.Name = "Menu_Herramientas";
            this.Menu_Herramientas.Size = new System.Drawing.Size(1228, 24);
            this.Menu_Herramientas.TabIndex = 0;
            this.Menu_Herramientas.Text = "menuStrip1";
            // 
            // Opt_Archivo
            // 
            this.Opt_Archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opt_Nuevo,
            this.Opt_Recientes,
            this.Opt_Ultimo});
            this.Opt_Archivo.Name = "Opt_Archivo";
            this.Opt_Archivo.Size = new System.Drawing.Size(60, 20);
            this.Opt_Archivo.Text = "&Archivo";
            // 
            // Opt_Nuevo
            // 
            this.Opt_Nuevo.Name = "Opt_Nuevo";
            this.Opt_Nuevo.Size = new System.Drawing.Size(152, 22);
            this.Opt_Nuevo.Text = "&Nuevo";
            this.Opt_Nuevo.Click += new System.EventHandler(this.Opt_Nuevo_Click);
            // 
            // Opt_Recientes
            // 
            this.Opt_Recientes.Name = "Opt_Recientes";
            this.Opt_Recientes.Size = new System.Drawing.Size(152, 22);
            this.Opt_Recientes.Text = "&Recientes";
            // 
            // Opt_Ultimo
            // 
            this.Opt_Ultimo.Name = "Opt_Ultimo";
            this.Opt_Ultimo.Size = new System.Drawing.Size(152, 22);
            this.Opt_Ultimo.Text = "&Ultimo";
            this.Opt_Ultimo.Click += new System.EventHandler(this.Opt_Ultimo_Click);
            // 
            // Opt_Guardar
            // 
            this.Opt_Guardar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opt_SvGrafica,
            this.Opt_Todos,
            this.kToolStripMenuItem});
            this.Opt_Guardar.Name = "Opt_Guardar";
            this.Opt_Guardar.Size = new System.Drawing.Size(61, 20);
            this.Opt_Guardar.Text = "G&uardar";
            // 
            // Opt_SvGrafica
            // 
            this.Opt_SvGrafica.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionadosToolStripMenuItem,
            this.todosToolStripMenuItem1});
            this.Opt_SvGrafica.Name = "Opt_SvGrafica";
            this.Opt_SvGrafica.Size = new System.Drawing.Size(187, 22);
            this.Opt_SvGrafica.Text = "Imagenes De Graficas";
            this.Opt_SvGrafica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Opt_SvGrafica.Click += new System.EventHandler(this.Opt_SvGrafica_Click);
            // 
            // seleccionadosToolStripMenuItem
            // 
            this.seleccionadosToolStripMenuItem.Name = "seleccionadosToolStripMenuItem";
            this.seleccionadosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.seleccionadosToolStripMenuItem.Text = "Seleccionados";
            this.seleccionadosToolStripMenuItem.Click += new System.EventHandler(this.seleccionadosToolStripMenuItem_Click);
            // 
            // todosToolStripMenuItem1
            // 
            this.todosToolStripMenuItem1.Name = "todosToolStripMenuItem1";
            this.todosToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.todosToolStripMenuItem1.Text = "Todos";
            this.todosToolStripMenuItem1.Click += new System.EventHandler(this.todosToolStripMenuItem1_Click);
            // 
            // Opt_Todos
            // 
            this.Opt_Todos.Name = "Opt_Todos";
            this.Opt_Todos.Size = new System.Drawing.Size(187, 22);
            this.Opt_Todos.Text = "&Todos";
            this.Opt_Todos.Click += new System.EventHandler(this.Opt_Todos_Click);
            // 
            // kToolStripMenuItem
            // 
            this.kToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionadoToolStripMenuItem,
            this.todosToolStripMenuItem});
            this.kToolStripMenuItem.Name = "kToolStripMenuItem";
            this.kToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.kToolStripMenuItem.Text = "Reportes Completos";
            // 
            // seleccionadoToolStripMenuItem
            // 
            this.seleccionadoToolStripMenuItem.Name = "seleccionadoToolStripMenuItem";
            this.seleccionadoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.seleccionadoToolStripMenuItem.Text = "Seleccionado";
            // 
            // todosToolStripMenuItem
            // 
            this.todosToolStripMenuItem.Name = "todosToolStripMenuItem";
            this.todosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.todosToolStripMenuItem.Text = "Todos";
            this.todosToolStripMenuItem.Click += new System.EventHandler(this.todosToolStripMenuItem_Click);
            // 
            // directoriosToolStripMenuItem
            // 
            this.directoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.destinoToolStripMenuItem});
            this.directoriosToolStripMenuItem.Name = "directoriosToolStripMenuItem";
            this.directoriosToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.directoriosToolStripMenuItem.Text = "Directorios";
            // 
            // destinoToolStripMenuItem
            // 
            this.destinoToolStripMenuItem.Name = "destinoToolStripMenuItem";
            this.destinoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.destinoToolStripMenuItem.Text = "Destino";
            this.destinoToolStripMenuItem.Click += new System.EventHandler(this.destinoToolStripMenuItem_Click);
            // 
            // vistasToolStripMenuItem
            // 
            this.vistasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem});
            this.vistasToolStripMenuItem.Name = "vistasToolStripMenuItem";
            this.vistasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.vistasToolStripMenuItem.Text = "Vistas";
            this.vistasToolStripMenuItem.Click += new System.EventHandler(this.vistasToolStripMenuItem_Click);
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.generalToolStripMenuItem.Text = "General";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Arbol_VistaEstudiantes);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 572);
            this.panel1.TabIndex = 2;
            // 
            // Arbol_VistaEstudiantes
            // 
            this.Arbol_VistaEstudiantes.Location = new System.Drawing.Point(3, 3);
            this.Arbol_VistaEstudiantes.Name = "Arbol_VistaEstudiantes";
            this.Arbol_VistaEstudiantes.Size = new System.Drawing.Size(272, 395);
            this.Arbol_VistaEstudiantes.TabIndex = 3;
            this.Arbol_VistaEstudiantes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Arbol_VistaEstudiantes_AfterSelect_1);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(28, 410);
            this.monthCalendar1.MaxSelectionCount = 365;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(284, 30);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(936, 569);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 601);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Menu_Herramientas);
            this.MainMenuStrip = this.Menu_Herramientas;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Menu_Herramientas.ResumeLayout(false);
            this.Menu_Herramientas.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_Herramientas;
        private System.Windows.Forms.ToolStripMenuItem Opt_Archivo;
        private System.Windows.Forms.ToolStripMenuItem Opt_Nuevo;
        private System.Windows.Forms.ToolStripMenuItem Opt_Recientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem Opt_Ultimo;
        private System.Windows.Forms.ToolStripMenuItem Opt_Guardar;
        private System.Windows.Forms.ToolStripMenuItem Opt_SvGrafica;
        private System.Windows.Forms.ToolStripMenuItem Opt_Todos;
        private System.Windows.Forms.ToolStripMenuItem directoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem destinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vistasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TreeView Arbol_VistaEstudiantes;
    }
}

