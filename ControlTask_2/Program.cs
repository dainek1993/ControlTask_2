using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTask_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = @"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920х1080
Text:data.txt(12B); Another string
Text:data1.txt(7B); Yet another string
Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";

            string[] filesData = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            File[] files = new File[filesData.Length];

            for (int i = 0; i < filesData.Length; i++)
            {
                string fileDescription = filesData[i].Split(':')[1];
                switch (filesData[i].Split(':')[0])
                {
                    case "Text":
                        files[i] = new TextFile(fileDescription);
                        break;
                    case "Movie":
                        files[i] = new Movie(fileDescription);
                        break;
                    case "Image":
                        files[i] = new Image(fileDescription);
                        break;
                    default:
                        files[i] = new File(fileDescription);
                        break;
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i] is TextFile)
                {
                    files[i].Print();
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i] is Movie)
                {
                    files[i].Print();
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i] is Image)
                {
                    files[i].Print();
                }
            }
        }
    }
}
