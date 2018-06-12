import { Injectable } from '@angular/core';
import { IDepartment } from '../model/IDepartment';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {
    http: HttpClient;
    constructor(http: HttpClient) {
        this.http = http;
    }

    getDeps(): Observable<IDepartment[]> {
        return this.http.get<IDepartment[]>(`/Departments/List`);
    }

    delDep(dep:IDepartment): Observable<Response> {
        return this.http.post<Response>('/Departments/Delete',dep)
    }

    editDep(dep: IDepartment): Observable<IDepartment> {
        return this.http.post<IDepartment>('/Departments/edit', dep);
    }

    findDep(id: number): Observable<IDepartment> {
        return this.http.get<IDepartment>(`/Departments/Find?id=${id}`);
    }
}