import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { IDepartment } from "../model/IDepartment";
import { Observable } from "rxjs/Observable";
import { HttpService } from "../providers/http.service";

@Injectable()
export class FindDepartmentsResolver implements Resolve<Observable<IDepartment>> {
    resolve(route: ActivatedRouteSnapshot):Observable<IDepartment> {
        return this.http.findDep(parseInt(route.paramMap.get('id') as string) );
    }

    constructor(private http: HttpService) { };
}