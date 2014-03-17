using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePA
{
    class Config
    {

        private static Config instance = null;
        private String defaultPath;
        private int imagesW;
        private int imagesH;
        private int numberOfImages;

        public String DefaultPath
        {
            get { return this.defaultPath; }
        }

        public int ImagesW
        {
            get { return this.imagesW; }
            set { this.imagesW = value; }
        }

        public int ImagesH
        {
            get { return this.imagesH; }
            set { this.imagesH = value; }
        }
        public int NumberOfImages
        {
            get { return this.numberOfImages; }
        }

        private Config()
        {
            this.defaultPath = "C:\\images";
            this.imagesW = 200;
            this.imagesH = 150;
            this.numberOfImages = 5;
        }
        public static Config getInstance()
        {
            if(instance == null)
            {
                instance = new Config();
            }
            return instance;
        }

    }
}
