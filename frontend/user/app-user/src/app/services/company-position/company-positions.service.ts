import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiEndpoints } from 'src/app/api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class CompanyPositionsService {

  private apiUrl = ApiEndpoints.baseUrl + 'careerMaps/1/companyPositions';

  constructor(private http: HttpClient) {}

  getCompanyPositions(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
