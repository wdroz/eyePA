using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace EyePA
{
    /// <summary>
    /// Singleton de configuration
    ///   -> permet d'avoir une base de connaissance des paramètres de configuration
    /// </summary>
    class Config
    {

        private static Config instance = null;
        private String defaultPath;
        private int imagesW;
        private int imagesH;
        private int numberOfImages;
        private System.Windows.Input.Key keyActivation;
        private System.Windows.Input.Key keyZoom;
        private System.Windows.Input.Key keyUnzoom;
        private System.Windows.Input.Key keyScroll;
        private double zoomMaxValueReference;
        private double srcReference;
        private double speedScroll;
        private double zoomForce;
        private double coefImageSizeZoom;
        private QueryHandlerAbstract queryHandler;
        private string[] listDossiers;

        public string[] ListDossiers
        {
            get { return listDossiers; }
            set { listDossiers = value; }
        }

        public double ZoomMaxValueReference
        {
            get { return zoomMaxValueReference; }
            set { zoomMaxValueReference = value; }
        }
        public double SrcReference
        {
            get { return srcReference; }
            set { srcReference = value; }
        }

        public double SpeedScroll
        {
            get { return speedScroll; }
            set { speedScroll = value; }
        }
        public double ZoomForce
        {
            get { return zoomForce; }
            set { zoomForce = value; }
        }

        public double CoefImageSizeZoom
        {
            get { return coefImageSizeZoom; }
            set { coefImageSizeZoom = value; }
        }

        public System.Windows.Input.Key KeyZoom
        {
            get { return keyZoom; }
            set { keyZoom = value; }
        }

        public System.Windows.Input.Key KeyUnzoom
        {
            get { return keyUnzoom; }
            set { keyUnzoom = value; }
        }
       

        public System.Windows.Input.Key KeyScroll
        {
            get { return keyScroll; }
            set { keyScroll = value; }
        }

        public System.Windows.Input.Key KeyActivation
        {
            get { return keyActivation; }
            set { keyActivation = value; }
        }

        public String DefaultPath
        {
            get { return Environment.ExpandEnvironmentVariables(this.defaultPath); }
            set { this.defaultPath = value; }
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
            this.keyActivation = System.Windows.Input.Key.A;
            this.keyZoom = System.Windows.Input.Key.W;
            this.keyUnzoom = System.Windows.Input.Key.S;
            this.keyScroll = System.Windows.Input.Key.D;
            this.queryHandler = null;

            this.zoomMaxValueReference = Double.Parse(ConfigurationManager.AppSettings["ZoomMaxValueReference"], CultureInfo.InvariantCulture);
            this.srcReference = Double.Parse(ConfigurationManager.AppSettings["srcReference"], CultureInfo.InvariantCulture);
            this.speedScroll = Double.Parse(ConfigurationManager.AppSettings["speedScroll"], CultureInfo.InvariantCulture);
            this.zoomForce = Double.Parse(ConfigurationManager.AppSettings["zoomForce"], CultureInfo.InvariantCulture);
            this.coefImageSizeZoom = Double.Parse(ConfigurationManager.AppSettings["coefImageSizeZoom"], CultureInfo.InvariantCulture);
            this.imagesW = Int32.Parse(ConfigurationManager.AppSettings["imagesW"]);
            this.imagesH = Int32.Parse(ConfigurationManager.AppSettings["imagesH"]);
            this.numberOfImages = Int32.Parse(ConfigurationManager.AppSettings["numberOfImages"]);
            this.listDossiers = ConfigurationManager.AppSettings["listDossiers"].Split('\n');
            List<String> list = new List<String>();
            
            
            foreach(string item in listDossiers)
            {
                string filteredItem = item.Replace("\r","").Replace("\n","").Replace("\t", "");
                filteredItem = Environment.ExpandEnvironmentVariables(filteredItem);
                if(System.IO.Directory.Exists(filteredItem))
                {
                    list.Add(filteredItem);
                }

            }
            this.listDossiers = list.ToArray();

            int i = 0;
            foreach (string item in listDossiers)
            {
                System.Console.Out.WriteLine("" + ++i + " item : " + item);
            }


        }
        /// <summary>
        /// Simple Singleton...
        /// </summary>
        /// <returns>Instance de Config</returns>
        public static Config getInstance()
        {
            if(instance == null)
            {
                instance = new Config();
            }
            return instance;
        }

        /// <summary>
        /// Retourne une instance unique de QueryHandler en fonction des paramètres du fichier de configuration
        /// </summary>
        /// <param name="eventManager"></param>
        /// <returns></returns>
        public QueryHandlerAbstract getQueryHandler(EventManager eventManager)
        {
            if(queryHandler == null)
            {
                String name = ConfigurationManager.AppSettings["device"];
                queryHandler = selectDevice(name, eventManager);
                if(queryHandler == null)
                {
                    string defaultDevice = ConfigurationManager.AppSettings["defaultDevice"];
                    queryHandler = selectDevice(defaultDevice, eventManager);
                }
                return queryHandler;
            }
            queryHandler.EventManager = eventManager;
            return queryHandler;
        }

        private QueryHandlerAbstract selectDevice(string name, EventManager eventManager)
        {
            if(name.Equals("Tobii"))
            {
                System.Console.Out.WriteLine("*** Selected Tobii ***");
                return new QueryHandler(eventManager);
            }
            else if(name.Equals("Tribe"))
            {
                System.Console.Out.WriteLine("*** Selected Tribe ***");
                return new QueryHandlerTribe(eventManager);
            }
            else
            {
                return null;
            }
        }


    }
}
