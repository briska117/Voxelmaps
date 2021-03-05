import { TestBed } from '@angular/core/testing';

import { VoxelmapRequestService } from './voxelmap-request.service';

describe('VoxelmapRequestService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VoxelmapRequestService = TestBed.get(VoxelmapRequestService);
    expect(service).toBeTruthy();
  });
});
