﻿import { Injectable } from '@angular/core';
import { IDepartment } from '../model/IDepartment';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { ICheques } from '../model/ICheques';
import { ISearch } from '../model/ISearch';
import { ISearchResults } from '../model/ISearchResults';

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

    search(search: ISearch): Observable<ISearchResults[]> {
        return this.http.post<ISearchResults[]>("/Departments/History", search);
    }

    deptSummary(year: number, month: number): Observable<Array<{ department: string, amount: number }>> {
        return this.http.get<Array<{ department: string, amount: number }>>(`/Departments/Summary?year=${year}&month=${month}`);
    }
}