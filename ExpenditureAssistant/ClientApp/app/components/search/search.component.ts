import { Component } from '@angular/core';
import { DateTime } from 'luxon';
import { ISearch } from '../../model/ISearch';

@Component({
    selector: 'bs-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})
/** Search component*/
export class SearchComponent {
    date: DateTime = new DateTime();
    _searchParams: ISearch
    /** Search ctor */
    constructor() {
        this._searchParams = {
            id: 0, fetch: 50, offset: 0, year: this.date.year, month: this.date.month
        }
    }

    search(search: ISearch) {

    }
}