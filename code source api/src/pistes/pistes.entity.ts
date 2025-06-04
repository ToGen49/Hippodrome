import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, JoinColumn, OneToMany } from "typeorm";
import { Hippodrome } from "src/hippodrome/hippodrome.entity";
import { Arrosage } from 'src/arrosage/arrosage.entity'

@Entity()
export class Pistes {
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    numero_piste: string;

    @ManyToOne(() => Hippodrome, (hippodrome) => hippodrome.nb_pistes)
    @JoinColumn({ name: 'id_hippodrome' })
    hippodrome:Hippodrome;

    @OneToMany(() => Arrosage, (arrosage) => arrosage.piste)
    arrosage: Arrosage[];
}