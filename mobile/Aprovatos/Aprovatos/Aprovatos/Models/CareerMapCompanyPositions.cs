﻿using System.Collections.Generic;

namespace Aprovatos.Models
{
    public class CareerMapCompanyPositions
    {
        public CareerMap CareerMap { get; set; }

        public ICollection<CompanyPosition> CompanyPositions { get; set; }
        public CareerMapCompanyPositions()
        {
            CompanyPositions = new List<CompanyPosition>();
        }
    }
}
