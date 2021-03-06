﻿import { Component } from '@angular/core';
import { IDepartment } from '../../model/IDepartment';
import { ISearchResults } from '../../model/ISearchResults';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ISearch } from '../../model/ISearch';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../../providers/http.service';
import { DateService } from '../../providers/date.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ISearchRange } from '../../model/ISearchRange';
import { IDeptSum } from '../../model/IDeptSum';

@Component({
    selector: 'bs-search-summary',
    templateUrl: './search-summary.component.html',
    styleUrls: ['./search-summary.component.css']
})
/** search-summary component*/
export class SearchSummaryComponent {
    _hist: IDeptSum[] = [];
    form: FormGroup;
    constructor(route: ActivatedRoute, private http: HttpService, fb: FormBuilder, public dates: DateService) {
        this.form = this.initForm(fb);
    }

    initForm(fb: FormBuilder) {
        return fb.group({
            year: [this.dates.years[1], Validators.compose([Validators.required, Validators.min(this.dates.date.year - 3), Validators.max(this.dates.date.year + 3)])],
            month: [1, Validators.compose([Validators.required])],
            endYear: [this.dates.years[1], Validators.compose([Validators.required, Validators.min(this.dates.date.year - 3), Validators.max(this.dates.date.year + 3)])],
            endMonth: [this.dates.date.month, Validators.compose([Validators.required])],
        })
    }

    search(form: ISearchRange) {
        this.http.deptSummary(form).subscribe(res => this._hist = res, (err: HttpErrorResponse) => console.log(err));
    }
}