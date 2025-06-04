import { Test, TestingModule } from '@nestjs/testing';
import { HippodromeService } from './hippodrome.service';

describe('HippodromeService', () => {
  let service: HippodromeService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [HippodromeService],
    }).compile();

    service = module.get<HippodromeService>(HippodromeService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
