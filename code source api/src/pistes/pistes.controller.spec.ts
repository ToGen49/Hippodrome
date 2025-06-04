import { Test, TestingModule } from '@nestjs/testing';
import { PistesController } from './pistes.controller';

describe('PistesController', () => {
  let controller: PistesController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [PistesController],
    }).compile();

    controller = module.get<PistesController>(PistesController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
