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

  submitAnswers(){
    // Create an array of test answers from the user's selections
    let answers = [];
    for (let i = 0; i < this.test.questionsAlternatives.length; i++) { 
      let question = this.test.questionsAlternatives[i];
      let answer = {
        answerId: 0,
        userId: 1,
        testId: this.test.testId,
        questionId: question.questionId,
        alternativeId: question.alternatives.alternativeId,
        dissertativeAnswer: ''
      };
      answers.push(answer);
    }

    // Send the test answers to the API
    this.testsService.postAnswers(answers).subscribe(response => {
      console.log(response);
      // Navigate to the career map page or display a success message
      this.navigateToCareerMap();
    }, error => {
      console.error(error);
      // Display an error message or take appropriate action
    });
  }
}
