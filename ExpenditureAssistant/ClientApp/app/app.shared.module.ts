import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { HttpService } from './providers/http.service';
import { DepartmentsComponent } from './components/departments/departments.component';
import { DepartmentsResolver } from './resolvers/DepsRes';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        DepartmentsComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'departments', component: DepartmentsComponent, resolve: { deps: DepartmentsResolver } },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[HttpService, DepartmentsResolver]
})
export class AppModuleShared {
}
