import {Income} from './income';
import {Expenditure} from './expenditure';

export interface UserCreate {
    email: string;
    fullname: string;
    joinedOn: Date;
    incomes: Income[];
    expenditures: Expenditure[];
}
