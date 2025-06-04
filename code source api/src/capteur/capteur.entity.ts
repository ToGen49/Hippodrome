import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, OneToMany, JoinColumn } from "typeorm";
import { Hippodrome } from "src/hippodrome/hippodrome.entity";
import { MesuresMeteo } from "src/mesures_meteo/mesures_meteo.entity";
import { MesuresTerrain } from "src/mesures_terrain/mesures_terrain.entity";

@Entity()
export class Capteur {
    @PrimaryGeneratedColumn()
    id_capteur: number;

    @ManyToOne(() => Hippodrome, (hippodrome) => hippodrome.capteurs)
    @JoinColumn({ name: 'id_hippodrome' })
    hippodrome: Hippodrome;

    @Column()
    type_capteur: string;

    @Column()
    zone: number;

    @OneToMany(() => MesuresMeteo, (mesure) => mesure.capteur)
    mesuresMeteo: MesuresMeteo[];

    @OneToMany(() => MesuresTerrain, (mesure) => mesure.capteur)
    mesuresTerrain: MesuresTerrain[];
}