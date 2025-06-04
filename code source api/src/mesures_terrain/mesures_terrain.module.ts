import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { MesuresTerrain } from './mesures_terrain.entity';
import { MesuresTerrainService } from './mesures_terrain.service';
import { MesuresTerrainController } from './mesures_terrain.controller';

@Module({
  imports: [TypeOrmModule.forFeature([MesuresTerrain])],
  providers: [MesuresTerrainService],
  controllers: [MesuresTerrainController]
})
export class MesuresTerrainModule {}
