using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raceup_Autocare
{
    
    class CreateROProperties
    {
        private String color;
        private String email;
        private String promise;
        private String drivers;
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
        private String mileAge;

        // Service information
        private List<String> serviceDescription;
        private List<int> serviceHours;
        private List<double> servicePrice;
        private List<double> serviceTotalPrice;

        // Parts information
        private List<String> itemCode;
        private List<String> itemName;
        private List<int> itemQuantity;
        private List<double> itemPrice;
        private List<double> itemTotalPrice;

        private String paymentMethod;
        private string customerRequest;
        private String grandTotal;

        public string ColorCar { get => color; set => color = value; }
        public string EmailAdd { get => email; set => email = value; }
        public string Promise { get => promise; set => promise = value; }
        public string Drivers { get => drivers; set => drivers = value; }

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
        public string MileAge { get => mileAge; set => mileAge = value; }
        public List<string> ServiceDescription { get => serviceDescription; set => serviceDescription = value; }
        public List<int> ServiceHours { get => serviceHours; set => serviceHours = value; }
        public List<double> ServicePrice { get => servicePrice; set => servicePrice = value; }
        public List<double> ServiceTotalPrice { get => serviceTotalPrice; set => serviceTotalPrice = value; }
        public List<string> ItemCode { get => itemCode; set => itemCode = value; }
        public List<string> ItemName { get => itemName; set => itemName = value; }
        public List<int> ItemQuantity { get => itemQuantity; set => itemQuantity = value; }
        public List<double> ItemPrice { get => itemPrice; set => itemPrice = value; }
        public List<double> ItemTotalPrice { get => itemTotalPrice; set => itemTotalPrice = value; }
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        public string CustomerRequest { get => customerRequest; set => customerRequest = value; }
        public string GrandTotal { get => grandTotal; set => grandTotal = value; }
    }
}
