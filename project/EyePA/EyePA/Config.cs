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

        public String DefaultPath
        {
            get { return this.defaultPath; }
        }

        public int ImagesW
        {
            get { return this.imagesW; }
        }

        public int ImagesH
        {
            get { return this.imagesH; }
        }

        private Config()
        {
            this.defaultPath = "C:\\images";
            this.imagesW = 200;
            this.imagesH = 150;
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
