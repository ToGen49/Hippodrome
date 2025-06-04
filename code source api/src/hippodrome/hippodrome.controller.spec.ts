import { Test, TestingModule } from '@nestjs/testing';
import { HippodromeController } from './hippodrome.controller';

describe('HippodromeController', () => {
  let controller: HippodromeController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [HippodromeController],
    }).compile();

    controller = module.get<HippodromeController>(HippodromeController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
