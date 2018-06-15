/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SearchSummaryComponent } from './search-summary.component';

let component: SearchSummaryComponent;
let fixture: ComponentFixture<SearchSummaryComponent>;

describe('search-summary component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SearchSummaryComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SearchSummaryComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});