import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { IDepartment } from "../model/IDepartment";
import { Observable } from "rxjs/Observable";
import { HttpService } from "../providers/http.service";

@Injectable()
export class DepartmentsResolver implements Resolve<Observable<IDepartment[]>> {
    resolve(route: ActivatedRouteSnapshot):Observable<IDepartment[]> {
        return this.http.getDeps();
    }

    constructor(private http: HttpService) { };
}