/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ItemSummaryComponent } from './item-summary.component';

let component: ItemSummaryComponent;
let fixture: ComponentFixture<ItemSummaryComponent>;

describe('item-summary component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ItemSummaryComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ItemSummaryComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});