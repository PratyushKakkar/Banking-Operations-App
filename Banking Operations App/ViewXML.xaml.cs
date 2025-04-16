using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xml;

namespace Banking_Operations_App
{
     /// <summary>
     /// Interaction logic for ViewXML.xaml
     /// </summary>
     public partial class ViewXML : Window
     {
          public ViewXML()
          {
               InitializeComponent();
          }

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {

           }

          public void DisplayHighlightedXml(XDocument xmlDoc)
          {
               rtbXMLData.Document.Blocks.Clear();
               Paragraph paragraph = new Paragraph();
               
               string xml = xmlDoc.ToString(); // Already formatted nicely

               foreach (var line in xml.Split('\n'))
               {
                    int i = 0;

                    while (i < line.Length)
                    {
                         if (line[i] == '<')
                         {
                              // Start of tag
                              int close = line.IndexOf('>', i);
                              if (close > i)
                              {
                                   string tag = line.Substring(i, close - i + 1);

                                   // Add opening angle bracket
                                   paragraph.Inlines.Add(new Run("<") { Foreground = Brushes.Gray });

                                   // Add tag name and contents
                                   string tagBody = tag.Substring(1, tag.Length - 2);
                                   paragraph.Inlines.Add(new Run(tagBody) { Foreground = Brushes.Blue });

                                   // Add closing angle bracket
                                   paragraph.Inlines.Add(new Run(">") { Foreground = Brushes.Gray });

                                   i = close + 1;
                              }
                              else
                              {
                                   // Just a dangling <
                                   paragraph.Inlines.Add(new Run("<") { Foreground = Brushes.Gray });
                                   i++;
                              }
                         }
                         else
                         {
                              // Text between tags
                              int nextTag = line.IndexOf('<', i);
                              string text = nextTag == -1 ? line.Substring(i) : line.Substring(i, nextTag - i);
                              paragraph.Inlines.Add(new Run(text.Trim()) { Foreground = Brushes.Black });
                              i = nextTag == -1 ? line.Length : nextTag;
                         }
                    }

                    paragraph.Inlines.Add(new LineBreak());
               }

               rtbXMLData.Document.Blocks.Add(paragraph);
          }
     }
}
