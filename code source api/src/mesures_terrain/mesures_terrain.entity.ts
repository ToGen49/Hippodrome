import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, JoinColumn } from "typeorm";
import { Capteur } from "src/capteur/capteur.entity";

@Entity()
export class MesuresTerrain {
    @PrimaryGeneratedColumn()
    id_terrain: number;

    @ManyToOne(() => Capteur, (capteur) => capteur.mesuresMeteo)
    @JoinColumn({ name: 'id_capteur'})
    capteur: Capteur;

    @Column()
    horodatage: Date;

    @Column('float')
    profondeur_peneration: number;

    @Column('float')
    temperature_sol: number;

    @Column('float')
    humidite_sol: number;
}