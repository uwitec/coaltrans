using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coal.ViewModel
{
    public class CoalTransModel
    {

        #region Properties

        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public int County
        {
            get;
            set;
        }

        public string CountyName
        {
            get;
            set;
        }

        public int Province
        {
            get;
            set;
        }

        public string ProvinceName
        {
            get;
            set;
        }

        public int City
        {
            get;
            set;
        }

        public string CityName
        {
            get;
            set;
        }

        public string ZipCode
        {
            get;
            set;
        }

        public int CoalType
        {
            get;
            set;
        }

        public string CoalTypeName
        {
            get;
            set;
        }

        public int Category
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }

        public DateTime CreatedOn
        {
            get;
            set;
        }

        public DateTime ValidDate
        {
            get;
            set;
        }

        public string WholesaleDes
        {
            get;
            set;
        }

        public string ShipDes
        {
            get;
            set;
        }

        public float Volatility
        {
            get;
            set;
        }

        public float GrainSize
        {
            get;
            set;
        }

        public string GrainSizeDes
        {
            get;
            set;
        }

        public float AshContent
        {
            get;
            set;
        }

        public float SurfurContent
        {
            get;
            set;
        }

        public float WaterContent
        {
            get;
            set;
        }

        public float CalorificPower
        {
            get;
            set;
        }

        public int TransType
        {
            get;
            set;
        }
        #endregion
    }
}
