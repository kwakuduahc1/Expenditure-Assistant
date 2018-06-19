import { IExpenditure } from "./IExpenditure";

export interface IExp_Items {
    expenditureItemsID: number;
    accountNumber: number;
    description: string;
    expenditures: IExpenditure[];
}