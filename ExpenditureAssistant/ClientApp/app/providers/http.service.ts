import { Injectable } from '@angular/core';
import { IDepartment } from '../model/IDepartment';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { ICheques } from '../model/ICheques';
import { ISearch } from '../model/ISearch';
import { ISearchResults } from '../model/ISearchResults';
import { IExp_Items } from '../model/Items';
import { ISearchRange } from '../model/ISearchRange';
import { IDeptSum } from '../model/IDeptSum';
import { IItemSumRep } from '../model/ItemSumRep';
import { IExpItemHistory } from '../model/IExpItemHistory';

@Injectable()
export class HttpService {
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
    }

    getDeps(): Observable<IDepartment[]> {
        return this.http.get<IDepartment[]>(`/Departments/List`);
    }

    delDep(dep: IDepartment): Observable<Response> {
        return this.http.post<Response>('/Departments/Delete', dep)
    }

    editDep(dep: IDepartment): Observable<IDepartment> {
        return this.http.post<IDepartment>('/Departments/edit', dep);
    }

    addDep(dep: IDepartment): Observable<IDepartment> {
        return this.http.post<IDepartment>('/Departments/Create', dep);
    }

    findDep(id: number): Observable<IDepartment> {
        return this.http.get<IDepartment>(`/Departments/Find?id=${id}`);
    }

    addTran(tran: ICheques): Observable<ICheques> {
        return this.http.post<ICheques>("/Cheques/Create", tran);
    }

    deptHistory(search: ISearch): Observable<ISearchResults[]> {
        return this.http.post<ISearchResults[]>("/Departments/History", search);
    }

    deptSummary(search: ISearchRange): Observable<IDeptSum[]> {
        return this.http.post<IDeptSum[]>(`/Departments/Summary`, search);
    }

    getItems(): Observable<IExp_Items[]> {
        return this.http.get<IExp_Items[]>("/ExpenditureItems/List");
    }

    addItem(item: IExp_Items): Observable<IExp_Items> {
        return this.http.post<IExp_Items>("/ExpenditureItems/Create", item)
    }

    editItem(item: IExp_Items): Observable<IExp_Items> {
        return this.http.post<IExp_Items>("/ExpenditureItems/Edit", item)
    }

    findItem(id: number): Observable<IExp_Items> {
        return this.http.get<IExp_Items>(`/ExpenditureItems/Find?id=${id}`);
    }

    deleteItem(item: IExp_Items): Observable<IExp_Items> {
        return this.http.post<IExp_Items>("/ExpenditureItems/Delete", item)
    }

    expItemSum(search: ISearchRange): Observable<IItemSumRep[]> {
        return this.http.post<IItemSumRep[]>(`/ExpenditureItems/Summary`, search);
    }

    expItemHist(search: ISearch): Observable<IExpItemHistory[]> {
        return this.http.post<IExpItemHistory[]>("/ExpenditureItems/History", search);
    }
}