import { Test, TestingModule } from '@nestjs/testing';
import { MesuresTerrainController } from './mesures_terrain.controller';

describe('MesuresTerrainController', () => {
  let controller: MesuresTerrainController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [MesuresTerrainController],
    }).compile();

    controller = module.get<MesuresTerrainController>(MesuresTerrainController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
