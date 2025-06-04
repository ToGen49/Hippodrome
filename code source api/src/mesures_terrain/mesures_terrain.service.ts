import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { MesuresTerrain } from './mesures_terrain.entity';

@Injectable()
export class MesuresTerrainService {
    constructor(
        @InjectRepository(MesuresTerrain)
        private mesuresTerrainRepository: Repository<MesuresTerrain>
    ){}

    async findByType(type: string): Promise<any[]> {
        const all = await this.mesuresTerrainRepository.find({relations: ['capteur'] });

        const mapValue = (record: MesuresTerrain, value: number) => ({
            valeur: value,
            date: record.horodatage,
            zone: record.capteur?.zone || 'inconnue',
        });

        switch (type) {
            case 'ProfondeurPenetrtion':
                return all.map((m) => mapValue(m, m.profondeur_peneration));
            case 'TemperatureSol':
                return all.map((m) => mapValue(m, m.temperature_sol));
            case 'HumiditeSol':
                return all.map((m) => mapValue(m, m.humidite_sol));
            default:
                return [];
        }
    }
}
