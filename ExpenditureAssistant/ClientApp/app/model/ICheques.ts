import { IExpenditure } from "./IExpenditure";

export interface ICheques {
    chequesID: number;
    chequeNumber: string;
    amount: number;
    dateIssued: Date;
    expenditures: IExpenditure[];
}
