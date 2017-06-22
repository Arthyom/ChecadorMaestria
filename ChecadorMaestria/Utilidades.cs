using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ChecadorMaestria
{
    public class Utilidades
    {
        public string RutaArchivoActual;
        string RutaArchivoUltimo;
        string RutaArchivoRecnts;

        public string RutaDirGuardado;
        public string RutaLastDirGuardado;

        StreamWriter EscritorRecientes;
        StreamWriter EscritorUltimo;
        StreamWriter EscritorLastDir;

        const string ErrorCargaDir = "No se ha seleccionado directorio para guardar imagenes de graficos";
        const string NoSelcDirSave = "Debe seleccionar directorio para guardar imagenes de grafico";
        public  string SaveAllOkStat = "Todos los registros se han salvado con exito";
        const string SaveActualOk  = "El registro se han salvado con exito";
        public string DirSaveSuper = @"\ImagenesGraficoAutomatica\";

        public          Utilidades              ( )
        {
            this.RutaArchivoRecnts = ".recnts.txt";
            this.RutaArchivoUltimo = ".lasts.txt";
            this.RutaLastDirGuardado = ".lastdir.txt";

            // crear archivos de rutas recientes si es que no existen ya
            if ( !Directory.Exists(this.RutaArchivoRecnts))
                EscritorRecientes = new StreamWriter(RutaArchivoRecnts,true);

            if ( !Directory.Exists(this.RutaArchivoUltimo))
                EscritorUltimo = new StreamWriter(RutaArchivoUltimo,true);

            if ( !Directory.Exists(this.RutaLastDirGuardado))
                EscritorLastDir = new StreamWriter(RutaLastDirGuardado,true);

              EscritorUltimo.Close();
              EscritorRecientes.Close();
              EscritorLastDir.Close();
        }


        public Boolean  CargarArchivo           ( )
        {
            OpenFileDialog d = new OpenFileDialog();
            if( d.ShowDialog() == DialogResult.OK)
            {
                // crear archivos de rutas recientes si es que no existen ya
                if (!Directory.Exists(this.RutaArchivoRecnts))
                    EscritorRecientes = new StreamWriter(RutaArchivoRecnts, true);

                if (!Directory.Exists(this.RutaArchivoUltimo))
                    EscritorUltimo = new StreamWriter(RutaArchivoUltimo);

                this.RutaArchivoActual = d.FileName;

                // agregar la ruta del archivo actual a los recientes
                EscritorRecientes.WriteLine(RutaArchivoActual);

                // agregar la ruta al archivo ultimo
                EscritorUltimo.WriteLine(RutaArchivoActual);

                EscritorUltimo.Close();
                EscritorRecientes.Close();

                return true;
            }

            return false;
        }

        public string   ConseguirUltimoArchivo  ( )
        {
            // leer el contenido del archivo ultimo, es decir la ultima ruta usada
            StreamReader lector = new StreamReader(this.RutaArchivoUltimo);

            string r = lector.ReadLine();

            lector.Close();

            return @r;
        }

        public string   ConseguirUltimoDirectr  ()  
        {
            // leer el contenido del archivo ultimo, es decir la ultima ruta usada
            StreamReader lector = new StreamReader(this.RutaLastDirGuardado);

            string r = lector.ReadLine();

            lector.Close();

            return @r+@"\";
        }

        public void     MensajeError            ( string Texto )
        {
            MessageBox.Show(Texto, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void     MensajeInfor            ( string Texto )
        {
            MessageBox.Show(Texto, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // guarda la imagen de la grafia mostrada en el control 
        public void     GuardarGraficaActual    ( Chart GraficoActual, string NombreEstudiante )
        {
            try
            {
                // guardar la imagenn de la grafica en la ruta indicada 
                // debe seguir el patron C://dir/c1/nombregrafico.png
                string NombreGrafico = this.ConseguirUltimoDirectr() + @"\"+ NombreEstudiante +".png";
                GraficoActual.SaveImage( NombreGrafico, ChartImageFormat.Png);
                MensajeInfor(SaveActualOk);
            }
            catch (Exception ex)
            {
                MensajeError(ErrorCargaDir);
            }
        }

        public void     FijarDestinoGuardar     ( )
        {
            FolderBrowserDialog carp = new FolderBrowserDialog();

            if (carp.ShowDialog() == DialogResult.OK)
            {
                string nuevaRuta = carp.SelectedPath;
                this.RutaDirGuardado = nuevaRuta;

                // guardar los directorios validos en archivos de texto
                this.EscritorLastDir = new StreamWriter(this.RutaLastDirGuardado );
                this.EscritorLastDir.WriteLine( nuevaRuta );
                this.EscritorLastDir.Close();
                
            }
            else
                MensajeInfor( NoSelcDirSave );
        }

        public void     SalvarEn                ( string rutaSalia, Chart OrigenGrafico )
        {
            OrigenGrafico.SaveImage(rutaSalia, ChartImageFormat.Png);
            //MensajeInfor(SaveActualOk);
        }

        public void    AgregarParrafo           ( string Parrafo, Document DocumentoPdfEntrada)
        {
            DocumentoPdfEntrada.Add(new Paragraph(Parrafo));
            DocumentoPdfEntrada.Add(Chunk.NEWLINE);
        }

        public void    AgregarImagen            ( Image ImgEntrada, Document DocEntrada)
        {
            ImgEntrada.Alignment = Element.ALIGN_LEFT;
            ImgEntrada.ScaleToFit(PageSize.LETTER.Width + 130, PageSize.LETTER.Height + 130);
            DocEntrada.Add(ImgEntrada);
        }

     
        // guardar pdf con informacion del estudiente y su grafico en la misma ruta de las imagenes
        public void   GuardarPDFActualEn        ( System.Drawing.Image imgGuardada , string rutaSalida, EstudianteMaestria EstEntrada )
        {
            // conseguir informacion
            string TituloDocumentoPdf;
            string RutaDocumentoPdf = rutaSalida+EstEntrada.Est_Nombre+".pdf";
            DateTime fechaCreacion = DateTime.Today;
            Image imgPdf = Image.GetInstance(imgGuardada, null, false);
           
            

            // crear un archivo pdf  de tamanio carta y una escritor de pdf
            Document    PdfSalida   = new Document(PageSize.LETTER.Rotate() );
            PdfWriter   PdfEscrtr   = PdfWriter.GetInstance( PdfSalida, new FileStream( RutaDocumentoPdf,FileMode.Create));

            // abrir documento para comenzar a agregar datos 
            PdfSalida.Open();

            // agregar informacion al documento
            AgregarParrafo( "Fecha de creacion del documento :  "+  fechaCreacion.ToString(), PdfSalida);
            AgregarImagen(imgPdf, PdfSalida);
            

            PdfSalida.Close();
            PdfEscrtr.Close();

        }

   


    }
}
