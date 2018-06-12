import { ICheques } from "./ICheques";
import { IDepartment } from "./IDepartment";

export interface IExpenditure {
    expenditureID: number;
    item: string;
    pVNumber: string;
    departmentsID: number;
    dateDone: Date;
    chequesID: number;
    concurrency: string;
    cheques: ICheques;
    departments: IDepartment
}