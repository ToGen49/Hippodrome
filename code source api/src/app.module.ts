import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { HippodromeModule } from './hippodrome/hippodrome.module';
import { CapteurModule } from './capteur/capteur.module';
import { MesuresMeteoModule } from './mesures_meteo/mesures_meteo.module';
import { MesuresTerrainModule } from './mesures_terrain/mesures_terrain.module';
import { ArrosageModule } from './arrosage/arrosage.module';
import { PistesModule } from './pistes/pistes.module';
import { Hippodrome } from './hippodrome/hippodrome.entity';
import { Capteur } from './capteur/capteur.entity';
import { MesuresMeteo } from './mesures_meteo/mesures_meteo.entity';
import { MesuresTerrain } from './mesures_terrain/mesures_terrain.entity';
import { Pistes } from './pistes/pistes.entity';
import { Arrosage } from './arrosage/arrosage.entity';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'postgres',
      host: 'localhost',
      port: 5432,
      username: "postgres",
      password: 'password',
      database: 'hippodrome_db',
      entities: [Hippodrome, Capteur, MesuresMeteo, MesuresTerrain, Pistes, Arrosage],
      synchronize: false,
    }),
    HippodromeModule, 
    CapteurModule, 
    MesuresMeteoModule, 
    MesuresTerrainModule, 
    ArrosageModule, 
    PistesModule],
})
export class AppModule {}
