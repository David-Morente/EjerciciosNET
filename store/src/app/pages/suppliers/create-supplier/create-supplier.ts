import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Supplier } from '../../../services/supplier';

@Component({
  selector: 'app-create-supplier',
  templateUrl: './create-supplier.html',
  imports: [CommonModule],
})
export class CreateSupplier {
  public suppliers: any[] = [];
  public supplierID: number | undefined | null;

  constructor(
    private router: Router,
    private supplierService: Supplier
  ) {}

  ngOnInit() {
    this.getAllSuppliers();
  }

  goToRouter(navigate: string) {
    this.router.navigate([navigate]);
  }

  getAllSuppliers() {
    this.supplierService.getAll()
    .subscribe((response: any) => {
      this.suppliers = response;
    }, (error) => {
      console.error('Error fetching suppliers:', error);
    });
  }

  addSupplier() {
    const newSupplier = {
      nombre_Empresa: (document.getElementById('nombreProveedor') as HTMLInputElement).value,
    };
    this.supplierService.create(newSupplier)
    .subscribe(() => {
      (document.getElementById('nombreProveedor') as HTMLInputElement).value = '';
      this.getAllSuppliers();
    }, (error) => {
      console.error('Error creating supplier:', error);
    });
  }

  deleteSupplier(id: number) {
    this.supplierService.delete(id)
    .subscribe(() => {
      this.getAllSuppliers();
    }, (error) => {
      console.error('Error deleting supplier:', error);
    });
  }

  editSupplier() {
    const newSupplier = {
      id: this.supplierID,
      nombre_Empresa: (document.getElementById('nombreProveedor') as HTMLInputElement).value,
    };

    this.supplierService.update(newSupplier)
    .subscribe(() => {
      this.supplierID = null;
      (document.getElementById('nombreProveedor') as HTMLInputElement).value = '';
      this.getAllSuppliers();
    }, (error) => {
      console.error('Error creating supplier:', error);
    });
  }

  getSupplierById(id: number) {
    let supplier = this.suppliers.find(supplier => supplier.id === id);
    (document.getElementById('nombreProveedor') as HTMLInputElement).value = supplier.nombre_Empresa;
    this.supplierID = supplier.id;
  }

  saveChanges() {
    if (this.supplierID) {
      this.editSupplier();
    } else {
      this.addSupplier();
    }
  }
}
