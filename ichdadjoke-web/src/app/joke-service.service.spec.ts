import { TestBed } from '@angular/core/testing';

import { JokeServiceService } from './joke-service.service';

describe('JokeServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JokeServiceService = TestBed.get(JokeServiceService);
    expect(service).toBeTruthy();
  });
});
