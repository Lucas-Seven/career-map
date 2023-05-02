import { Component, OnInit } from '@angular/core';
import { CompanyPositionsService } from 'src/app/services/company-position/company-positions.service';
import { RequirementsService } from 'src/app/services/requirement/requirements.service';
import { TestsService } from 'src/app/services/test/tests.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-career-map',
  templateUrl: './career-map.component.html',
  styleUrls: ['./career-map.component.css']
})
export class CareerMapComponent implements OnInit {

  companyPositions: any[] = [];
  selectedPosition: any;
  requirements: any[] = [];
  tests: any[] = [];

  title = 'appBootstrap';  
  closeResult: string = '';

  constructor(
    private companyPositionsService: CompanyPositionsService,
    private requirementsService: RequirementsService,
    private testsService: TestsService,
    private modalService: NgbModal
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

  selectRequirements(requirementId: number){
    this.testsService.getTests(requirementId).subscribe(data => {
      this.tests = data.tests;
    });
  }

  open(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
}
