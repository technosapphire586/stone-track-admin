using System;
using System.Collections.Generic;
using System.Text;

namespace StoneTrackAdmin.Models
{
    public class EditOrdersModel
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int RequestId { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public string District { get; set; }
        public string Nationality { get; set; }
        public string address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public bool PhotoFormRequest { get; set; }

        public int AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string CutomerAddressName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressType { get; set; }
        public int PinCode { get; set; }
        public string FormType { get; set; }
        //public StandardAffidavitModel StandardAffidavit { get; set; }
        //public AffidavitForMarriageOrDevorceModel AffidavitMarriageDevorce { get; set; }
        //public CasteCertificateModel CasteCertificate { get; set; }
        //public BirthCertificateModel BirthCertificate { get; set; }
        //public GiftCertificateModel GiftCertificate { get; set; }
        //public MarriageCertificateModel MarriageCertificate { get; set; }
        //public RentAgreementModel RentAgreement { get; set; }
        //public SalesPurchaseAgreementModel SalesPurchaseAgreement { get; set; }
        //public SettlementAgreementModel SettlementAgreement { get; set; }
        //public PowerOfAttonaryModel PowerOfAttonary { get; set; }
        //public PhotoFormRequestModel PhotoFormRequestM { get; set; }
        //public PoliceVerificationModel PoliceVerification { get; set; }
        //public AffidavitForchangeofNameModel AffidavitForChangeofName { get; set; }
        //public NonDisclosureAgreementModel NonDisclosureAgreement { get; set; }
        //public ServiceAgreementModel ServiceAgreement { get; set; }
        //public LastWillModel LastWill { get; set; }

    }
}
