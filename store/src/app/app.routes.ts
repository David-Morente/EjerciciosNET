import { Routes } from '@angular/router';
import { MainComponent } from './pages/main/main.component';
import { Login } from './pages/user/login/login';
import { Register } from './pages/user/register/register';
import { Product } from './pages/product/product';

export const routes: Routes = [
    {
        path: '',
        component: MainComponent
    },
    {
        path: 'login',
        component: Login
    },
    {
        path: 'register',
        component: Register
    },
    {
        path: 'product',
        component: Product
    }
];
