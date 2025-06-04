import { Test, TestingModule } from '@nestjs/testing';
import { PistesService } from './pistes.service';

describe('PistesService', () => {
  let service: PistesService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [PistesService],
    }).compile();

    service = module.get<PistesService>(PistesService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
