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

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        DepartmentsComponent,
        EditDepartmentComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'departments', component: DepartmentsComponent, resolve: { deps: DepartmentsResolver } },
            { path: 'edit-dept/:id', component: EditDepartmentComponent, resolve: { dep: FindDepartmentsResolver } },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [HttpService, DepartmentsResolver, HttpHandler, FindDepartmentsResolver]
})
export class AppModuleShared {
}
