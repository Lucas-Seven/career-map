import { Component, OnInit } from '@angular/core';
import { TestsService } from 'src/app/services/test/tests.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  
  testId: number = 0;
  test: any = {};
  testAnswers: any = [];
  testLoaded: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private testsService: TestsService
  ) {
    this.route.paramMap.subscribe(params => {
      this.testId = Number(params.get('id'));
    });
  }

  ngOnInit() {
    this.testsService.getTest(this.testId).subscribe(data => {
      this.test = data;
      this.testLoaded = true;
    });
  }

  navigateToCareerMap() {
    this.router.navigateByUrl('/career-map');
  }
}
