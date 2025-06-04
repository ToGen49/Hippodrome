import { Controller, Get, Param } from '@nestjs/common';
import { MesuresMeteoService } from './mesures_meteo.service';
import { MesuresMeteo } from './mesures_meteo.entity';

@Controller('mesures-meteo')
export class MesuresMeteoController {
    constructor(private readonly service:MesuresMeteoService) {}

    @Get('type/:type')
    async findByType(@Param('type') type:string) {
        return this.service.findByType(type);
    }
}
