import { TestBed } from '@angular/core/testing';

import { CompanyPositionsService } from './company-positions.service';

describe('CompanyPositionsService', () => {
  let service: CompanyPositionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompanyPositionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
