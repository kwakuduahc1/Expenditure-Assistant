import { Component } from '@angular/core';
import { IDepartment } from '../../model/IDepartment';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'bs-departments',
    templateUrl: './departments.component.html',
    styleUrls: ['./departments.component.css']
})
/** departments component*/
export class DepartmentsComponent {

    deps: IDepartment[];
    /** departments ctor */

    constructor(route: ActivatedRoute) {
        this.deps = route.snapshot.data['deps'];
    }
}