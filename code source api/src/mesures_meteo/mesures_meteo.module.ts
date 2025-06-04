import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { MesuresMeteo } from './mesures_meteo.entity';
import { MesuresMeteoService } from './mesures_meteo.service';
import { MesuresMeteoController } from './mesures_meteo.controller';

@Module({
  imports: [TypeOrmModule.forFeature([MesuresMeteo])],
  providers: [MesuresMeteoService],
  controllers: [MesuresMeteoController]
})
export class MesuresMeteoModule {}
