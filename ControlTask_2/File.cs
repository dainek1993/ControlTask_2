using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTask_2
{
    class File
    {
        public File(string fileDescription)
        {
            string baseFileData = fileDescription.Split(';')[0];
            Extension = baseFileData.Split('(')[0];
            sizeStr = baseFileData.Split('(')[1].Split(')')[0];
            SizeInBytes = GetBytes();
        }
        public string Extension { get; private set; }
        public long SizeInBytes { get; private set; }
        private string sizeStr;
        public virtual void Print()
        {
            Console.WriteLine("Extension: " + Extension);
            Console.WriteLine("Size: " + SizeInBytes);
        }

        private long GetBytes()
        {
            long digit = 0;
            char[] sizeInChars = sizeStr.Split('B')[0].ToCharArray();
            if (char.IsDigit(sizeInChars[sizeInChars.Length - 1]) == false)
            {
                sizeInChars[sizeInChars.Length - 1] = '\0';
                
            }
            digit = long.Parse(new string(sizeInChars));
            switch (sizeStr[sizeStr.Length - 2])
            {
                case 'G':
                    digit *= 1000000000;
                    break;
                case 'K':
                    digit *= 1000;
                    break;
                case 'M':
                    digit *= 1000000;
                    break;
            }

            return digit;
        }
    }

    class TextFile : File
    {
        public TextFile(string fileeDescription) : base(fileeDescription)
        {
            Content = fileeDescription.Split(';')[1];
        }

        public string Content { get; private set; }

        public override void Print()
        {
            Console.WriteLine("TextFile:");
            base.Print();
            Console.WriteLine("Content: " + Content);
        }
    }

    class Movie : File, IGraphicsFile
    {
        public Movie(string fileeDescription) : base(fileeDescription)
        {
            Resolution = fileeDescription.Split(';')[1];
            Duration = fileeDescription.Split(';')[2];
        }

        public string Resolution { get;}
        public string Duration { get; }

        public override void Print()
        {
            Console.WriteLine("Movie:");
           base.Print();
            Console.WriteLine("Resolution: " + Resolution);
            Console.WriteLine("Duration  " + Duration);
        }
    }

    class Image : File, IGraphicsFile
    {
        public Image(string fileeDescription) : base(fileeDescription)
        {
            resolution = fileeDescription.Split(';')[1];
        }
        private string resolution;

        public string Resolution => resolution;

        public override void Print()
        {
            Console.WriteLine("Image:");
            base.Print();
            Console.WriteLine("Resolution: " + Resolution);
        }
    }

    interface IGraphicsFile
    {
        string Resolution { get;} 
    }
}
