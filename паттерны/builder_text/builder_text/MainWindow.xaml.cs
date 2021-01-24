using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace builder_text
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public class Text2
    {
       
        public ConsoleColor Color { get; internal set; } = ConsoleColor.White;

       
        public ConsoleColor BackgroundColor { get; internal set; } = ConsoleColor.Black;

      
        public bool Bold { get; internal set; } = false;

        public bool Italic { get; internal set; } = false;

        
        public bool Underline { get; internal set; } = false;

     
        public string Content { get; internal set; } = "";

        
        public int HeaderLevel { get; internal set; } = 0;


       
        public int Size { get; internal set; } = 12;

       
        public Text2(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            Content = content;
        }
        public string Print()
        {
            var mainTag = HeaderLevel == 0 ? "P" : $"H{HeaderLevel}";
            var formatedContent = $"<{mainTag} style=\"background-color: {BackgroundColor}; \">" +
                $"<FONT size=\"{Size}\" color=\"{Color}\">" +
                (Bold == true ? "<STRONG>" : "") +
                (Italic == true ? "<EM>" : "") +
                (Underline == true ? "<U>" : "") +
                Content +
                (Underline == true ? "</U>" : "") +
                (Italic == true ? "</EM>" : "") +
                (Bold == true ? "</STRONG>" : "") +
                $"</FONT></{mainTag}>";

            return formatedContent;
        }

        public override string ToString()
        {
            return Content;
        }
    }



        public static class TextBUILDER
        {
        public static Text2 Size(this Text2 text, int size)
        {
          
            const int MinFontSize = 6;
            const int MaxFontSize = 72;

            if (size <= MinFontSize)
            {
               
                text.Size = MinFontSize;
            }
            else if (size >= MaxFontSize)
            {
              
                text.Size = MaxFontSize;
            }
            else
            {
                
                text.Size = size;
            }

         
            return text;
        }

     
        public static Text2 Color(this Text2 text, ConsoleColor color)
        {
            
            text.Color = color;
            return text;
        }

       
        public static Text2 BackgroundColor(this Text2 text, ConsoleColor color)
        {
        
            text.BackgroundColor = color;
            return text;
        }

    
        public static Text2 Bold(this Text2 text, bool bold)
        {
            text.Bold = bold;
            return text;
        }

        
        public static Text2 Italic(this Text2 text, bool italic)
        {
            text.Italic = italic;
            return text;
        }

    
        public static Text2 Underline(this Text2 text, bool underline)
        {
         
            text.Underline = underline;
            return text;
        }

       
        public static Text2 HeaderLevel(this Text2 text, int headerLevel)
        {
            const int NormalText = 0;
            const int MinHeader = 6;

            if (headerLevel <= NormalText)
            {
                text.HeaderLevel = NormalText;
            }
            else if (headerLevel >= MinHeader)
            {
                text.HeaderLevel = MinHeader;
            }
            else
            {
                text.HeaderLevel = headerLevel;
            }

            return text;
        }
    }

    public partial class MainWindow : Window
    {
        internal string Text;
        internal string text;

        public MainWindow()
        {
            InitializeComponent();
           
          
        }

        public void button_1(object sender, RoutedEventArgs e)
        {
            foreach (string Row in File.ReadAllLines("2020.txt", Encoding.Default))
            {
                var row = new Text2(Row);
                row.Size(18)
                .Color(ConsoleColor.Red)
                .BackgroundColor(ConsoleColor.Black)
                .Bold(true)
                .Underline(true);
                var html = row.Print();
                data.Items.Add(Row);

            }
          
            string[] lines = System.IO.File.ReadAllLines("2020.txt");
            string[] lines2 = System.IO.File.ReadAllLines("2021.xml");
            var text = new MainWindow();
            int b = lines.GetHashCode();
            int bb = lines2.GetHashCode();
            red.Content = bb+" " + " "+ b ;

            //Text ler = new Text(text);
            //ler.fff(lines);
            //ler.floyd(lines2);
        }

      

        private void button2(object sender, RoutedEventArgs e)
        {
            System.IO.File.Move(@"D:\для с#\паттерны\builder_text\builder_text\bin\Debug\2020.txt", @"D:\для с#\паттерны\builder_text\builder_text\bin\Debug\2020.xml");
        }
    }
}
