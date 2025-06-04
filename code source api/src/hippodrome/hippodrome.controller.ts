import { Controller, Get, Post, Body } from '@nestjs/common';
import { HippodromeService } from './hippodrome.service';
import { Hippodrome } from './hippodrome.entity';

@Controller('hippodrome')
export class HippodromeController {
    constructor(private readonly hippodromeService: HippodromeService) {}

    @Get()
    findAll():Promise<Hippodrome[]> {
        return this.hippodromeService.findAll();
    }

    @Post()
    create(@Body() Hippodrome: Hippodrome): Promise<Hippodrome> {
        return this.hippodromeService.create(Hippodrome);
    }
}
