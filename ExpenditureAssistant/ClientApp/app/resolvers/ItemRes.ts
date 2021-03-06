﻿import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { HttpService } from "../providers/http.service";
import { IExp_Items } from "../model/Items";

@Injectable()
export class ItemsResolver implements Resolve<Observable<IExp_Items[]>> {
    resolve(route: ActivatedRouteSnapshot):Observable<IExp_Items[]> {
        return this.http.getItems();
    }

    constructor(private http: HttpService) { };
}