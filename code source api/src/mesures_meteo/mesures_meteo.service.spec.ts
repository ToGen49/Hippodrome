import { Test, TestingModule } from '@nestjs/testing';
import { MesuresMeteoService } from './mesures_meteo.service';

describe('MesuresMeteoService', () => {
  let service: MesuresMeteoService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [MesuresMeteoService],
    }).compile();

    service = module.get<MesuresMeteoService>(MesuresMeteoService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
