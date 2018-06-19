import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpService } from '../../providers/http.service';
import { HttpHandler } from '../../providers/HttpHandler';
import { IExp_Items } from '../../model/Items';

@Component({
    selector: 'bs-edit-item',
    templateUrl: './edit-item.component.html',
    styleUrls: ['./edit-item.component.css']
})
/** edit.item component*/
export class EditItemComponent {
    item: IExp_Items;
    form: FormGroup;
    /** departments ctor */

    constructor(route: ActivatedRoute, private router: Router, private http: HttpService, fb: FormBuilder, public hand: HttpHandler) {
        this.item = route.snapshot.data['item'];
        this.form = this.InitForm(fb);
        console.log(this.item);
    }

    InitForm(fb: FormBuilder) {
        return fb.group({
            accountNumber: [this.item.accountNumber, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
            description: [this.item.description, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])]
        })
    }

    edit(item: IExp_Items) {
        this.hand.processing = true;
        this.hand.error = false;
        if (item.accountNumber && item.description) {
            this.item.accountNumber = item.accountNumber;
            this.item.description = item.description;
            this.http.editItem(this.item).subscribe(res => this.router.navigate(['/items']), (err: HttpErrorResponse) => this.hand.handleError(err))
        }
        this.hand.processing = false;
    }

    delete() {
        this.hand.processing = true;
        this.hand.error = false;
        this.hand.message = "";
        if (confirm(`Are you sure you want to delete ${this.item.description}?`)) {
            this.http.deleteItem(this.item).subscribe(res => {
                this.hand.message = `${this.item.description} was deleted from the list`;
                this.router.navigate(['/items']);
            }, (err: HttpErrorResponse) => this.hand.handleError(err));
        }
        this.hand.processing = false;
    }
}