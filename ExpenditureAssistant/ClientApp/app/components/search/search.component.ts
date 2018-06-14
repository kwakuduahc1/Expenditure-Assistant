import { Component } from '@angular/core';
import { DateTime } from 'luxon';
import { ISearch } from '../../model/ISearch';
import { HttpService } from '../../providers/http.service';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { getLocaleMonthNames, FormStyle, TranslationWidth } from '@angular/common';
import { forEach } from '@angular/router/src/utils/collection';
import { ISearchResults } from '../../model/ISearchResults';
import { IDepartment } from '../../model/IDepartment';

@Component({
    selector: 'bs-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})
/** Search component*/
export class SearchComponent {
    status: any;
    date = DateTime.local();
    _searchParams: ISearch;
    departments: IDepartment[];
    _hist: ISearchResults[] = [];
    form: FormGroup;
    years: number[];
    months: Array<{ month: string, value: number }>;

    constructor(route: ActivatedRoute, private http: HttpService, fb: FormBuilder) {
        this._searchParams = {
            id: 0, fetch: 50, offset: 0, year: this.date.year, month: this.date.month
        }
        this.form = this.initForm(fb);
        this.departments = route.snapshot.data["departments"];
        this.years = [this._searchParams.year - 1, this._searchParams.year, this._searchParams.year + 1];
        this.months = this.getMonths();

    }

    getMonths(): Array<{ month: string, value: number }> {
        let months: Array<{ month: string, value: number }> = [];
        let _myDate = getLocaleMonthNames(this.date.locale, FormStyle.Standalone, TranslationWidth.Wide);
        for (var i = 0; i < _myDate.length; i++) {
            months.push({ month: _myDate[i], value: i + 1 });
        }
        return months;
    }
    initForm(fb: FormBuilder) {
        return fb.group({
            id: [this._searchParams.id],
            fetch: [this._searchParams.fetch, Validators.compose([Validators.required, Validators.min(10), Validators.max(50)])],
            offset: [this._searchParams.offset, Validators.compose([Validators.required, Validators.min(0), Validators.max(50)])],
            year: [this._searchParams.year, Validators.compose([Validators.required, Validators.min(this.date.year - 3), Validators.max(this.date.year + 3)])],
            month: [this._searchParams.month, Validators.compose([Validators.required, Validators.max(this.date.month)])],
        })
    }

    search(search: ISearch) {
        this.http.search(search).subscribe(res => this._hist = res, (err: HttpErrorResponse) => console.log(err));
    }
}