import { TestBed, inject } from '@angular/core/testing';

import { LivroDetailService } from './livro-detail.service';

describe('LivroDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LivroDetailService]
    });
  });

  it('should be created', inject([LivroDetailService], (service: LivroDetailService) => {
    expect(service).toBeTruthy();
  }));
});
