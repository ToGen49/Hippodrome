import { Controller, Get, Post, Body } from '@nestjs/common';
import { CapteurService } from './capteur.service';
import { Capteur } from './capteur.entity';

@Controller('capteur')
export class CapteurController {
    constructor(private readonly capteurService: CapteurService) {}

    @Get()
    findAll(): Promise<Capteur[]> {
        return this.capteurService.findAll();
    }

    @Post()
    create(@Body() capteur: Capteur): Promise<Capteur> {
        return this.capteurService.create(capteur);
    }
}
