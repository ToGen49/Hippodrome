import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { Pistes } from './pistes.entity';

@Injectable()
export class PistesService {    
    constructor(
        @InjectRepository(Pistes)
        private PistesRepository: Repository<Pistes>,
    ){}

    findAll(): Promise<Pistes[]>{
        return this.PistesRepository.find({ relations: ['hippodrome', 'arrosage']});
    }

    create(pistes: Pistes): Promise<Pistes> {
        return this.PistesRepository.save(pistes);
    }
}

