import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyPositionsService {

  private apiUrl = 'https://localhost:7149/api/careerMaps/1/companyPositions';

  constructor(private http: HttpClient) {}

  getCompanyPositions(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
