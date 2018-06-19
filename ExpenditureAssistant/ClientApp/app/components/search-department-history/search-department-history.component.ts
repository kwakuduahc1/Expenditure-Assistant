import { Component } from '@angular/core';
import { DateTime } from 'luxon';
import { ISearch } from '../../model/ISearch';
import { HttpService } from '../../providers/http.service';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { getLocaleMonthNames, FormStyle, TranslationWidth } from '@angular/common';
import { ISearchResults } from '../../model/ISearchResults';
import { IDepartment } from '../../model/IDepartment';
import { DateService } from '../../providers/date.service';

@Component({
    selector: 'bs-search-department-history',
    templateUrl: './search-department-history.component.html',
    styleUrls: ['./search-department-history.component.css']
})
/** search-department-history component*/
export class SearchDepartmentHistoryComponent {
    status: any;
    departments: IDepartment[];
    _hist: ISearchResults[] = [];
    form: FormGroup;
    _searchParams: ISearch;

    constructor(route: ActivatedRoute, private http: HttpService, fb: FormBuilder, public dates: DateService) {
        this._searchParams = {
            id: 0, fetch: 50, offset: 0, year: this.dates.date.year, month: this.dates.date.month, endMonth: this.dates.date.month + 3, endYear: this.dates.date.year
        };
        this.departments = route.snapshot.data["departments"];
        this.form = this.initForm(fb);
    }

    initForm(fb: FormBuilder) {
        return fb.group({
            id: [this._searchParams.id],
            fetch: [this._searchParams.fetch, Validators.compose([Validators.required, Validators.min(10), Validators.max(50)])],
            offset: [this._searchParams.offset, Validators.compose([Validators.required, Validators.min(0), Validators.max(50)])],
            year: [this._searchParams.year, Validators.compose([Validators.required, Validators.min(this.dates.date.year - 3), Validators.max(this.dates.date.year + 3)])],
            month: [this._searchParams.month, Validators.compose([Validators.required])],
            endYear: [this._searchParams.endYear, Validators.compose([Validators.required])],
            endMonth: [this._searchParams.endMonth, Validators.compose([Validators.required])]
        })
    }

    search(search: ISearch) {
        this.http.search(search).subscribe(res => this._hist = res, (err: HttpErrorResponse) => console.log(err));
    }

}