import { Injectable } from '@angular/core';
import { DateTime } from 'luxon';
import { getLocaleMonthNames, FormStyle, TranslationWidth } from '@angular/common';
import { ISearch } from '../model/ISearch';

@Injectable()
export class DateService {
    readonly date = DateTime.local();
    readonly years: number[];
    readonly months: Array<{ month: string, value: number }>;

    constructor() {
        this.years = [this.date.year - 1, this.date.year, this.date.year + 1];
        this.months = this.getMonths();
    }

    private getMonths(): Array<{ month: string, value: number }> {
        let months: Array<{ month: string, value: number }> = [];
        let _myDate = getLocaleMonthNames(this.date.locale, FormStyle.Standalone, TranslationWidth.Wide);
        for (var i = 0; i < _myDate.length; i++) {
            months.push({ month: _myDate[i], value: i + 1 });
        }
        return months;
    }

}