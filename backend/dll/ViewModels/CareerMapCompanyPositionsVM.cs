﻿namespace dll.ViewModels
{
    public class CareerMapCompanyPositionsVM
    {
        public CareerMapVM CareerMap { get; set; }

        public ICollection<CompanyPositionVM>? CompanyPositions { get; set; }
        public CareerMapCompanyPositionsVM()
        {
            CompanyPositions = new List<CompanyPositionVM>();
        }
    }
}
