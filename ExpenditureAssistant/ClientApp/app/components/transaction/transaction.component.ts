import { Component } from '@angular/core';
import { IDepartment } from '../../model/IDepartment';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from '../../providers/http.service';
import { HttpHandler } from '../../providers/HttpHandler';
import { ICheques } from '../../model/ICheques';
import { HttpErrorResponse } from '@angular/common/http';
import { IExpenditure } from '../../model/IExpenditure';
import { IExp_Items } from '../../model/Items';

@Component({
    selector: 'bs-transaction',
    templateUrl: './transaction.component.html',
    styleUrls: ['./transaction.component.css']
})
/** transaction component*/
export class TransactionComponent {
    form: FormGroup;
    trans: FormGroup[] = [];
    departments: IDepartment[];
    items: IExp_Items[];
    /** transaction ctor */
    constructor(route: ActivatedRoute, private router: Router, private http: HttpService, fb: FormBuilder, public hand: HttpHandler) {
        this.form = this.InitForm(fb);
        this.departments = route.snapshot.data['departments'];
        this.items = route.snapshot.data['items'];
        this.initTrans(fb);
    }

    InitForm(fb: FormBuilder) {
        return fb.group({
            chqNum: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(0.1)])],
            chequeDate: [new Date(), Validators.compose([Validators.required])]
        });
    }

    addForm() {
        this.initTrans(new FormBuilder);
    }

    /*Ensure all forms on the page are valid
     * */
    _formsValid(c_form: FormGroup, t_forms: FormGroup[]): boolean {
        return c_form.valid && t_forms.every(x => x.valid);
    }
    removeForm() {
        this.trans.shift();
    }

    initTrans(fb: FormBuilder) {
        let t_form = fb.group({
            pVNumber: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(0.1)])],
            item: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
            departmentsID: ["", Validators.compose([Validators.required, Validators.min(1)])],
            expenditureItemsID: ["", Validators.compose([Validators.required, Validators.min(1)])],
            pVDate: [new Date().toString(), Validators.compose([Validators.required])]
        });
        this.trans.unshift(t_form);
    }

    ver_amounts(chq: ICheques, exps: IExpenditure[]): boolean {
        var amt = exps.reduce((p, c) => c.amount + p, 0);
        return amt === chq.amount;
    }

    add(chq: { item: string, chqNum: string, amount: number, chequeDate: Date }, tran_gp: FormGroup[]) {
        this.hand.processing = true;
        this.hand.error = false;
        let exps: IExpenditure[] = [];
        tran_gp.forEach(x => {
            exps.unshift(x.value);
        })
        let _chq: ICheques = {
            amount: chq.amount, chequeDate: chq.chequeDate, chequeNumber: chq.chqNum, expenditures: exps
        } as ICheques;
        if (!this.ver_amounts(_chq, exps)) {
            alert("Amount on cheque must be equal to sum of PVs");
        }
        else {
            this.http.addTran(_chq).subscribe(res => this.router.navigate(['/departments']), (err: HttpErrorResponse) => this.hand.handleError(err));
        }
        this.hand.processing = false;
    }
}