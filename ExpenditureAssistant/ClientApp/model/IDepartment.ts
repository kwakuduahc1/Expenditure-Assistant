import { IExpenditure } from "./IExpenditure";

export interface IDepartment {
    departmentsID: number;
    department: string;
    concurrency: string;
    expenditure: IExpenditure[];
    amount: number;
}
