import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, JoinColumn } from "typeorm";
import { Capteur } from "src/capteur/capteur.entity";

@Entity()
export class MesuresMeteo {
    @PrimaryGeneratedColumn()
    id_meteo: number;

    @ManyToOne(() => Capteur, (capteur) => capteur.mesuresMeteo)
    @JoinColumn({ name : 'id_capteur' })
    capteur: Capteur;

    @Column()
    horodatage: Date;

    @Column('float')
    temperature_air: number;

    @Column('float')
    temperature_air_moyenne: number;

    @Column('float')
    hygrometrie: number;

    @Column('float')
    hygrometrie_moyenne: number;

    @Column('float')
    vent_vitesse: number;

    @Column('float')
    vent_vitesse_moyenne: number;

    @Column('int')
    vent_direction: number;

    @Column('float')
    pluviometrie: number;

    @Column('float')
    ensoleillement: number;

    @Column('float')
    ensoleillement_moyenne: number;
}