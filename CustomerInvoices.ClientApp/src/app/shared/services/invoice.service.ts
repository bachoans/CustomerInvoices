import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, delay, map, Observable, Subject, throwError } from 'rxjs';
import { InvoiceModel } from '../models/invoice.model';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http'
import { ErrorService } from './common/error.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  public invoice$:  BehaviorSubject<InvoiceModel>= new BehaviorSubject<InvoiceModel>({} as InvoiceModel);
  public invoiceList$: BehaviorSubject<InvoiceModel[]> = new BehaviorSubject<InvoiceModel[]>([]);

  constructor(private httpclient: HttpClient, private errorService: ErrorService) { }

  GetInvoiceList(page: number, pageSize: number) : Observable<InvoiceModel[]> {
    return this.httpclient.get<InvoiceModel[]>(environment.baseUrl + `Invoice/List?page=0&pageSize=10`);
  }

  Create(): Observable<InvoiceModel> {
    return this.httpclient.post<InvoiceModel>(environment.baseUrl + 'Invoice/Create', this.invoice$);
  }

  Update(): Observable<InvoiceModel> {
    return this.httpclient.put<InvoiceModel>(environment.baseUrl + 'Invoice/Update', this.invoice$);
  }

  private errorHandler(error: HttpErrorResponse){
    this.errorService.handle(error.message);
    return throwError(()=>error.message);
  }
}
