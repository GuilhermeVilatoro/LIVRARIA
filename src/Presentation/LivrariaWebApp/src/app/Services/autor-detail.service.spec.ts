import { TestBed, inject } from '@angular/core/testing';

import { AutorDetailService } from './autor-detail.service';

describe('AutorDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AutorDetailService]
    });
  });

  it('should be created', inject([AutorDetailService], (service: AutorDetailService) => {
    expect(service).toBeTruthy();
  }));
});
