import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiEndpoints } from 'src/app/api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class RequirementsService {

  constructor(private http: HttpClient) { }

  getRequirements(companyPositionId: number) {
    return this.http.get<any>(ApiEndpoints.baseUrl + `careerMaps/1/companyPositions/${companyPositionId}/requirements`);
  }
}
