using System;
using System.Collections.Generic;
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
using System.IO;
using Ionic.Zip;

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = TextBox.Text + "\\" ;
            DirectoryInfo dirInfo = new DirectoryInfo(FilePath);
            DirectoryInfo[] list = dirInfo.GetDirectories("*", SearchOption.AllDirectories);
            var list2 = new HashSet<string> { };
            string baseName = dirInfo.Name;

            //Console.WriteLine(baseName);
            for (int i = 0; i < list.Length; i++)
                {
                    list2.Add(list[i].Name.Split(' ').First());

                }
            foreach (var val in list2)
            {
               // Console.WriteLine(baseName + ' ' + val);
                var zipFile = FilePath + "\\" + baseName + ' ' + val + ".cbz";
                



                using (ZipFile zip = new ZipFile())
                {
                    


                    for (int i = 0; i < list.Length; i++)
                        {
                            string fileloc = @"" + list[i].FullName + "\\";
                        //Console.WriteLine(fileloc);

                       // Console.WriteLine(list[i].Name.Split(' ').First() + "||" + list.Length + "||" + val + "||" + i);
                            if (list[i].Name.Split(' ').First().Equals(val))
                            {
                            zip.AddDirectory(fileloc, list[i].Name);
                               



                            }


                        }
                    zip.Save(zipFile);
                    
                        //    Console.WriteLine(fileloc);
                       
                    }

                }
                
                

                }
            

            }


            




            
            



        }
    

