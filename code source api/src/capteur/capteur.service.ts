import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Capteur } from './capteur.entity';
import { Repository } from 'typeorm';

@Injectable()
export class CapteurService {
    constructor(
        @InjectRepository(Capteur)
        private CapteurRepository: Repository<Capteur>,
    ){}

    findAll(): Promise<Capteur[]>{
        return this.CapteurRepository.find({ relations: ['hippodrome']});
    }

    create(capteur: Capteur): Promise<Capteur> {
        return this.CapteurRepository.save(capteur);
    }
}
