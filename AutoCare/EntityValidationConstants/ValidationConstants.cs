namespace AutoCare.EntityValidationConstants
{
    public static class ValidationConstants
    {
        public static class Car
        {
            public const int BrandMaxLength = 50;
            public const int ModelMaxLength = 50;
            public const int RegistrationNumberMaxLength = 8;
            public const int YearOfManufactureMinValue = 1900;
            public const int YearOfManufactureMaxValue = 2100;
        }

        public static class OilServiceRecord
        {
            public const int OilViscosityMaxLength = 10;
            public const int OilAndFiltersBrandMaxLength = 200;
        }

        public static class BeltServiceRecord
        {
           public const int BeltsPumpBrandMaxLength = 200;
        }

        public static class CivilLiabilityInsurance
        {
            public const int InsuranceCompanyNameMaxLength = 50;
        }
    }
}
