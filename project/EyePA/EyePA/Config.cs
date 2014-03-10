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

        public String DefaultPath
        {
            get { return this.defaultPath; }
        }

        private Config()
        {
            this.defaultPath = "C:\\images";
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
