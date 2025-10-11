import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../../../services/category';
import { Product } from '../../../services/product';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.html',
  imports: [CommonModule],
})
export class CreateProduct {
  public categories: any[] = [];
  public products: any[] = [];
  public productID: number | undefined | null;

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

  obtenerCategoriaPorId() {
    let categoriaId = (document.getElementById('categoria') as HTMLInputElement).value;

    console.log('Categoría seleccionada ID:', categoriaId);
  }

  addProduct() {
    const newProduct = {
      nombre: (document.getElementById('nombre') as HTMLInputElement).value,
      precio: (document.getElementById('precio') as HTMLInputElement).value,
      stock: (document.getElementById('stock') as HTMLInputElement).value,
      categoriaId: (document.getElementById('categoria') as HTMLInputElement).value,
      emoji: (document.getElementById('imagen') as HTMLInputElement).value
    }
    this.productService.create(newProduct)
    .subscribe(() => {
      (document.getElementById('nombre') as HTMLInputElement).value = '';
      (document.getElementById('precio') as HTMLInputElement).value = '';
      (document.getElementById('stock') as HTMLInputElement).value = '';
      (document.getElementById('categoria') as HTMLInputElement).value = '';
      (document.getElementById('imagen') as HTMLInputElement).value = '';
      this.getAllProducts();
    }, (error) => {
      console.error('Error creating product:', error);
    });
  }

  deleteProduct(id: number) {
    this.productService.delete(id)
    .subscribe(() => {
      this.getAllProducts();
    }, (error) => {
      console.error('Error deleting product:', error);
    });
  }

  editProduct() {
    const newProduct = {
      id: this.productID,
      nombre: (document.getElementById('nombre') as HTMLInputElement).value,
      precio: (document.getElementById('precio') as HTMLInputElement).value,
      stock: (document.getElementById('stock') as HTMLInputElement).value,
      categoriaId: +(document.getElementById('categoria') as HTMLInputElement).value,
      emoji: (document.getElementById('imagen') as HTMLInputElement).value
    };

    console.log(newProduct);
    this.productService.update(newProduct)
    .subscribe(() => {
      this.productID = null;
      (document.getElementById('nombre') as HTMLInputElement).value = '';
      (document.getElementById('precio') as HTMLInputElement).value = '';
      (document.getElementById('stock') as HTMLInputElement).value = '';
      (document.getElementById('categoria') as HTMLInputElement).value = '';
      (document.getElementById('imagen') as HTMLInputElement).value = '';
      this.getAllProducts();
    }, (error) => {
      console.error('Error creating products:', error);
    });
  }

  getProductById(id: number) {
    let product = this.products.find(product => product.id === id);
    (document.getElementById('nombre') as HTMLInputElement).value = product.nombre;
    (document.getElementById('precio') as HTMLInputElement).value = product.precio;
    (document.getElementById('stock') as HTMLInputElement).value = product.stock;
    (document.getElementById('categoria') as HTMLInputElement).value = product.categoriaId;
    (document.getElementById('imagen') as HTMLInputElement).value = product.emoji;
    this.productID = product.id;
  }

  saveChanges() {
    if (this.productID) {
      this.editProduct();
    } else {
      this.addProduct();
    }
  }
}
