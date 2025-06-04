import { Test, TestingModule } from '@nestjs/testing';
import { MesuresMeteoController } from './mesures_meteo.controller';

describe('MesuresMeteoController', () => {
  let controller: MesuresMeteoController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [MesuresMeteoController],
    }).compile();

    controller = module.get<MesuresMeteoController>(MesuresMeteoController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
