import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { MesuresMeteo } from './mesures_meteo.entity';

@Injectable()
export class MesuresMeteoService {
    constructor(
        @InjectRepository(MesuresMeteo)
        private mesuresMeteoRepository: Repository<MesuresMeteo>
    ){}

    async findByType(type: string): Promise<any[]> {
        const all = await this.mesuresMeteoRepository.find();

        const mapValue = (record: MesuresMeteo, value: number, extra?: Record<string, any>) => ({
            valeur: value,
            date: record.horodatage,
            ...(extra || {}),
        });

        switch (type) {
            case 'TemperatureAir':
                return all.map((m) => mapValue(m, m.temperature_air));
            case 'TemperatureAirMoyenne':
                return all.map((m) => mapValue(m, m.temperature_air_moyenne));
            case 'Hygrométrie':
                return all.map((m) => mapValue(m, m.hygrometrie));
            case 'HygrométrieMoyenne':
                return all.map((m) => mapValue(m, m.hygrometrie_moyenne));
            case 'Pluviometrie':
                return all.map((m) => mapValue(m, m.pluviometrie));
            case 'Ensoleillement':
                return all.map((m) => mapValue(m, m.ensoleillement));
            case 'EnsoleillementMoyenne':
                return all.map((m) => mapValue(m, m.ensoleillement_moyenne));
            case 'DirectionVent':
                return all.map((m) => mapValue(m, m.vent_direction));
            case 'VitesseVent':
                return all.map((m) => mapValue(m, m.vent_vitesse));
            case 'VitesseVentMoyenne':
                return all.map((m) => mapValue(m, m.vent_vitesse_moyenne));
            default:
                return [];
        }
    }
}
