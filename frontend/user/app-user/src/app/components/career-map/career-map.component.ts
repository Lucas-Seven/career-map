import { Component, OnInit } from '@angular/core';
import { CompanyPositionsService } from 'src/app/services/company-position/company-positions.service';
import { RequirementsService } from 'src/app/services/requirement/requirements.service';

@Component({
  selector: 'app-career-map',
  templateUrl: './career-map.component.html',
  styleUrls: ['./career-map.component.css']
})
export class CareerMapComponent implements OnInit {

  companyPositions: any[] = [];
  selectedPosition: any;
  requirements: any[] = [];

  constructor(
    private companyPositionsService: CompanyPositionsService,
    private requirementsService: RequirementsService
  ) { }

  ngOnInit() {
    this.companyPositionsService.getCompanyPositions().subscribe(data => {
      this.companyPositions = data.companyPositions;
    });
  }

  selectPosition(companyPositionId: number) {
    this.requirementsService.getRequirements(companyPositionId).subscribe(data => {
      this.requirements = data.requirements;
    });
  }
}
