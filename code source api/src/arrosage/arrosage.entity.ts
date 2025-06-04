import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, JoinColumn } from "typeorm";
import { Pistes } from "src/pistes/pistes.entity";

@Entity()
export class Arrosage {
    @PrimaryGeneratedColumn()
    id_arrosage: number;

    @Column()
    horodatage: Date;

    @Column()
    quantite:number;

    @ManyToOne(() => Pistes, (pistes) => pistes.arrosage)
    @JoinColumn()
    piste: Pistes;
}