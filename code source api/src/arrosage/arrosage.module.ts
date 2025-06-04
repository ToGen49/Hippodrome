import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Arrosage } from './arrosage.entity';
import { ArrosageService } from './arrosage.service';
import { ArrosageController } from './arrosage.controller';

@Module({
  imports: [TypeOrmModule.forFeature([Arrosage])],
  providers: [ArrosageService],
  controllers: [ArrosageController]
})
export class ArrosageModule {}
