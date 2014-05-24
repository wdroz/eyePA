﻿using System;
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
            //TODO test si on utilise tobii ou l'autre machin
            if(queryHandler == null)
            {
                queryHandler = new QueryHandler(eventManager);
            }
            return queryHandler;
        }


    }
}
