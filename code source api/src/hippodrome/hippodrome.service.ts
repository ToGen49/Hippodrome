import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { Hippodrome } from './hippodrome.entity';

@Injectable()
export class HippodromeService {
    constructor(
        @InjectRepository(Hippodrome)
        private HippodromeRepository: Repository<Hippodrome>,
    ){}

    findAll(): Promise<Hippodrome[]> {
        return this.HippodromeRepository.find();
    }

    create(hippodrome: Hippodrome): Promise<Hippodrome> {
        return this.HippodromeRepository.save(hippodrome)
    }
}
