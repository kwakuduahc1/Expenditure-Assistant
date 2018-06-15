/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SearchDepartmentHistoryComponent } from './search-department-history.component';

let component: SearchDepartmentHistoryComponent;
let fixture: ComponentFixture<SearchDepartmentHistoryComponent>;

describe('search-department-history component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SearchDepartmentHistoryComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SearchDepartmentHistoryComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});