import { Component, OnInit } from '@angular/core';
import { TestsService } from 'src/app/services/test/tests.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  
  testId: number = 1;
  test: any = {};
  testAnswers: any = [];

  constructor(
    private testsService: TestsService
  ) { }

  ngOnInit() {
    this.testsService.getTest(this.testId).subscribe(data => {
      this.test = data;
    });
  }  
}
