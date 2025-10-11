import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../../../services/category';
import { CommonModule } from '@angular/common';
import { Product } from '../../../services/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.html',
  imports: [CommonModule],
})
export class ListProduct {
  public categories: any[] = [];
  public products: any[] = [];
  
  constructor(
    private router: Router,
    private categoryService: Category,
    private productService: Product
  ) {}

  ngOnInit() {
    this.getAllCategories();
    this.getAllProducts();
  }

  goToRouter(navigate: string) {
    this.router.navigate([navigate]);
  }

  getAllCategories() {
    this.categoryService.getAll()
    .subscribe((response: any) => {
      this.categories = response;
    }, (error) => {
      console.error('Error fetching categories:', error);
    });
  }

  getAllProducts() {
    this.productService.getAll()
    .subscribe((response: any) => {
      this.products = response;
    }, (error) => {
      console.error('Error fetching products:', error);
    });
  }
}
