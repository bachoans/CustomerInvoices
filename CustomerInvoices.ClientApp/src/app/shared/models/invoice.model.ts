import { InvoiceLogModel } from "./invoice-log.model";

export interface InvoiceModel {
    id: number;
    customerId: number;
    title: string;
    createDate: string;
    dueDate: string;
    status: number;
    ccy: string;
    amount: number;
    description: string;
}