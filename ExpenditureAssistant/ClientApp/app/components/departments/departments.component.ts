import { Component } from '@angular/core';
import { IDepartment } from '../../model/IDepartment';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpService } from '../../providers/http.service';
import { HttpErrorResponse } from '@angular/common/http';
import { HttpHandler } from '../../providers/HttpHandler';

@Component({
    selector: 'bs-departments',
    templateUrl: './departments.component.html',
    styleUrls: ['./departments.component.css']
})
/** departments component*/
export class DepartmentsComponent {

    deps: IDepartment[];
    form: FormGroup;
    /** departments ctor */
    constructor(route: ActivatedRoute, private http: HttpService, fb: FormBuilder, public hand: HttpHandler) {
        this.deps = route.snapshot.data['deps'];
        this.form = this.InitForm(fb)
    }

    InitForm(fb: FormBuilder) {
        return fb.group({
            department: ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])]
        })
    }

    add(dept: IDepartment) {
        this.hand.processing = true;
        this.hand.error = false;
        if (dept.department) {
            this.http.addDep(dept).subscribe(res=> this.deps.unshift(res),(err:HttpErrorResponse)=>this.hand.handleError(err))
        }
        this.hand.processing = false;
    }

    delete(dept: IDepartment) {
        this.hand.processing = true;
        this.hand.error = false;
        this.hand.message = "";
        if (confirm(`Are you sure you want to delete ${dept.department}?`)) {
            this.http.delDep(dept).subscribe(res => {
                let ix = this.deps.findIndex(x => x.departmentsID == dept.departmentsID);
                this.deps.splice(ix, 1);
                this.hand.message = `${dept.department} was deleted from the list`;
            }, (err: HttpErrorResponse) => this.hand.handleError(err));
        }
        this.hand.processing = false;
    }
}