/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { TransactionComponent } from './transaction.component';

let component: TransactionComponent;
let fixture: ComponentFixture<TransactionComponent>;

describe('transaction component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ TransactionComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(TransactionComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});