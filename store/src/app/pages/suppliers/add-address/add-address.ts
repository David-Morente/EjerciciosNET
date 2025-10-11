import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AddressSuppliers } from '../../../services/address-suppliers';
import { Supplier } from '../../../services/supplier';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.html',
  imports: [CommonModule],
})
export class AddAddress {
  public address: any[] = [];
  public suppliers: any[] = [];
  public addressID: number | undefined | null;

  constructor(
    private router: Router,
    private addressService: AddressSuppliers,
    private supplierService: Supplier
  ) {}

  ngOnInit() {
    this.getAllAddressSuppliers();
    this.getAllSuppliers();
  }

  goToRouter(navigate: string) {
    this.router.navigate([navigate]);
  }

  getAllAddressSuppliers() {
    this.addressService.getAll()
    .subscribe((response: any) => {
      this.address = response;
    }, (error) => {
      console.error('Error fetching address suppliers:', error);
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

  //

  addAddressSupplier() {
    const newAddressSupplier = {
      calle: (document.getElementById('calle') as HTMLInputElement).value,
      codigoPostal: (document.getElementById('codigoPostal') as HTMLInputElement).value,
      ciudad: (document.getElementById('ciudad') as HTMLInputElement).value,
      proveedorId: (document.getElementById('proveedor') as HTMLInputElement).value,
    };
    this.addressService.create(newAddressSupplier)
    .subscribe(() => {
      (document.getElementById('calle') as HTMLInputElement).value = '';
      (document.getElementById('codigoPostal') as HTMLInputElement).value = '';
      (document.getElementById('ciudad') as HTMLInputElement).value = '';
      (document.getElementById('proveedor') as HTMLInputElement).value = '';
      this.getAllAddressSuppliers();
    }, (error) => {
      console.error('Error creating address supplier:', error);
    });
  }

  deleteAddressSupplier(id: number) {
    this.addressService.delete(id)
    .subscribe(() => {
      this.getAllAddressSuppliers();
    }, (error) => {
      console.error('Error deleting address supplier:', error);
    });
  }

  editAddressSupplier() {
    const newAddressSupplier = {
      id: this.addressID,
      calle: (document.getElementById('calle') as HTMLInputElement).value,
      codigoPostal: (document.getElementById('codigoPostal') as HTMLInputElement).value,
      ciudad: (document.getElementById('ciudad') as HTMLInputElement).value,
      proveedorId: (document.getElementById('proveedor') as HTMLInputElement).value,
    };

    this.addressService.update(newAddressSupplier)
    .subscribe(() => {
      this.addressID = null;
      (document.getElementById('calle') as HTMLInputElement).value = '';
      (document.getElementById('codigoPostal') as HTMLInputElement).value = '';
      (document.getElementById('ciudad') as HTMLInputElement).value = '';
      (document.getElementById('proveedor') as HTMLInputElement).value = '';
      this.getAllAddressSuppliers();
    }, (error) => {
      console.error('Error creating address supplier:', error);
    });
  }

  getAddressSupplierById(id: number) {
    let address = this.address.find(address => address.id === id);
    (document.getElementById('calle') as HTMLInputElement).value = address.calle;
    (document.getElementById('codigoPostal') as HTMLInputElement).value = address.codigoPostal;
    (document.getElementById('ciudad') as HTMLInputElement).value = address.ciudad;
    (document.getElementById('proveedor') as HTMLInputElement).value = address.proveedorId;
    this.addressID = address.id;
  }

  saveChanges() {
    if (this.addressID) {
      this.editAddressSupplier();
    } else {
      this.addAddressSupplier();
    }
  }
}
