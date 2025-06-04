import { Test, TestingModule } from '@nestjs/testing';
import { MesuresTerrainService } from './mesures_terrain.service';

describe('MesuresTerrainService', () => {
  let service: MesuresTerrainService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [MesuresTerrainService],
    }).compile();

    service = module.get<MesuresTerrainService>(MesuresTerrainService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
