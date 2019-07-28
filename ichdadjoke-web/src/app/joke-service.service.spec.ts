import { TestBed } from '@angular/core/testing';

import { JokeService } from './joke-service.service';

describe('JokeServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JokeService = TestBed.get(JokeService);
    expect(service).toBeTruthy();
  });
});
