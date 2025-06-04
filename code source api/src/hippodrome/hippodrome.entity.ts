import { Entity, PrimaryGeneratedColumn, Column, OneToMany } from "typeorm";
import { Capteur } from 'src/capteur/capteur.entity';
import { Pistes } from "src/pistes/pistes.entity";

@Entity()
export class Hippodrome {
    @PrimaryGeneratedColumn()
    id_hippodrome: number;

    @Column()
    nom: string;

    @Column()
    ville: string;

    @Column('float')
    superficie: number;

    @Column('int')
    nb_pistes:number;

    @OneToMany(() => Capteur, (capteur) => capteur.hippodrome)
    capteurs: Capteur[];

    @OneToMany(() => Pistes, (piste) => piste.hippodrome)
    pistes: Pistes[];
}