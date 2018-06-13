import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { IDepartment } from '../../model/IDepartment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpService } from '../../providers/http.service';
import { HttpHandler } from '../../providers/HttpHandler';

@Component({
    selector: 'bs-edit-department',
    templateUrl: './edit-department.component.html',
    styleUrls: ['./edit-department.component.css']
})
/** edit-department component*/
export class EditDepartmentComponent {

    dep: IDepartment;
    form: FormGroup;
    /** departments ctor */

    constructor(route: ActivatedRoute,private router:Router, private http: HttpService, fb: FormBuilder, public hand: HttpHandler) {
        this.dep = route.snapshot.data['dep'];
        this.form = this.InitForm(fb)
    }

    InitForm(fb: FormBuilder) {
        return fb.group({
            department: [this.dep.department, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])]
        })
    }

    edit(dept: IDepartment) {
        this.hand.processing = true;
        this.hand.error = false;
        if (dept.department) {
            this.dep.department = dept.department;
            this.http.editDep(this.dep).subscribe(res => this.router.navigate(['/departments']), (err: HttpErrorResponse) => this.hand.handleError(err))
        }
        this.hand.processing = false;
    }

    delete(dept: IDepartment) {
        this.hand.processing = true;
        this.hand.error = false;
        this.hand.message = "";
        if (confirm(`Are you sure you want to delete ${dept.department}?`)) {
            this.http.delDep(dept).subscribe(res => {
                this.hand.message = `${dept.department} was deleted from the list`;
                this.router.navigate(['/departments']);
            }, (err: HttpErrorResponse) => this.hand.handleError(err));
        }
        this.hand.processing = false;
    }
}