import { Controller, Get, Post, Body } from '@nestjs/common';
import { PistesService } from './pistes.service';
import { Pistes } from './pistes.entity';

@Controller('pistes')
export class PistesController {
    constructor(private readonly pistesService: PistesService) {}

    @Get()
    findAll(): Promise<Pistes[]> {
        return this.pistesService.findAll();
    }

    @Post()
    create(@Body() pistes: Pistes): Promise<Pistes> {
        return this.pistesService.create(pistes);
    }
}
