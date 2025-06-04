import { Module } from '@nestjs/common';
import { HippodromeService } from './hippodrome.service';
import { HippodromeController } from './hippodrome.controller';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Hippodrome } from './hippodrome.entity';

@Module({
  imports: [TypeOrmModule.forFeature([Hippodrome])],
  providers: [HippodromeService],
  controllers: [HippodromeController]
})
export class HippodromeModule {}
