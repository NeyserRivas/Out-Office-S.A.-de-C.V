using System;
using System.Data;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;
using SistemaReservaSalas.Clases;
using SistemaReservaSalas.Clases.DAO;
using System.IO;
using System.Text;

namespace SistemaReservaSalas.Formularios
{
    /// <summary>
    /// Formulario para generar reportes del sistema
    /// Incluye reportes estadísticos y gráficos
    /// </summary>
    public partial class frmReportes : Form
    {
        private Usuario usuarioActual;
        private ReservaDAO reservaDAO;
        private SalaDAO salaDAO;
        private DataTable datosReporte;

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public frmReportes(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            reservaDAO = new ReservaDAO();
            salaDAO = new SalaDAO();
            ConfigurarFormulario();
        }

        /// <summary>
        /// Configura las propiedades iniciales del formulario
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.Text = "Generación de Reportes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1200, 700);

            // Configurar DateTimePickers
            dtpReporteDesde.Value = DateTime.Today.AddMonths(-1);
            dtpReporteHasta.Value = DateTime.Today;
            dtpReporteDesde.Format = DateTimePickerFormat.Short;
            dtpReporteHasta.Format = DateTimePickerFormat.Short;

            // Cargar salas en el ComboBox
            CargarSalas();

            // Configurar RadioButtons
            rbReservasPorFecha.Checked = true;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar Chart
            //ConfigurarGrafico();

            // Deshabilitar controles según tipo de reporte
            ActualizarControlesSegunTipo();
        }

