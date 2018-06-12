import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { IDepartment } from '../model/IDepartment';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class HttpService {
    http: Http;
    constructor(http: Http) {
        this.http = http;
    }

    getDeps(): Observable<IDepartment[]> {
        return this.http.get(`/Departments/List`).map(x=>x.json());
    }

    delDep(dep:IDepartment): Observable<Response> {
        return this.http.post('/Departments/Delete',dep)
    }

    editDep(dep: IDepartment): Observable<IDepartment> {
        return this.http.post('/Departments/edit', dep).map(x => x.json());
    }

    findDep(id: number): Observable<IDepartment> {
        return this.http.get(`/Departments/Find?id=${id}`).map(x => x.json());
    }
}