import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { Arrosage } from './arrosage.entity';

@Injectable()
export class ArrosageService {
    constructor(
        @InjectRepository(Arrosage)
        private ArrosageRepository: Repository<Arrosage>,
    ){}

    findAll(): Promise<Arrosage[]>{
        return this.ArrosageRepository.find({ relations: ['piste']});
    }

    create(arrosage: Arrosage): Promise<Arrosage> {
        return this.ArrosageRepository.save(arrosage);
    }
}

