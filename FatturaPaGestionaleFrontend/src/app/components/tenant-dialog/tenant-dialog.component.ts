import { Component, OnInit, Inject, Output, EventEmitter, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Tenant } from '../../models/dto/cf/cf01-tenant.dto';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import { CheckBoxModule } from '@syncfusion/ej2-angular-buttons';

@Component({
  selector: 'app-tenant-dialog',
  templateUrl: './tenant-dialog.component.html',
  styleUrls: ['./tenant-dialog.component.css', '../../../styles/dialog.css'],
  standalone: false
})
export class TenantDialogComponent implements OnInit {
  @Input() tenant: Tenant | null = null;
  @Output() cancel = new EventEmitter<void>();
  @Output() save = new EventEmitter<Tenant>();

  tenantForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.tenantForm = this.fb.group({
      cf01Nome: ['', Validators.required],
      cf01Datarinnovo: [new Date()],
      cf01Deleted: [false]
    });
  }

  ngOnInit(): void {

    if (this.tenant) {
      this.tenantForm.patchValue({
        cf01Nome: this.tenant.cf01Nome,
        cf01Datarinnovo: this.tenant.cf01Datarinnovo,
        cf01Deleted: this.tenant.cf01Deleted
      });
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.tenant) {
      this.tenantForm.patchValue({
        cf01Nome: this.tenant.cf01Nome,
        cf01Datarinnovo: this.tenant.cf01Datarinnovo,
        cf01Deleted: this.tenant.cf01Deleted
      });
    }else{
      this.tenantForm.reset();
    }
  }

  onCancel(): void {
    this.cancel.emit();
  }

  onSubmit(): void {
    if (this.tenantForm.valid) {
      const formValue = this.tenantForm.value;
      const tenantToSave: Tenant = {
        ...formValue,
        cf01Tenant1: this.tenant?.cf01Tenant1
      };
      this.save.emit(tenantToSave);
    }
  }
}
