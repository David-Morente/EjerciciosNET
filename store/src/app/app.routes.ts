import { Routes } from '@angular/router';
import { MainComponent } from './pages/main/main.component';
import { Login } from './pages/user/login/login';
import { Register } from './pages/user/register/register';
import { ListProduct } from './pages/product/products/product';
import { Cart } from './pages/cart/cart';
import { CreateProduct } from './pages/product/create-product/create-product';
import { CreateCategory } from './pages/product/create-category/create-category';
import { CreateStore } from './pages/product/create-store/create-store';
import { CreateSupplier } from './pages/suppliers/create-supplier/create-supplier';
import { CreateSupplies } from './pages/supplies/create-supplies/create-supplies';
import { CategorySupplie } from './pages/supplies/category-supplies/category-supplies';
import { AddAddress } from './pages/suppliers/add-address/add-address';

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
        component: ListProduct
    },
    {
        path: 'cart',
        component: Cart
    },
    {
        path: 'register-product',
        component: CreateProduct
    },
    {
        path: 'register-category',
        component: CreateCategory
    },
    {
        path: 'register-store',
        component: CreateStore
    },
    {
        path: 'register-supplier',
        component: CreateSupplier
    },
    {
        path: 'register-supplies',
        component: CreateSupplies
    },
    {
        path: 'register-category-supplies',
        component: CategorySupplie
    },
    {
        path: 'register-address-supplier',
        component: AddAddress
    }
];
