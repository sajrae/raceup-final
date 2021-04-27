using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raceup_Autocare
{
    
    class CreateROProperties
    {
        // Customer Information
        private String roNumber;
        private String fName;
        private String lName;
        private String contactNum;
        private String address;
        private String carBrand;
        private String cardModel;
        private String plateNo;
        private String chasisNo;
        private String engineNo;

        // Service information
        private string description;
        private String hours;
        private String servicePrice;
        private string totalPrice;

        public string RoNumber { get => roNumber; set => roNumber = value; }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string ContactNum { get => contactNum; set => contactNum = value; }
        public string Address { get => address; set => address = value; }
        public string CarBrand { get => carBrand; set => carBrand = value; }
        public string CardModel { get => cardModel; set => cardModel = value; }
        public string PlateNo { get => plateNo; set => plateNo = value; }
        public string ChasisNo { get => chasisNo; set => chasisNo = value; }
        public string EngineNo { get => engineNo; set => engineNo = value; }
        public string Description { get => description; set => description = value; }
        public string Hours { get => hours; set => hours = value; }
        public string ServicePrice { get => servicePrice; set => servicePrice = value; }
        public string TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
