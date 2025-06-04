import { Controller, Get, Param } from '@nestjs/common';
import { MesuresTerrain } from './mesures_terrain.entity';
import { MesuresTerrainService } from './mesures_terrain.service';

@Controller('mesures-meteo')
export class MesuresTerrainController {
    constructor(private readonly service:MesuresTerrainService) {}

    @Get('type/:type')
    async findByType(@Param('type') type:string) {
        return this.service.findByType(type);
    }
}
