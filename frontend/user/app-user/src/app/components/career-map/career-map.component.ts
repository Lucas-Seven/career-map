import { Component, OnInit } from '@angular/core';
import { CompanyPositionsService } from 'src/app/services/company-position/company-positions.service';

@Component({
  selector: 'app-career-map',
  templateUrl: './career-map.component.html',
  styleUrls: ['./career-map.component.css']
})
export class CareerMapComponent implements OnInit {

  companyPositions: any[] = [];

  constructor(private companyPositionsService: CompanyPositionsService) { }

  ngOnInit() {
    this.companyPositionsService.getCompanyPositions().subscribe(data => {
      this.companyPositions = data.companyPositions;
    });
  }

}
