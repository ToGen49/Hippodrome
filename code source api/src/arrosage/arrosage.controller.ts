import { Controller, Get, Body, Post } from '@nestjs/common';
import { ArrosageService } from './arrosage.service';
import { Arrosage } from './arrosage.entity';

@Controller('arrosage')
export class ArrosageController {
    constructor(private readonly arrosageService: ArrosageService) {}

    @Get()
    findAll(): Promise<Arrosage[]> {
        return this.arrosageService.findAll();
    }

    @Post()
    create(@Body() arrosage: Arrosage): Promise<Arrosage> {
        return this.arrosageService.create(arrosage);
    }
}
