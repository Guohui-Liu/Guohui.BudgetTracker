import {Income} from './income';
import {Expenditure} from './expenditure';

export interface UserDetails {
    id: number;
    email: string;
    fullName: string;
    totalIncomes: number;
    totalExpenditures: number;
    incomes: Income[];
    expenditures: Expenditure[];
}