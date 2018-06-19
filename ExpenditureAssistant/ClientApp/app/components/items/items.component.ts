import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from '../../providers/http.service';
import { HttpHandler } from '../../providers/HttpHandler';
import { HttpErrorResponse } from '@angular/common/http';
import { IExp_Items } from '../../model/Items';

@Component({
    selector: 'bs-items',
    templateUrl: './items.component.html',
    styleUrls: ['./items.component.css']
})
/** items component*/
export class ItemsComponent {
    form: FormGroup;
    trans: FormGroup[] = [];
    items: IExp_Items[];
    /** transaction ctor */
    constructor(route: ActivatedRoute, private router: Router, private http: HttpService, fb: FormBuilder, public hand: HttpHandler) {
        this.form = this.InitForm(fb);
        this.items = route.snapshot.data['items'];
    }

    InitForm(fb: FormBuilder) {
        return fb.group({
            accountNumber: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            description: ["", Validators.compose([Validators.required, Validators.min(0.1)])]
        });
    }

    add(item: IExp_Items) {
        this.hand.processing = true;
        this.hand.error = false;
        this.http.addItem(item).subscribe(res => {
            this.items.unshift(res);
            this.hand.error = false;
            this.hand.message = "Item was added successfully";
        }, (err: HttpErrorResponse) => this.hand.handleError(err));
        this.hand.processing = false;
    }

    refresh() {
        this.http.getItems().subscribe(res => this.items = res, (err: HttpErrorResponse) => this.hand.handleError(err));
    }
    delete(item: IExp_Items) {
        this.hand.processing = true;
        this.hand.error = false;
        this.hand.message = "";
        if (confirm(`Are you sure you want to delete ${item.description}?`)) {
            this.http.deleteItem(item).subscribe(res => {
                let ix = this.items.findIndex(x => x.expenditureItemsID == item.expenditureItemsID);
                this.items.splice(ix, 1);
                this.hand.message = `${item.description} was deleted from the list`;
            }, (err: HttpErrorResponse) => this.hand.handleError(err));
        }
        this.hand.processing = false;
    }
}