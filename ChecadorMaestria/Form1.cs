using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChecadorMaestria
{
    
    public partial class Form1 : Form
    {
        public Dictionary<int, EstudianteMaestria> EstudiantesMaestria;
        public Utilidades Herramientas = new Utilidades();

        public Form1()
        {
            
            InitializeComponent();
     
        }

        // agregar los estudiantes al control para visualizarlos
        public void CargarAlumnos ( TreeView Destino )
        {
            // cargar total de asistencias
            foreach (EstudianteMaestria est in EstudiantesMaestria.Values)
            {
                Destino.Nodes.Add(est.Est_Id.ToString(),"[ "+ est.Est_Id + " ]   "+ est.Est_Nombre);
                Destino.Nodes[est.Est_Id.ToString()].Nodes.Add("Asistencias Totales [ " + est.Asst_Total.Count + " ]");
                foreach (Asistencia a in est.Asst_Total)
                    Destino.Nodes[est.Est_Id.ToString()].Nodes[0].Nodes.Add(a.Asistencia_FechaEntrada + "    " + a.Asistencia_HoraEntrada + "    " +Convert.ToInt32( a.Asistencia_Entrada) ); 
            }

            // cargar asistencias agrupadas
            foreach (EstudianteMaestria est in EstudiantesMaestria.Values)
            {
               // Destino.Nodes.Add(est.Est_Id.ToString(), est.Est_Nombre);
                Destino.Nodes[est.Est_Id.ToString()].Nodes.Add("Asistencias Agrupadas [ " + est.Asst_Agrupada.Count + " ]");
                foreach (Asistencia a in est.Asst_Agrupada)
                    Destino.Nodes[est.Est_Id.ToString()].Nodes[1].Nodes.Add(a.Asistencia_FechaEntrada + "    " + a.Asistencia_HoraEntrada + "    " + a.Asistencia_HoraSalida +"    "+ Convert.ToInt32(a.Asistencia_Salida));
            }

            // cargar asistencias validas
            foreach (EstudianteMaestria est in EstudiantesMaestria.Values)
            {
                // Destino.Nodes.Add(est.Est_Id.ToString(), est.Est_Nombre);
                Destino.Nodes[est.Est_Id.ToString()].Nodes.Add("Asistencias Validas [ " + est.Asst_Valida.Count + " ]");
                foreach (Asistencia a in est.Asst_Valida)
                    Destino.Nodes[est.Est_Id.ToString()].Nodes[2].Nodes.Add(a.Asistencia_FechaEntrada + "    " + a.Asistencia_HoraEntrada + "    " + a.Asistencia_HoraSalida + "    " + Convert.ToInt32(a.Asistencia_Salida));
            }


        }

        public void GraficarAsistenciaAlumno ( EstudianteMaestria est)
        {

        }

        public void CargarDatos( string ruta )
        {
            EstudiantesMaestria = EstudianteMaestria.ProcesarClaves(ruta);
            EstudianteMaestria.ProcesarRegistros(ruta, EstudiantesMaestria);
            EstudianteMaestria.AgruparFechas(EstudiantesMaestria);
            EstudianteMaestria.ValidadAsistencia(EstudiantesMaestria);
            EstudianteMaestria.ProcesarFechas(EstudiantesMaestria, EstudianteMaestria.Lista_Valid);
            EstudianteMaestria.GraficarTodosEn(EstudiantesMaestria, EstudianteMaestria.Lista_Valid, chart1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
                try
                {
                    inicarGrafico(0);
                    string ruta = this.Herramientas.ConseguirUltimoArchivo();
                    CargarDatos(ruta);
                    // EstudianteMaestria.GraficarEstEn(EstudiantesMaestria[101], EstudianteMaestria.Lista_Valid, chart1 );
                    CargarAlumnos(this.Arbol_VistaEstudiantes);
                }
                catch (Exception ex)
                {
                    ;
                }
        }

        private void Arbol_VistaEstudiantes_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
          
        }

        private void Opt_Nuevo_Click(object sender, EventArgs e)
        {
          if(  this.Herramientas.CargarArchivo() )
            {
                BorrarEstado();
                inicarGrafico(0);
                CargarDatos(Herramientas.RutaArchivoActual);
                CargarAlumnos(this.Arbol_VistaEstudiantes);
            }
        }

        public void BorrarEstado()
        {
            Arbol_VistaEstudiantes.Nodes.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();
        }

        public void BorrarGrafico()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
        }

        public void BorrarTitulos()
        {
            this.chart1.Titles.Clear();
        }

        public void inicarGrafico( int tipo )
        {
            string s = "A1";
            chart1.ChartAreas.Add(s);
            chart1.ChartAreas[s].AxisX.Interval = 1;

            chart1.ChartAreas[s].AxisX.TitleFont = new Font(this.Font, FontStyle.Bold);
            chart1.ChartAreas[s].AxisY.TitleFont = new Font(this.Font, FontStyle.Bold);

            if (tipo == 1)
            {
                // vista general 
                chart1.ChartAreas[s].AxisX.Title = "Id. Estudiante";
                chart1.ChartAreas[s].AxisY.Title = "Horas";
            }

            else
            {
                // vista especifica
                chart1.ChartAreas[s].AxisX.Title = "Dias";
                chart1.ChartAreas[s].AxisY.Title = "Horas";
            }
            
        }

        private void Opt_Ultimo_Click(object sender, EventArgs e)
        {
            BorrarEstado();
            inicarGrafico(0);
            CargarDatos(Herramientas.ConseguirUltimoArchivo());
            CargarAlumnos(this.Arbol_VistaEstudiantes);
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarGrafico();
            BorrarTitulos();
            inicarGrafico(1);
            FijarTitulo("Vista General");
            CargarDatos(Herramientas.ConseguirUltimoArchivo());
            
        }

        private void destinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // seleccionar el fonder donde se ha de guardar la informacion
            this.Herramientas.FijarDestinoGuardar();
        }

        // guardar la imagen de grafico que contiene el control actual
        private void Opt_SvGrafica_Click(object sender, EventArgs e)
        {
            this.Herramientas.GuardarGraficaActual(this.chart1, Arbol_VistaEstudiantes.SelectedNode.Text);
        }

        // guardar las imagenes de grafico de todos los estudiantes 
        private void Opt_Todos_Click(object sender, EventArgs e)
        {
            string rutaGeneral = Herramientas.ConseguirUltimoDirectr() + this.Herramientas.DirSaveSuper;

            if (!Directory.Exists(rutaGeneral))
                Directory.CreateDirectory(rutaGeneral);

            foreach (EstudianteMaestria est in this.EstudiantesMaestria.Values)
            {
                this.BorrarGrafico();
                this.inicarGrafico(0);
                FijarTitulo("[ " + est.Est_Id.ToString() + " ]" + est.Est_Nombre);
                EstudianteMaestria.GraficarEstEn(est, EstudianteMaestria.Lista_Valid, chart1, monthCalendar1.SelectionRange );
                this.Refresh();
                Thread.Sleep(100);
                Herramientas.SalvarEn(rutaGeneral + est.Est_Nombre + ".png", chart1);
            }

            Herramientas.MensajeInfor(Herramientas.SaveAllOkStat);

        }

        // fijar el titulo principal de la grafica
        public void FijarTitulo(string TituloEntrada)
        {
            if (chart1.Titles.Count == 0)
            {

                this.chart1.Titles.Add(TituloEntrada);
                this.chart1.Titles[0].Font = new Font(this.Font, FontStyle.Bold);
                this.chart1.Titles[0].Text = TituloEntrada;
            }
            else
            {
                chart1.Titles.Clear();
                this.chart1.Titles.Add(TituloEntrada);
                this.chart1.Titles[0].Font = new Font(this.Font, FontStyle.Bold);
                this.chart1.Titles[0].Text = TituloEntrada;
            }
        }

        private void vistasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void todosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        // guardar todos los reportes
        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaGeneral = Herramientas.ConseguirUltimoDirectr() + this.Herramientas.DirSaveSuper;

            if (!Directory.Exists(rutaGeneral))
                Directory.CreateDirectory(rutaGeneral);

            foreach (EstudianteMaestria est in this.EstudiantesMaestria.Values)
            {               
                this.BorrarGrafico();
                this.inicarGrafico(0);

                FijarTitulo("[ " + est.Est_Id.ToString() + " ]" + est.Est_Nombre);

                EstudianteMaestria.GraficarEstEn(est, EstudianteMaestria.Lista_Valid, chart1, monthCalendar1.SelectionRange);

                MemoryStream imagenGuardada = new MemoryStream();
                chart1.SaveImage(imagenGuardada, ChartImageFormat.Jpeg);
                Image mn = Image.FromStream(imagenGuardada);

                this.Refresh();
                Thread.Sleep(100);              
                Herramientas.GuardarPDFActualEn(mn,rutaGeneral,est);
            }

            Herramientas.MensajeInfor(Herramientas.SaveAllOkStat);
            
        }

        private void Arbol_VistaEstudiantes_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            try
            {
                string clave = e.Node.Text;
                string[] Clave = clave.Split(' ');
                int Id = Convert.ToInt32(Clave[1]);
                SelectionRange rangoFecha = monthCalendar1.SelectionRange;

                if (chart1.Series.Count == 0)
                {
                    EstudianteMaestria.GraficarEstEn(EstudiantesMaestria[Id], EstudianteMaestria.Lista_Valid, chart1,rangoFecha);
                    FijarTitulo(clave);
                }
                else
                {
                    BorrarGrafico();
                    BorrarTitulos();
                    inicarGrafico(0);
                    EstudianteMaestria.GraficarEstEn(EstudiantesMaestria[Id], EstudianteMaestria.Lista_Valid, chart1,rangoFecha);
                    FijarTitulo(clave);
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           
        }

        private void seleccionadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
