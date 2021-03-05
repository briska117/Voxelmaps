import { TestBed } from '@angular/core/testing';

import { VoxelmapMapService } from './voxelmap-map.service';

describe('VoxelmapMapService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VoxelmapMapService = TestBed.get(VoxelmapMapService);
    expect(service).toBeTruthy();
  });
});
