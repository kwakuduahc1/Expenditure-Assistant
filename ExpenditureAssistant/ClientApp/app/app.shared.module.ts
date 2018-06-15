import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { HttpService } from './providers/http.service';
import { DepartmentsComponent } from './components/departments/departments.component';
import { DepartmentsResolver } from './resolvers/DepsRes';
import { HttpClientModule } from '@angular/common/http';
import { HttpHandler } from './providers/HttpHandler';
import { EditDepartmentComponent } from './components/edit-department/edit-department.component';
import { FindDepartmentsResolver } from './resolvers/FindDepRes';
import { TransactionComponent } from './components/transaction/transaction.component';
import { SearchComponent } from './components/search/search.component';
import { NgPipesModule, RangePipe } from 'ngx-pipes';
import { SearchDepartmentHistoryComponent } from './components/search-department-history/search-department-history.component';
import { DateService } from './providers/date.service';
import { SearchSummaryComponent } from './components/search-summary/search-summary.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        DepartmentsComponent,
        EditDepartmentComponent,
        TransactionComponent,
        SearchComponent,
        SearchDepartmentHistoryComponent,
        SearchSummaryComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        NgPipesModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'departments', component: DepartmentsComponent, resolve: { deps: DepartmentsResolver } },
            { path: 'edit-dept/:id', component: EditDepartmentComponent, resolve: { dep: FindDepartmentsResolver } },
            { path: 'expend', component: TransactionComponent, resolve: { departments: DepartmentsResolver } },
            {path: 'search', component: SearchComponent,
                children: [
                    { path: 'dept-history', component: SearchDepartmentHistoryComponent, resolve: { departments: DepartmentsResolver } },
                    { path: 'summary', component: SearchSummaryComponent, resolve: { departments: DepartmentsResolver } }
                ]
            },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [HttpService, DepartmentsResolver, HttpHandler, FindDepartmentsResolver, DateService]
})
export class AppModuleShared {
}
