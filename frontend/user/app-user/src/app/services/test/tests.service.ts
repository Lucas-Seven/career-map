import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiEndpoints } from 'src/app/api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class TestsService {

  constructor(private http: HttpClient) { }

  getTests(requirementId: number) {
    return this.http.get<any>(ApiEndpoints.baseUrl + `tests/requirements/${requirementId}`);
  }

  getTest(testId: number){
    return this.http.get<any>(ApiEndpoints.baseUrl + `tests/${testId}`);
  }

  postAnswers(answers: any[]){
    return this.http.post(ApiEndpoints.baseUrl + `​testAnswers​/insertall`, answers);
  }  
}
