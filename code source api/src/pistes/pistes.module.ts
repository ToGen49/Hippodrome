import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Pistes } from './pistes.entity';
import { PistesService } from './pistes.service';
import { PistesController } from './pistes.controller';

@Module({
  imports: [TypeOrmModule.forFeature([Pistes])],
  providers: [PistesService],
  controllers: [PistesController]
})
export class PistesModule {}