        /// <summary>
        /// Carga las salas en el ComboBox
        /// </summary>
        private void CargarSalas()
        {
            try
            {
                DataTable dt = salaDAO.Listar();

                // Agregar opción "Todas"
                DataRow row = dt.NewRow();
                row["IdSala"] = 0;
                row["NombreSala"] = "Todas las salas";
                dt.Rows.InsertAt(row, 0);

                cmbSalaReporte.DataSource = dt;
                cmbSalaReporte.DisplayMember = "NombreSala";
                cmbSalaReporte.ValueMember = "IdSala";
                cmbSalaReporte.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura el DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.ReadOnly = true;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Configura el gráfico
        /// </summary>
        /*
        private void ConfigurarGrafico()
        {
            //TODO: Estos chartReportes dice q el nombre no existe en el contexto actual
            chartReporte.Series.Clear();
            chartReporte.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Categoría";
            area.AxisY.Title = "Valor";
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Interval = 1;
            chartReporte.ChartAreas.Add(area);

            chartReporte.Legends.Clear();
            //TODO: Legend tampoco funciona 
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Bottom;
            chartReporte.Legends.Add(legend);
        }
        */
        /// <summary>
        /// Actualiza los controles según el tipo de reporte seleccionado
        /// </summary>
        private void ActualizarControlesSegunTipo()
        {
            // Habilitar fechas para todos excepto historial
            dtpReporteDesde.Enabled = true;
            dtpReporteHasta.Enabled = true;

            // Sala solo para reporte de ingresos por sala
            cmbSalaReporte.Enabled = rbIngresosPorSala.Checked;

            // Responsable solo para historial
            txtBuscarResponsable.Enabled = rbHistorialReservas.Checked;
        }

        /// <summary>
        /// Eventos de cambio de tipo de reporte
        /// </summary>
        private void rbTipoReporte_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarControlesSegunTipo();
        }

        /// <summary>
        /// Genera el reporte según el tipo seleccionado
        /// </summary>
        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = dtpReporteDesde.Value.Date;
                DateTime hasta = dtpReporteHasta.Value.Date;

                // Validar fechas
                if (desde > hasta)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
                        "Fechas Inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                if (rbReservasPorFecha.Checked)
                {
                    GenerarReportePorFecha(desde, hasta);
                }
                else if (rbIngresosPorSala.Checked)
                {
                    GenerarReporteIngresosPorSala(desde, hasta);
                }
                else if (rbHistorialReservas.Checked)
                {
                    GenerarReporteHistorial(desde, hasta);
                }
                else if (rbOcupacionSalas.Checked)
                {
                    GenerarReporteOcupacion(desde, hasta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Genera reporte de reservas por fecha
        /// </summary>
        private void GenerarReportePorFecha(DateTime desde, DateTime hasta)
        {
            datosReporte = reservaDAO.ObtenerReportePorFecha(desde, hasta);
            dgvReporte.DataSource = datosReporte;

            // Formato de columnas
            if (dgvReporte.Columns["Fecha"] != null)
                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvReporte.Columns["TotalIngresos"] != null)
            {
                dgvReporte.Columns["TotalIngresos"].HeaderText = "Total Ingresos";
                dgvReporte.Columns["TotalIngresos"].DefaultCellStyle.Format = "C2";
            }

            if (dgvReporte.Columns["CantidadReservas"] != null)
                dgvReporte.Columns["CantidadReservas"].HeaderText = "Cantidad de Reservas";

            // Generar gráfico
            //GenerarGraficoReservasPorFecha();

            if (datosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para el período seleccionado.",
                    "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MostrarResumenReporte();
            }
        }

        /// <summary>
        /// Genera reporte de ingresos por sala
        /// </summary>
        private void GenerarReporteIngresosPorSala(DateTime desde, DateTime hasta)
        {
            datosReporte = reservaDAO.ObtenerIngresosPorSala(desde, hasta);
            dgvReporte.DataSource = datosReporte;

            // Formato de columnas
            if (dgvReporte.Columns["TotalIngresos"] != null)
            {
                dgvReporte.Columns["TotalIngresos"].HeaderText = "Total Ingresos";
                dgvReporte.Columns["TotalIngresos"].DefaultCellStyle.Format = "C2";
            }

            if (dgvReporte.Columns["TotalReservas"] != null)
                dgvReporte.Columns["TotalReservas"].HeaderText = "Total Reservas";

            // Generar gráfico
            //GenerarGraficoIngresosPorSala();

            if (datosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para el período seleccionado.",
                    "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MostrarResumenReporte();
            }
        }

        /// <summary>
        /// Genera reporte historial de reservas
        /// </summary>
        private void GenerarReporteHistorial(DateTime desde, DateTime hasta)
        {
            string responsable = txtBuscarResponsable.Text.Trim();

            // Usar el método de búsqueda con filtros
            int? idSala = null;
            string estado = "Todos";

            datosReporte = reservaDAO.BuscarConFiltros(desde, hasta, idSala, estado);

            // Filtrar por responsable si se especificó
            if (!string.IsNullOrEmpty(responsable))
            {
                DataView dv = datosReporte.DefaultView;
                dv.RowFilter = $"Responsable LIKE '%{responsable}%'";
                datosReporte = dv.ToTable();
            }

            dgvReporte.DataSource = datosReporte;

            // Formato de columnas
            if (dgvReporte.Columns["Fecha"] != null)
                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvReporte.Columns["Total"] != null)
                dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";

            if (datosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron reservas con los criterios especificados.",
                    "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Gráfico de estados
                //GenerarGraficoEstados();
            }
        }

        /// <summary>
        /// Genera reporte de ocupación de salas
        /// </summary>
        private void GenerarReporteOcupacion(DateTime desde, DateTime hasta)
        {
            datosReporte = reservaDAO.ObtenerOcupacionSalas(desde, hasta);
            dgvReporte.DataSource = datosReporte;

            // Formato de columnas
            if (dgvReporte.Columns["ReservasActivas"] != null)
                dgvReporte.Columns["ReservasActivas"].HeaderText = "Reservas Activas";

            if (dgvReporte.Columns["HorasTotales"] != null)
            {
                dgvReporte.Columns["HorasTotales"].HeaderText = "Total de Horas";
                dgvReporte.Columns["HorasTotales"].DefaultCellStyle.Format = "N2";
            }

            // Generar gráfico
            //GenerarGraficoOcupacion();

            if (datosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para el período seleccionado.",
                    "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MostrarResumenReporte();
            }
        }

        #region Generación de Gráficos

        /// <summary>
        /// Genera gráfico de reservas por fecha
        /// </summary>
        /// 
        /*
        private void GenerarGraficoReservasPorFecha()
        {
            chartReporte.Series.Clear();

            //TODO: Series no funciona
            Series series = new Series("Ingresos por Día");
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "Fecha";
            series.YValueMembers = "TotalIngresos";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "C0";

            chartReporte.Series.Add(series);
            chartReporte.DataSource = datosReporte;
            chartReporte.DataBind();

            chartReporte.ChartAreas[0].AxisX.Title = "Fecha";
            chartReporte.ChartAreas[0].AxisY.Title = "Ingresos ($)";
            chartReporte.Titles.Clear();
            chartReporte.Titles.Add("Ingresos por Fecha");
        }
        */
        /// <summary>
        /// Genera gráfico de ingresos por sala
        /// </summary>
        /*private void GenerarGraficoIngresosPorSala()
        {
            chartReporte.Series.Clear();

            Series series = new Series("Ingresos por Sala");
            series.ChartType = SeriesChartType.Bar;

            foreach (DataRow row in datosReporte.Rows)
            {
                string sala = row["Sala"].ToString();
                decimal ingresos = row["TotalIngresos"] != DBNull.Value
                    ? Convert.ToDecimal(row["TotalIngresos"])
                    : 0;

                DataPoint point = new DataPoint();
                point.AxisLabel = sala;
                point.YValues = new double[] { (double)ingresos };
                point.Label = ingresos.ToString("C0");
                series.Points.Add(point);
            }

            chartReporte.Series.Add(series);

            chartReporte.ChartAreas[0].AxisX.Title = "Sala";
            chartReporte.ChartAreas[0].AxisY.Title = "Ingresos ($)";
            chartReporte.Titles.Clear();
            chartReporte.Titles.Add("Ingresos por Sala");
        }
        */
        /// <summary>
        /// Genera gráfico de ocupación
        /// </summary>
        /// 
        /*
        private void GenerarGraficoOcupacion()
        {
            chartReporte.Series.Clear();

            Series series = new Series("Horas Ocupadas");
            series.ChartType = SeriesChartType.Pie;

            foreach (DataRow row in datosReporte.Rows)
            {
                string sala = row["Sala"].ToString();
                decimal horas = row["HorasTotales"] != DBNull.Value
                    ? Convert.ToDecimal(row["HorasTotales"])
                    : 0;

                if (horas > 0)
                {
                    DataPoint point = new DataPoint();
                    point.AxisLabel = sala;
                    point.YValues = new double[] { (double)horas };
                    point.Label = $"{sala}\n{horas:N1}h";
                    series.Points.Add(point);
                }
            }

            series.IsValueShownAsLabel = true;
            chartReporte.Series.Add(series);

            chartReporte.Titles.Clear();
            chartReporte.Titles.Add("Ocupación de Salas (Horas)");
        }
        */
        /// <summary>
        /// Genera gráfico de estados de reservas
        /// </summary>
        /*
        private void GenerarGraficoEstados()
        {
            chartReporte.Series.Clear();

            // Contar reservas por estado
            var estados = new System.Collections.Generic.Dictionary<string, int>();

            foreach (DataRow row in datosReporte.Rows)
            {
                string estado = row["Estado"].ToString();
                if (estados.ContainsKey(estado))
                    estados[estado]++;
                else
                    estados[estado] = 1;
            }

            Series series = new Series("Estados");
            series.ChartType = SeriesChartType.Doughnut;

            foreach (var kvp in estados)
            {
                DataPoint point = new DataPoint();
                point.AxisLabel = kvp.Key;
                point.YValues = new double[] { kvp.Value };
                point.Label = $"{kvp.Key}\n{kvp.Value}";
                series.Points.Add(point);
            }

            series.IsValueShownAsLabel = true;
            chartReporte.Series.Add(series);

            chartReporte.Titles.Clear();
            chartReporte.Titles.Add("Distribución por Estado");
        }
        */
        #endregion

        /// <summary>
        /// Muestra un resumen del reporte generado
        /// </summary>
        private void MostrarResumenReporte()
        {
            if (datosReporte == null || datosReporte.Rows.Count == 0)
                return;

            string resumen = "RESUMEN DEL REPORTE\n";
            resumen += "═══════════════════════════════════════\n\n";
            resumen += $"Total de registros: {datosReporte.Rows.Count}\n";

            // Calcular totales según el tipo de reporte
            if (rbReservasPorFecha.Checked || rbIngresosPorSala.Checked)
            {
                decimal totalIngresos = 0;
                int totalReservas = 0;

                foreach (DataRow row in datosReporte.Rows)
                {
                    if (row["TotalIngresos"] != DBNull.Value)
                        totalIngresos += Convert.ToDecimal(row["TotalIngresos"]);

                    if (datosReporte.Columns.Contains("CantidadReservas") &&
                        row["CantidadReservas"] != DBNull.Value)
                        totalReservas += Convert.ToInt32(row["CantidadReservas"]);
                    else if (datosReporte.Columns.Contains("TotalReservas") &&
                             row["TotalReservas"] != DBNull.Value)
                        totalReservas += Convert.ToInt32(row["TotalReservas"]);
                }

                resumen += $"Total de reservas: {totalReservas}\n";
                resumen += $"Ingresos totales: ${totalIngresos:F2}\n";

                if (totalReservas > 0)
                {
                    decimal promedio = totalIngresos / totalReservas;
                    resumen += $"Promedio por reserva: ${promedio:F2}\n";
                }
            }
            else if (rbOcupacionSalas.Checked)
            {
                decimal totalHoras = 0;
                int totalReservas = 0;

                foreach (DataRow row in datosReporte.Rows)
                {
                    if (row["HorasTotales"] != DBNull.Value)
                        totalHoras += Convert.ToDecimal(row["HorasTotales"]);

                    if (row["ReservasActivas"] != DBNull.Value)
                        totalReservas += Convert.ToInt32(row["ReservasActivas"]);
                }

                resumen += $"Total de reservas: {totalReservas}\n";
                resumen += $"Total de horas ocupadas: {totalHoras:F2}\n";

                if (totalReservas > 0)
                {
                    decimal promedio = totalHoras / totalReservas;
                    resumen += $"Promedio de horas por reserva: {promedio:F2}\n";
                }
            }

            resumen += $"\nPeríodo: {dtpReporteDesde.Value:dd/MM/yyyy} al {dtpReporteHasta.Value:dd/MM/yyyy}";

            MessageBox.Show(resumen, "Resumen del Reporte",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exporta el reporte a Excel (CSV)
        /// </summary>
        private void btnExportarExcel_Click_1(object sender, EventArgs e)
        {
            if (datosReporte == null || datosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Genere un reporte primero.",
                    "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Archivo CSV (*.csv)|*.csv|Archivo de Texto (*.txt)|*.txt";
                sfd.FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarACSV(sfd.FileName);

                    MessageBox.Show("Reporte exportado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Preguntar si desea abrir el archivo
                    if (MessageBox.Show("¿Desea abrir el archivo exportado?",
                        "Abrir Archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Exporta los datos a un archivo CSV
        /// </summary>
        private void ExportarACSV(string nombreArchivo)
        {
            StringBuilder sb = new StringBuilder();

            // Encabezados
            string[] columnas = new string[datosReporte.Columns.Count];
            for (int i = 0; i < datosReporte.Columns.Count; i++)
            {
                columnas[i] = datosReporte.Columns[i].ColumnName;
            }
            sb.AppendLine(string.Join(",", columnas));

            // Datos
            foreach (DataRow row in datosReporte.Rows)
            {
                string[] campos = new string[datosReporte.Columns.Count];
                for (int i = 0; i < datosReporte.Columns.Count; i++)
                {
                    string valor = row[i].ToString().Replace(",", ";"); // Evitar conflictos con el delimitador
                    campos[i] = $"\"{valor}\"";
                }
                sb.AppendLine(string.Join(",", campos));
            }

            File.WriteAllText(nombreArchivo, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Imprime el reporte
        /// </summary>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (datosReporte == null || datosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir. Genere un reporte primero.",
                    "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Generar documento de texto para imprimir
                string documento = GenerarDocumentoReporte();

                // Guardar temporalmente
                string tempFile = Path.Combine(Path.GetTempPath(), $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                File.WriteAllText(tempFile, documento);

                // Abrir para impresión
                System.Diagnostics.Process.Start(tempFile);

                MessageBox.Show("Documento generado. Use Ctrl+P para imprimir desde el visor.",
                    "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar documento: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera el documento del reporte para imprimir
        /// </summary>
        private string GenerarDocumentoReporte()
        {
            StringBuilder doc = new StringBuilder();

            doc.AppendLine("═══════════════════════════════════════════════════════════");
            doc.AppendLine("            OUT OFFICE S.A. DE C.V.");
            doc.AppendLine("              REPORTE DEL SISTEMA");
            doc.AppendLine("═══════════════════════════════════════════════════════════");
            doc.AppendLine();
            doc.AppendLine($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            doc.AppendLine($"Generado por: {usuarioActual.Nombre}");
            doc.AppendLine($"Período: {dtpReporteDesde.Value:dd/MM/yyyy} al {dtpReporteHasta.Value:dd/MM/yyyy}");
            doc.AppendLine();

            // Tipo de reporte
            string tipoReporte = "";
            if (rbReservasPorFecha.Checked) tipoReporte = "RESERVAS POR FECHA";
            else if (rbIngresosPorSala.Checked) tipoReporte = "INGRESOS POR SALA";
            else if (rbHistorialReservas.Checked) tipoReporte = "HISTORIAL DE RESERVAS";
            else if (rbOcupacionSalas.Checked) tipoReporte = "OCUPACIÓN DE SALAS";

            doc.AppendLine($"Tipo de Reporte: {tipoReporte}");
            doc.AppendLine("═══════════════════════════════════════════════════════════");
            doc.AppendLine();

            // Encabezados de columnas
            foreach (DataColumn col in datosReporte.Columns)
            {
                doc.Append(col.ColumnName.PadRight(20));
            }
            doc.AppendLine();
            doc.AppendLine(new string('-', datosReporte.Columns.Count * 20));

            // Datos
            foreach (DataRow row in datosReporte.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    doc.Append(item.ToString().PadRight(20));
                }
                doc.AppendLine();
            }

            doc.AppendLine();
            doc.AppendLine("═══════════════════════════════════════════════════════════");
            doc.AppendLine($"Total de registros: {datosReporte.Rows.Count}");
            doc.AppendLine("═══════════════════════════════════════════════════════════");

            return doc.ToString();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento al cargar el formulario
        /// </summary>
        private void frmReportes_Load(object sender, EventArgs e)
        {
            // Mensaje de bienvenida
            lblInfoReportes.Text = "Seleccione el tipo de reporte y haga clic en 'Generar Reporte'";
        }


        //TODO: No Tiene funcionalidad pero segun lo que he visto hay mett
        private void btnGrafico_Click(object sender, EventArgs e)
        {

        }

       
    }
}