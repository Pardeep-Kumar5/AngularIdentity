import { TestBed } from '@angular/core/testing';

import { JwtActivateguardService } from './jwt-activateguard.service';

describe('JwtActivateguardService', () => {
  let service: JwtActivateguardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtActivateguardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
