import { Routes } from '@angular/router';
import { LoginComponent } from './main/login/login.component';
import { RegisterComponent } from './main/register/register.component';
import { HomeComponent } from './main/home/home.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'home', component: HomeComponent },
    { path: '**', redirectTo: 'home' }
];
