import { Component } from '@angular/core';
import { IDepartment } from '../../model/IDepartment';
import { ISearchResults } from '../../model/ISearchResults';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ISearch } from '../../model/ISearch';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../../providers/http.service';
import { DateService } from '../../providers/date.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'bs-search-summary',
    templateUrl: './search-summary.component.html',
    styleUrls: ['./search-summary.component.css']
})
/** search-summary component*/
export class SearchSummaryComponent {
    _hist: Array<{ department: string, amount: number }> = [];
    form: FormGroup;
    constructor(route: ActivatedRoute, private http: HttpService, fb: FormBuilder, public dates: DateService) {
        this.form = this.initForm(fb);
    }

    initForm(fb: FormBuilder) {
        return fb.group({
            year: [this.dates.years[1], Validators.compose([Validators.required, Validators.min(this.dates.date.year - 3), Validators.max(this.dates.date.year + 3)])],
            month: [1, Validators.compose([Validators.required])],
        })
    }

    search(form: { year: number, month: number }) {
        this.http.deptSummary(form.year, form.month).subscribe(res => this._hist = res, (err: HttpErrorResponse) => console.log(err));
    }
}