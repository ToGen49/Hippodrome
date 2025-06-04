import { Test, TestingModule } from '@nestjs/testing';
import { ArrosageController } from './arrosage.controller';

describe('ArrosageController', () => {
  let controller: ArrosageController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [ArrosageController],
    }).compile();

    controller = module.get<ArrosageController>(ArrosageController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
