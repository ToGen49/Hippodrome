import { Test, TestingModule } from '@nestjs/testing';
import { CapteurService } from './capteur.service';

describe('CapteurService', () => {
  let service: CapteurService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [CapteurService],
    }).compile();

    service = module.get<CapteurService>(CapteurService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
