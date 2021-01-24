using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Word= Microsoft.Office.Interop.Word;



namespace diagramms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private аква_паркEntities1 _context = new аква_паркEntities1();
       
        public MainWindow()
        {
            InitializeComponent();
            chartpayments.ChartAreas.Add(new ChartArea("main"));

            var currentSeries = new Series("payments")
            {
                IsValueShownAsLabel = true
            };
            chartpayments.Series.Add(currentSeries);

            ComboUsers.ItemsSource = _context.Билет.ToList();
            COMBOCHARTTYPES.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
        }

        private void UpdateChart(object sender,SelectionChangedEventArgs e)
        {
            if(ComboUsers.SelectedItem is Билет currentUser && COMBOCHARTTYPES.SelectedItem is SeriesChartType currentType)
            {
                Series currentSeries = chartpayments.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();


                var categorieslist = _context.Клиент.ToList();
                foreach(var cathegory in categorieslist)
                {
                    currentSeries.Points.AddXY(cathegory.Код_клиента, _context.Заказ.ToList().Where(p => p.Билет== currentUser && p.Клиент== cathegory).Sum(p => p.Код_клиента * p.Код_заказа));
                }
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var allUsers = _context.Клиент.ToList().OrderBy(p => p.Код_клиента).ToList();

            var application = new Excel.Application();
            application.SheetsInNewWorkbook = allUsers.Count();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);


            for (int i = 0; i < allUsers.Count(); i++)
            {
                int startRowIndex = 1;
                Excel.Worksheet worksheet = application.Worksheets.Item[i + 1];
                worksheet.Name=allUsers[i].Код_клиента+allUsers[i].Фамилия;

                worksheet.Cells[1][startRowIndex] = "Код типа";
                worksheet.Cells[2][startRowIndex] = "Название товара";
                worksheet.Cells[3][startRowIndex] = "Цена";
                worksheet.Cells[4][startRowIndex] = "Количество";
                worksheet.Cells[5][startRowIndex] = "Стоимость";


                startRowIndex++;

                var usersCategories = allUsers[i].Заказ.GroupBy(p => p.Билет).OrderBy(p => p.Key.Код_заказа);

                foreach (var groupCategory in usersCategories)
                {
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[5][startRowIndex]];
                    headerRange.Merge();
                    headerRange.Value = groupCategory.Key.Код_заказа;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.Font.Italic = true;

                    startRowIndex++;

                    foreach (var payment in groupCategory)
                    {
                        worksheet.Cells[1][startRowIndex] = payment.Код_клиента;
                        worksheet.Cells[2][startRowIndex] = payment.Код_заказа;
                        worksheet.Cells[3][startRowIndex] = payment.Дата_оформления;
                        worksheet.Cells[4][startRowIndex] = payment.Код_клиента;

                        worksheet.Cells[5][startRowIndex].Formula = $"=C{startRowIndex}*D{startRowIndex}";

                        worksheet.Cells[3][startRowIndex].NumberFormat =
                            worksheet.Cells[3][startRowIndex].NumberFormat = "## ###,00";

                        startRowIndex++;
                    }

                    Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[4][startRowIndex]];
                    sumRange.Merge();
                    sumRange.Value = "Итого:";
                    sumRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    worksheet.Cells[5][startRowIndex].Formula = $"=SUM(E{startRowIndex - groupCategory.Count()}:" + $"E{startRowIndex - 1})";

                    sumRange.Font.Bold = worksheet.Cells[5][startRowIndex].Font.Bold = true;
                    worksheet.Cells[5][startRowIndex].NumberFormat = "## ###,00";

                    startRowIndex++;

                    Excel.Range rangeBorder = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[5][startRowIndex - 1]];
                    rangeBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                        rangeBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                        rangeBorder.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                        rangeBorder.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                        rangeBorder.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                        rangeBorder.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
                        rangeBorder.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                }
                application.Visible = true;
            }
        }

        private void Export_Word_Click(object sender, RoutedEventArgs e)
        {
            var allUsers = _context.Билет.ToList();
            var allCategories = _context.Клиент.ToList();

            var application = new Word.Application();
            Word.Document document = application.Documents.Add();

            foreach (var user in allUsers)
            {
                Word.Paragraph userParagrapth = document.Paragraphs.Add();
                Word.Range userRange = userParagrapth.Range;
                userRange.Text = user.Код_заказа + " " + user.Код_сотрудника;
                userParagrapth.set_Style("Обычный");
                userRange.InsertParagraphAfter();

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, allCategories.Count() + 1, 3);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Иконка";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "Категория";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Сумма расходов";

                paymentsTable.Rows[1].Range.Bold = 1;
                paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                for (int i = 0; i < allCategories.Count(); i++)
                {
                    var currentCategory = allCategories[i];

                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    Word.InlineShape imageShape = cellRange.InlineShapes.AddPicture(AppDomain.CurrentDomain.BaseDirectory + "\\Assets\\" + currentCategory.icon);
                    imageShape.Width = imageShape.Height = 40;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = currentCategory.телефон;

                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = user.Заказ.ToList().Where(p => p.Код_клиента == currentCategory.Код_клиента).Sum(p => p.Код_заказа * p.Код_клиента).ToString("N2") + "руб";
                }
                Заказ maxPayment = user.Заказ.OrderByDescending(p => p.Код_заказа * p.Код_клиента).FirstOrDefault();

                if (maxPayment != null)
                {
                    Word.Paragraph maxPaymentParagraph = document.Paragraphs.Add();
                    Word.Range maxPaymentRange = maxPaymentParagraph.Range;
                    maxPaymentRange.Text = $"Самый дорогостоящий платеж - {maxPayment.Дата_оформления} за {(maxPayment.Код_заказа * maxPayment.Код_клиента).ToString("N2")} ";
                    maxPaymentRange.set_Style("Выделенная цитата");
                    maxPaymentRange.Font.Color = Word.WdColor.wdColorDarkRed;
                    maxPaymentRange.InsertParagraphAfter();
                }

                Заказ minPayment = user.Заказ.OrderBy(p => p.Код_заказа * p.Код_клиента).FirstOrDefault();

                if (minPayment != null)
                {
                    Word.Paragraph minPaymentParagraph = document.Paragraphs.Add();
                    Word.Range minPaymentRange = minPaymentParagraph.Range;
                    minPaymentRange.Text = $"Самый дешевый платеж - {minPayment.Дата_оформления} за {(minPayment.Код_заказа * minPayment.Код_клиента).ToString("N2")} ";
                    minPaymentRange.set_Style("Выделенная цитата");
                    minPaymentRange.Font.Color = Word.WdColor.wdColorDarkGreen;
                    minPaymentRange.InsertParagraphAfter();
                }

                if (user != allUsers.LastOrDefault())
                    document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);

            }
            application.Visible = true;

            document.SaveAs(@"D:\для с#\программные решения для бизнеса\diagramms\diagramms\packages\Test.docx");
            document.SaveAs(@"D:\для с#\программные решения для бизнеса\diagramms\diagramms\packages\Test.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }
    }
}
