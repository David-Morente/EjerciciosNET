import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Supplie } from '../../../services/supplie';
import { Router } from '@angular/router';
import { Supplier } from '../../../services/supplier';
import { CategorySupplies } from '../../../services/category_insumo';

@Component({
  selector: 'app-create-supplies',
  templateUrl: './create-supplies.html',
  imports: [CommonModule],
})
export class CreateSupplies {
  public supplies: any[] = [];
  public suppliers: any[] = [];
  public category_supplies: any[] = [];
  public supplieID: number | undefined | null;

  constructor(
    private router: Router,
    private supplieService: Supplie,
    private supplierService: Supplier,
    private categorySupplieService: CategorySupplies
  ) {}

  ngOnInit() {
    this.getAllSupplies();
    this.getAllSuppliers();
    this.getAllCategorySupplies();
  }

  goToRouter(navigate: string) {
    this.router.navigate([navigate]);
  }

  getAllSupplies() {
    this.supplieService.getAll()
    .subscribe((response: any) => {
      this.supplies = response;
    }, (error) => {
      console.error('Error fetching supplies:', error);
    });
  }

  getAllSuppliers() {
    this.supplierService.getAll()
    .subscribe((response: any) => {
      this.suppliers = response;
    }, (error) => {
      console.error('Error fetching suppliers:', error);
    });
  }

  getAllCategorySupplies() {
    this.categorySupplieService.getAll()
    .subscribe((response: any) => {
      this.category_supplies = response;
    }, (error) => {
      console.error('Error fetching category supplies:', error);
    });
  }

  addSupplie() {
    const newSupplie = {
      nombre: (document.getElementById('nombreInsumo') as HTMLInputElement).value,
      cantidad: (document.getElementById('stock') as HTMLInputElement).value,
      precio: (document.getElementById('precio') as HTMLInputElement).value,
      categoriaInsumoId: (document.getElementById('categoriaInsumo') as HTMLInputElement).value,
      proveedorId: (document.getElementById('proveedor') as HTMLInputElement).value,
    };
    this.supplieService.create(newSupplie)
    .subscribe(() => {
      (document.getElementById('nombreInsumo') as HTMLInputElement).value = '';
      (document.getElementById('stock') as HTMLInputElement).value = '';
      (document.getElementById('precio') as HTMLInputElement).value = '';
      (document.getElementById('categoriaInsumo') as HTMLInputElement).value = '';
      (document.getElementById('proveedor') as HTMLInputElement).value = '';
      this.getAllSupplies();
    }, (error) => {
      console.error('Error creating supplie:', error);
    });
  }

  deleteSupplie(id: number) {
    this.supplieService.delete(id)
    .subscribe(() => {
      this.getAllSupplies();
    }, (error) => {
      console.error('Error deleting supplie:', error);
    });
  }

  editSupplie() {
    const newSupplie = {
      id: this.supplieID,
      nombre: (document.getElementById('nombreInsumo') as HTMLInputElement).value,
      cantidad: (document.getElementById('stock') as HTMLInputElement).value,
      precio: (document.getElementById('precio') as HTMLInputElement).value,
      categoriaInsumoId: (document.getElementById('categoriaInsumo') as HTMLInputElement).value,
      proveedorId: (document.getElementById('proveedor') as HTMLInputElement).value,
    };

    this.supplieService.update(newSupplie)
    .subscribe(() => {
      this.supplieID = null;
      (document.getElementById('nombreInsumo') as HTMLInputElement).value = '';
      (document.getElementById('stock') as HTMLInputElement).value = '';
      (document.getElementById('precio') as HTMLInputElement).value = '';
      (document.getElementById('categoriaInsumo') as HTMLInputElement).value = '';
      (document.getElementById('proveedor') as HTMLInputElement).value = '';
      this.getAllSuppliers();
    }, (error) => {
      console.error('Error creating supplie:', error);
    });
  }

  getSupplieById(id: number) {

    let supplie = this.supplies.find(supplie => supplie.id === id);
    console.log(supplie);
    (document.getElementById('nombreInsumo') as HTMLInputElement).value = supplie.nombre;
    (document.getElementById('stock') as HTMLInputElement).value = supplie.cantidad;
    (document.getElementById('precio') as HTMLInputElement).value = supplie.precio;
    (document.getElementById('categoriaInsumo') as HTMLInputElement).value = supplie.categoriaInsumoId;
    (document.getElementById('proveedor') as HTMLInputElement).value = supplie.proveedorId;
    this.supplieID = supplie.id;
  }

  saveChanges() {
    if (this.supplieID) {
      this.editSupplie();
    } else {
      this.addSupplie();
    }
  }
}
